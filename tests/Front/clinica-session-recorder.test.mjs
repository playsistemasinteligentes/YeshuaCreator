import test from 'node:test';
import assert from 'node:assert/strict';
import { readFile } from 'node:fs/promises';
const source=await readFile(new URL('../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/spa/scripts/components/recording/session-recorder.js',import.meta.url),'utf8');
const {SessionRecorder}=await import('data:text/javascript;base64,'+Buffer.from(source).toString('base64'));
const delay=ms=>new Promise(resolve=>setTimeout(resolve,ms));
async function until(predicate){for(let i=0;i<300;i++){if(await predicate())return;await delay(2);}throw new Error('Condition timed out');}
class Store{
    rows=new Map();chunks=new Map();peak=0;
    async put(value){this.rows.set(value.id,structuredClone(value));}
    async all(){return [...this.rows.values()].map(x=>structuredClone(x));}
    async saveChunk(item,index,blob){await this.put(item);this.chunks.set(item.id+'_'+index,{key:item.id+'_'+index,sessionId:item.id,index,blob,acknowledged:false});this.peak=Math.max(this.peak,this.chunks.size);}
    async next(item){const rows=[...this.chunks.values()].filter(x=>x.sessionId===item.id).sort((a,b)=>a.index-b.index);return rows.find(x=>!x.acknowledged)||(item.final?rows.find(x=>x.index===item.finalIndex):null);}
    async acknowledge(item,chunk,previous){if(previous>=0&&previous!==chunk.index)this.chunks.delete(item.id+'_'+previous);this.chunks.set(chunk.key,{...chunk,acknowledged:true});await this.put(item);}
    async remove(id){this.rows.delete(id);for(const [key,chunk]of this.chunks)if(chunk.sessionId===id)this.chunks.delete(key);}
}
class Recorder{
    static isTypeSupported(){return true;}
    state='inactive';emptyStop=false;
    start(interval){assert.equal(interval,10000);this.state='recording';}
    pause(){this.state='paused';}
    resume(){this.state='recording';}
    part(text){this.ondataavailable({data:new Blob([text])});}
    stop(){this.state='inactive';this.part(this.emptyStop?'':'final');this.onstop();}
}
const good=async(token,blob,index,final)=>({success:true,isFinalized:final,sagaId:final?42:0});
function fixture(sendChunk=good,store=new Store(),options={}){
    const tracks={stopped:false,stop(){this.stopped=true;}};
    const r=new SessionRecorder({actor:'1:7',sessionId:12,startSession:async()=> 'private-upload-token',sendChunk,store,mediaDevices:{getUserMedia:async()=>({getTracks:()=>[tracks]})},Recorder,retryBase:10,retryMax:20,...options});
    return {r,store,tracks};
}

test('sends during capture; stopping waits for final data persistence and saga acknowledgement',async()=>{
    const calls=[];const {r,store,tracks}=fixture(async(token,blob,index,final)=>{calls.push({text:await blob.text(),index,final});return good(token,blob,index,final);});
    await r.start();r.recorder.part('first');await until(()=>r.pending.acknowledged===1);assert.equal(r.state,'recording');
    await r.stop();assert.deepEqual(calls,[{text:'first',index:0,final:false},{text:'final',index:1,final:true}]);
    assert.equal(r.sagaId,42);assert.equal(r.state,'completed');assert.equal(tracks.stopped,true);assert.equal(store.rows.size,0);assert.equal(store.chunks.size,0);
});

test('an hour at ten-second intervals keeps only a confirmed tail and current pending chunk',async()=>{
    const {r,store}=fixture();await r.start();
    try{for(let index=0;index<360;index++){r.recorder.part('part-'+index);await until(()=>r.pending.acknowledged===index+1);assert.equal(store.chunks.size,1);assert.equal(r.pending.chunks,undefined);}}
    finally{await r.stop();}
    assert(store.peak<=2);assert.equal(store.rows.size,0);
});

test('empty final event replays the retained last confirmed chunk with the same index',async()=>{
    const calls=[];const {r}=fixture(async(t,b,i,f)=>{calls.push([i,f,await b.text()]);return good(t,b,i,f);});await r.start();r.recorder.part('head');await until(()=>r.pending.acknowledged===1);r.recorder.emptyStop=true;await r.stop();
    assert.deepEqual(calls,[[0,false,'head'],[0,true,'head']]);
});

