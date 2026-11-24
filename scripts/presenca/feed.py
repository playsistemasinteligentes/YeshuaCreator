"""Durable source adapter. It runs independently from issue/PR/release/deploy completion.
No raw issue body, PR title, credentials or internal metadata enters the public contract.
The same transport can simulate an independent Academia producer during development.
"""
import argparse
import hashlib
import hmac
import importlib.util
import json
import os
from pathlib import Path
import re
import time
import urllib.request
import urllib.parse
import urllib.error


def public_hash(content):
    fields = ['presenca.public.v1', content['Manchete'], content['Corpo'], str(len(content['Fontes'])), *content['Fontes'],
              content['ClassificacaoPrincipal'], str(len(content['ClassificacoesSecundarias'])), *content['ClassificacoesSecundarias'],
              str(len(content['Tags'])), *content['Tags'], str(len(content['Materiais']))]
    for m in content['Materiais']:
        fields.extend([m['StorageKey'], m['Hash'], str(m['Tamanho']), m['Tipo'], m['Autor'], m['Licenca'], m['TextoAlternativo']])
    fields.append(content['AutorPublico'])
    return hashlib.sha256(''.join(str(len(f.encode('utf-8'))) + ':' + f for f in fields).encode('utf-8')).hexdigest().upper()


def factory_input(repository, identity, event):
    if not re.fullmatch(r'[A-Za-z0-9_.-]+/[A-Za-z0-9_.-]+', repository) or len(repository) > 120:
        raise ValueError('Repository invalid.')
    kind, action, number, revision = (event[k] for k in ('kind', 'action', 'id', 'revision'))
    if kind not in ('issue', 'pull_request', 'release', 'deploy') or action not in ('opened', 'updated', 'closed', 'merged', 'published', 'completed'):
        raise ValueError('Movement type invalid.')
    if type(number) is not int or number < 1 or not re.fullmatch(r'[A-Za-z0-9_.-]{1,80}', str(revision)):
        raise ValueError('Movement identity invalid.')
    resource = {'issue': 'issues', 'pull_request': 'pull', 'release': 'releases', 'deploy': 'deployments'}[kind]
    reference = event.get('url')
    if reference is None and kind in ('issue', 'pull_request'):
        reference = f'https://github.com/{repository}/{resource}/{number}'
    if not isinstance(reference, str):
        raise ValueError('A verified public source URL is required for release/deploy.')
    parsed = urllib.parse.urlsplit(reference)
    allowed_reference = (parsed.netloc == 'github.com' and parsed.path.startswith('/' + repository + '/')) or (kind == 'deploy' and parsed.netloc == 'api.github.com' and parsed.path == f'/repos/{repository}/deployments/{number}')
    if parsed.scheme != 'https' or not allowed_reference or parsed.query or parsed.fragment:
        raise ValueError('Public source URL does not belong to the explicit repository.')
    content = {'Manchete': f'{kind} {action} - {repository}',
               'Corpo': f'Um movimento publico autorizado ({kind}/{action}) foi recebido. Revisar o fato e suas fontes antes de publicar.',
               'Fontes': [reference], 'ClassificacaoPrincipal': 'Fabrica', 'ClassificacoesSecundarias': [], 'Tags': [kind], 'Materiais': [], 'AutorPublico': 'Play Sistemas'}
    movement = f'{repository}:{kind}:{number}:{action}:{revision}'
    if len(movement) > 120:
        movement = kind + ':' + hashlib.sha256(movement.encode()).hexdigest().upper()
    return {'IdentidadeId': identity, 'Produtor': repository, 'MovimentoId': movement,
            'Referencia': reference, 'Revisao': 1, 'Tipo': kind, 'AprovadaNaOrigem': False, 'Conteudo': content, 'Hash': public_hash(content)}


def academia_input(identity, producer, reference, lesson, revision, content, approved):
    if not approved or type(revision) is not int or revision < 1:
        raise ValueError('An approved educational version is required.')
    # Deliberate public allowlist: students/enrolment/private assessments never enter the contract.
    allowed = ('Manchete', 'Corpo', 'Fontes', 'ClassificacaoPrincipal', 'ClassificacoesSecundarias', 'Tags', 'Materiais', 'AutorPublico')
    public = {k: content[k] for k in allowed}
    for field in ('Manchete', 'Corpo', 'ClassificacaoPrincipal', 'AutorPublico'):
        public[field] = public[field].strip()
    public['Materiais'] = [{k: m[k] for k in ('StorageKey', 'Hash', 'Tamanho', 'Tipo', 'Autor', 'Licenca', 'TextoAlternativo')} for m in public['Materiais']]
    return {'IdentidadeId': identity, 'Produtor': producer, 'MovimentoId': lesson, 'Referencia': reference,
            'Revisao': revision, 'Tipo': 'aula', 'AprovadaNaOrigem': True, 'Conteudo': public, 'Hash': public_hash(public)}


