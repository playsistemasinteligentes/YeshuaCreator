import test from 'node:test';
import assert from 'node:assert/strict';
import { buildHelpPrompt } from '../../src/CQRS/Infrastructure/Yeshua.Central.CQRS.Infrastructure.Front/wwwroot/spa/scripts/help-prompt.js';

const context = () => ({ application:'APS.ADM', applicationTitle:'APS.ADM', title:'Planejamento de transporte', key:'planejamento-transporte', kind:'Página personalizada', tenantId:2, userId:7, origin:'https://playsis.com.br', path:'/spa/', route:'dashboard', timestampUtc:'2026-10-28T12:00:00.000Z', timeZone:'America/Sao_Paulo' });

test('help identifies the actual application, screen, tenant and investigation time', () => {
    const text = buildHelpPrompt(context());
    for (const value of ['APS.ADM','Planejamento de transporte','TenantID: 2','UserID: 7','2026-10-28T12:00:00.000Z','America/Sao_Paulo','Yeshua Inteligência Operacional','yeshua_health','yeshua_source_search']) assert(text.includes(value), value);
    assert(text.includes('[Escreva aqui')); assert(text.includes('não concede acesso administrativo'));
});

test('URL parameters and fragments never enter the copied location', () => {
    const text = buildHelpPrompt({ ...context(), path:'/spa/?token=SECRET_QUERY&patient=SECRET_PATIENT#SECRET_FRAGMENT', route:'dashboard?SECRET_ROUTE' });
    assert(text.includes('Ambiente acessado: https://playsis.com.br/spa/')); assert(!text.includes('SECRET_'));
});

test('context is an allowlist and excludes record contents, credentials and arbitrary payloads', () => {
    const text = buildHelpPrompt({ ...context(), token:'SECRET_TOKEN', password:'SECRET_PASSWORD', email:'SECRET_EMAIL', currentRecord:{Nome:'SECRET_NAME',Prontuario:'SECRET_NOTE'}, formValues:{key:'SECRET_KEY'}, error:'SECRET_ERROR' });
    assert(!text.includes('SECRET_'));
});

test('CRUD context includes technical entity, action and supported record identity only', () => {
    const text = buildHelpPrompt({ ...context(), kind:'Cadastro', title:'Profissional', entity:'Profissional', action:'Edit', recordId:12 });
    assert(text.includes('Entidade: Profissional')); assert(text.includes('Ação: Edição')); assert(text.includes('Identificador do registro: 12'));
    assert(!buildHelpPrompt({ ...context(), recordId:'person@example.test',tenantId:'SECRET_TENANT',userId:'SECRET_USER' }).includes('SECRET_'));
});

test('missing context remains usable without fabricating identities or API access', () => {
    const text = buildHelpPrompt({});
    assert(text.includes('TenantID: não identificado'));assert(text.includes('UserID: não identificado'));
    assert(text.includes('Se o conector não estiver disponível'));assert(text.includes('Não afirme ter consultado'));
});

test('navigation labels cannot introduce extra context lines', () => {
    const text = buildHelpPrompt({ ...context(), title:'Tela\nTexto adicional\r\nOutra linha' });
    assert(text.includes('Tela: Tela Texto adicional  Outra linha'));
    assert(!text.includes('\nTexto adicional'));
});