test('offline capture pauses on queue limit and resumes after background retry without losing chunks',async()=>{
    let online=false;const {r,store}=fixture(async(...args)=>{if(!online)throw new Error('offline');return good(...args);},new Store(),{maxPending:3});
    await r.start();for(let i=0;i<3;i++){r.recorder.part('part-'+i);await r.writeChain;}await until(()=>r.state==='paused');assert(r.autoPaused);assert.equal(store.chunks.size,3);assert.throws(()=>r.resume(),/Aguarde/);
    online=true;await until(()=>r.state==='recording'&&r.pending.acknowledged===3);assert.equal(store.chunks.size,1);await r.stop();assert.equal(store.chunks.size,0);
});

test('manual pause is preserved while uploads recover',async()=>{
    let online=false;const {r}=fixture(async(...args)=>{if(!online)throw new Error('offline');return good(...args);});await r.start();r.recorder.part('head');await r.writeChain;r.pause();online=true;await until(()=>r.pending.acknowledged===1);assert.equal(r.state,'paused');assert.equal(r.recorder.state,'paused');r.resume();await r.stop();
});

test('stop during an in-flight send remains sequential and waits for the final response',async()=>{
    let release;const gate=new Promise(resolve=>release=resolve);let active=0,peak=0;const calls=[];
    const {r}=fixture(async(t,b,i,f)=>{active++;peak=Math.max(peak,active);calls.push([i,f]);if(i===0)await gate;active--;return good(t,b,i,f);});
    await r.start();r.recorder.part('head');await until(()=>active===1);const stopping=r.stop();await delay(5);release();await stopping;
    assert.equal(peak,1);assert.deepEqual(calls,[[0,false],[1,true]]);assert.equal(r.sagaId,42);
});

test('recovery is actor/session bound and continues only remaining indexes',async()=>{
    let online=true;const {r,store}=fixture(async(...args)=>{if(!online)throw new Error('offline');return good(...args);});
    await r.start();r.recorder.part('first');await until(()=>r.pending.acknowledged===1);online=false;r.recorder.part('second');await assert.rejects(r.stop(),/offline/);
    assert.equal(store.rows.size,1);const other=fixture(undefined,store).r;other.actor='2:7';assert.equal((await other.recoverable()).length,0);other.actor='1:7';other.sessionId=13;assert.equal((await other.recoverable()).length,0);
    const calls=[];const recovered=fixture(async(t,b,i,f)=>{calls.push(i);return good(t,b,i,f);},store).r;
    await recovered.recover((await recovered.recoverable())[0].id);assert.deepEqual(calls,[1,2]);assert.equal(recovered.sagaId,42);assert.equal(store.chunks.size,0);other.dispose();recovered.dispose();
});

test('HTTP success without final saga acknowledgement retains the final chunk',async()=>{
    const {r,store}=fixture(async()=>({success:true,isFinalized:false,sagaId:0}));await r.start();await assert.rejects(r.stop(),/não confirmou/);assert.equal(store.rows.size,1);assert.equal(store.chunks.size,1);
});

test('ambiguous final timeout can replay an already finalized upload idempotently',async()=>{
    let accepted=false;const {r,store}=fixture(async(t,b,i,f)=>{if(f&&!accepted){accepted=true;throw new Error('timeout');}return good(t,b,i,f);});await r.start();await assert.rejects(r.stop(),/timeout/);assert.equal(store.chunks.size,1);await r.flush();assert.equal(r.sagaId,42);assert.equal(store.chunks.size,0);
});

test('denied microphone never creates an upload session',async()=>{
    let started=false;const {r}=fixture();r.startSession=async()=>{started=true;};r.mediaDevices={getUserMedia:async()=>{throw new Error('permission denied');}};await assert.rejects(r.start(),/permission denied/);assert.equal(started,false);assert.equal(r.active,false);
});

test('closing during permission request releases the late media stream',async()=>{
    const {r,tracks}=fixture();let grant;r.mediaDevices={getUserMedia:()=>new Promise(resolve=>grant=resolve)};const start=r.start();r.dispose();grant({getTracks:()=>[tracks]});await assert.rejects(start,/fechada/);assert.equal(tracks.stopped,true);
});

test('storage failure stops capture; unsaved tail remains available for an explicit retry',async()=>{
    const {r,store,tracks}=fixture();const save=store.saveChunk.bind(store);let available=false;
    store.saveChunk=async(...args)=>{if(!available)throw new Error('quota exceeded');return save(...args);};
    await r.start();r.recorder.part('captured');await until(()=>r.state==='error'&&!r.stopPromise);assert.equal(tracks.stopped,true);assert.equal(r.recorder.state,'inactive');assert(r.emergencyChunks.length>0);
    available=true;await r.recover(r.pending.id);assert.equal(r.sagaId,42);assert.equal(store.chunks.size,0);
});
