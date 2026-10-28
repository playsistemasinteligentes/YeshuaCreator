import test from 'node:test';
import assert from 'node:assert/strict';
import { readFile } from 'node:fs/promises';
const source=await readFile(new URL('../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/spa/scripts/components/recording/session-recorder.js',import.meta.url),'utf8');
const {SessionRecorder}=await import('data:text/javascript;base64,'+Buffer.from(source).toString('base64'));
const delay=ms=>new Promise(resolve=>setTimeout(resolve,ms));
class Store{
    rows=new Map();
    async put(value){await delay(5);this.rows.set(value.id,structuredClone(value));}
    async remove(id){this.rows.delete(id);}
    async all(){return [...this.rows.values()];}
}
class Recorder{
    static isTypeSupported(){return true;}
    state='inactive';
    start(){this.state='recording';}
    pause(){this.state='paused';}
    resume(){this.state='recording';}
    part(text){this.ondataavailable({data:new Blob([text])});}
    stop(){this.state='inactive';this.part('final');this.onstop();}
}
function fixture(sendChunk=async()=>({success:true,isFinalized:true,sagaId:42}),store=new Store()){
    const tracks={stopped:false,stop(){this.stopped=true;}};
    const r=new SessionRecorder({actor:'1:7',sessionId:12,startSession:async()=> 'private-upload-token',sendChunk,store,mediaDevices:{getUserMedia:async()=>({getTracks:()=>[tracks]})},Recorder});
    return {r,store,tracks};
}
test('stop waits for final dataavailable persistence and final server confirmation',async()=>{
    const calls=[];const {r,store,tracks}=fixture(async(token,blob,index,final)=>{calls.push({text:await blob.text(),index,final});return {success:true,isFinalized:final,sagaId:final?42:0};});
    await r.start();r.recorder.part('first');await r.stop();
    assert.deepEqual(calls,[{text:'first',index:0,final:false},{text:'final',index:1,final:true}]);
    assert.equal(r.sagaId,42);assert.equal(r.state,'completed');assert.equal(tracks.stopped,true);assert.equal((await store.all()).length,0);
});
test('failed final send preserves every byte and recovery is actor and session bound',async()=>{
    const {r,store}=fixture(async()=>{throw new Error('offline');});await r.start();r.recorder.part('first');await assert.rejects(r.stop(),/offline/);
    assert.equal((await store.all()).length,1);assert.equal(await (await r.downloadPending()).text(),'firstfinal');
    const other=fixture(undefined,store).r;other.actor='2:7';assert.equal((await other.recoverable()).length,0);other.actor='1:7';other.sessionId=13;assert.equal((await other.recoverable()).length,0);
    const recovered=fixture(async(token,blob,index,final)=>({success:true,isFinalized:final,sagaId:final?55:0}),store).r;
    await recovered.recover((await recovered.recoverable())[0].id);assert.equal(recovered.sagaId,55);assert.equal((await store.all()).length,0);
});
test('an HTTP success without final saga acknowledgement does not discard the audio',async()=>{
    const {r,store}=fixture(async()=>({success:true,isFinalized:false,sagaId:0}));await r.start();await assert.rejects(r.stop(),/não confirmou/);assert.equal((await store.all()).length,1);
});
test('an ambiguous timeout can replay a server-finalized upload idempotently',async()=>{
    let online=false;const {r,store}=fixture(async()=>{if(!online)throw new Error('timeout');return {success:true,isFinalized:true,sagaId:72};});
    await r.start();r.recorder.part('first');await assert.rejects(r.stop());online=true;await r.flush();assert.equal(r.sagaId,72);assert.equal((await store.all()).length,0);
});
test('pause and resume use the actual capture device and stop releases its tracks',async()=>{
    const {r,tracks}=fixture();await r.start();r.pause();assert.equal(r.recorder.state,'paused');assert.equal(r.state,'paused');r.resume();assert.equal(r.recorder.state,'recording');await r.stop();assert.equal(tracks.stopped,true);
});
test('denied microphone permission never creates an upload session',async()=>{
    let started=false;const {r}=fixture();r.startSession=async()=>{started=true;};r.mediaDevices={getUserMedia:async()=>{throw new Error('permission denied');}};await assert.rejects(r.start(),/permission denied/);assert.equal(started,false);assert.equal(r.active,false);
});
test('closing the page while permission is pending releases a late media stream',async()=>{
    const {r,tracks}=fixture();let grant;r.mediaDevices={getUserMedia:()=>new Promise(resolve=>grant=resolve)};const start=r.start();r.dispose();grant({getTracks:()=>[tracks]});await assert.rejects(start,/fechada/);assert.equal(tracks.stopped,true);
});
test('a local storage failure stops the physical capture and retains bytes for download',async()=>{
    const {r,tracks}=fixture();let writes=0;const put=r.store.put.bind(r.store);
    r.store.put=async value=>{if(++writes>1)throw new Error('quota exceeded');return put(value);};
    await r.start();r.recorder.part('captured');await delay(40);
    assert.equal(tracks.stopped,true);assert.equal(r.recorder.state,'inactive');assert.equal(r.state,'error');
    assert((await (await r.downloadPending()).text()).includes('captured'));
});