def enqueue(spool, tenant, source, payload):
    if type(tenant) is not int or tenant <= 0 or source not in ('Fabrica', 'Academia') or not re.fullmatch(r'[A-Fa-f0-9]{64}', payload['IdentidadeId']):
        raise ValueError('Explicit tenant, source and publisher are required.')
    contract = 'MovimentoFabricaDisponivel.v1' if source == 'Fabrica' else 'SolicitacaoPublicacaoEducacional.v1'
    logical = json.dumps([tenant, source, payload['IdentidadeId'], payload['Produtor'], payload['MovimentoId'], payload['Revisao']], ensure_ascii=False, separators=(',', ':'))
    message = hashlib.sha256(logical.encode()).hexdigest().upper()
    body = json.dumps({'TenantId': tenant, 'MessageId': message, 'Type': contract, 'EntityType': 'OrigemEditorial',
                       'EntityId': payload['MovimentoId'], 'CorrelationId': '', 'Payload': json.dumps(payload, ensure_ascii=False, separators=(',', ':')),
                       'Source': source, 'Transport': 'YeshuaApi'}, ensure_ascii=False, separators=(',', ':'))
    spool = Path(spool); spool.mkdir(parents=True, exist_ok=True)
    for suffix in ('.pending', '.sent'):
        existing = spool / (message + suffix)
        if existing.exists():
            if existing.read_text() != body:
                raise ValueError('Conflicting input for the same movement/version.')
            return message
    target = spool / (message + '.pending')
    # Exclusive creation preserves another producer's work. A partial file is never sent.
    temporary = spool / (message + '.' + os.urandom(8).hex() + '.tmp')
    try:
        with temporary.open('x') as output:
            output.write(body); output.flush(); os.fsync(output.fileno())
        try:
            os.link(temporary, target)
        except FileExistsError:
            if target.read_text() != body:
                raise ValueError('Conflicting movement.')
    finally:
        temporary.unlink(missing_ok=True)
    return message


def deliver(spool, endpoint, shared_key):
    parsed = urllib.parse.urlsplit(endpoint)
    if (parsed.scheme != 'https' or not parsed.hostname or parsed.username or parsed.password
            or parsed.query or parsed.fragment or parsed.path != '/yapi/Presenca/Inbox/YeshuaModuleEvent'
            or len(shared_key.encode()) < 32):
        raise ValueError('An explicit HTTPS ingress and module signing key are required.')
    for path in sorted(Path(spool).glob('*.pending')):
        state_path = path.with_suffix('.retry')
        state = json.loads(state_path.read_text()) if state_path.exists() else {'attempt': 0, 'next': 0}
        if state['next'] > time.time():
            continue
        body = path.read_text(); envelope = json.loads(body)
        timestamp = str(int(time.time()))
        canonical = '\n'.join(['POST', parsed.path + ('?' + parsed.query if parsed.query else ''), envelope['Source'], timestamp, envelope['MessageId'], hashlib.sha256(body.encode()).hexdigest().upper()])
        signature = hmac.new(shared_key.encode(), canonical.encode(), hashlib.sha256).hexdigest().upper()
        request = urllib.request.Request(endpoint, data=body.encode(), headers={'Content-Type': 'application/json',
            'X-Yeshua-Source-Module': envelope['Source'], 'X-Yeshua-Message-Id': envelope['MessageId'], 'X-Yeshua-Timestamp': timestamp, 'X-Yeshua-Signature': signature}, method='POST')
        try:
            # Redirects would change the signed path and must not forward the envelope to another host.
            class NoRedirect(urllib.request.HTTPRedirectHandler):
                def redirect_request(self, req, fp, code, msg, headers, newurl):
                    return None
            with urllib.request.build_opener(NoRedirect).open(request, timeout=30) as response:
                if not 200 <= response.status < 300:
                    raise ValueError('Ingress not accepted.')
            os.replace(path, path.with_suffix('.sent')); state_path.unlink(missing_ok=True)
        except (urllib.error.URLError, TimeoutError, OSError) as error:
            # Inbox deduplication makes transport replay safe. Never remove unconfirmed source work.
            state['attempt'] += 1
            delay = min(3600, 2 ** min(state['attempt'], 12))
            if isinstance(error, urllib.error.HTTPError) and error.headers:
                retry_after = error.headers.get('Retry-After', '')
                if retry_after.isdigit():
                    delay = max(delay, min(86400, int(retry_after)))
            state['next'] = time.time() + delay
            temporary = state_path.with_suffix('.retry.tmp'); temporary.write_text(json.dumps(state)); os.replace(temporary, state_path)


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('action', choices=['fabrica', 'academia', 'deliver'])
    parser.add_argument('--spool', required=True); parser.add_argument('--input'); parser.add_argument('--tenant', type=int)
    parser.add_argument('--identity'); parser.add_argument('--repository'); parser.add_argument('--credentials')
    args = parser.parse_args()
    if args.action == 'deliver':
        # Reuse the unified private-file validation. No secondary credential file or provider.
        spec = importlib.util.spec_from_file_location('yeshua_credentials', Path(__file__).resolve().parents[2] / 'infra/private/credentials.py')
        module = importlib.util.module_from_spec(spec); spec.loader.exec_module(module)
        document = module.read_json(module.validate_access(args.credentials))
        config = document.get('Apps', {}).get('Presenca', {})
        deliver(args.spool, config['IngressUrl'], document['Shared']['ModuleAuthentication']['SharedKey'])
    else:
        data = json.loads(Path(args.input).read_text())
        if args.action == 'fabrica':
            payload = factory_input(args.repository, args.identity, data); source = 'Fabrica'
        else:
            payload = academia_input(args.identity, data['Produtor'], data['Referencia'], data['MovimentoId'], data['Revisao'], data['Conteudo'], data['AprovadaNaOrigem']); source = 'Academia'
        print(enqueue(args.spool, args.tenant, source, payload))

if __name__ == '__main__':
    main()
