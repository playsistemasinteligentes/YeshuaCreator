"""One bounded scheduled invocation; systemd owns time, isolation and process lifetime.
Collection and delivery use separate timers/locks. No credentials or public input
are printed. Nothing is installed or enabled by invoking this module's tests.
"""
import argparse
from contextlib import contextmanager
import fcntl
import json
from pathlib import Path
import sys
# Explicit trusted source path also works with Python isolated mode (-I).
sys.path.insert(0, str(Path(__file__).resolve().parent))
import feed
import factory


@contextmanager
def lock(spool, action):
    spool.mkdir(parents=True, exist_ok=True, mode=0o700)
    with (spool / ('.' + action + '.lock')).open('a') as handle:
        try:
            fcntl.flock(handle, fcntl.LOCK_EX | fcntl.LOCK_NB)
        except BlockingIOError:
            yield False
            return
        try:
            yield True
        finally:
            fcntl.flock(handle, fcntl.LOCK_UN)


def run(action, credentials, spool, load=feed.private_document):
    if action not in ('collect', 'deliver'):
        raise ValueError('Invalid scheduled action.')
    spool = Path(spool)
    if not spool.is_absolute() or spool.is_symlink():
        raise ValueError('An explicit absolute persistent spool is required.')
    document = load(credentials)
    config = document.get('Apps', {}).get('Presenca', {})
    profile = config.get('Factory', {})
    # Scheduler activation is independent from application/channel configuration.
    if profile.get('Enabled') is not True:
        return {'action':action,'status':'disabled'}
    tenant, identity, repository, pages = (profile.get(k) for k in ('TenantId','IdentidadeId','Repository','Pages'))
    if (type(tenant) is not int or tenant <= 0 or not isinstance(identity,str)
            or not feed.re.fullmatch(r'[A-Fa-f0-9]{64}',identity)
            or not feed.valid_repository(repository) or type(pages) is not int or not 1<=pages<=10):
        raise ValueError('Explicit bounded factory binding is required.')
    with lock(spool,action) as acquired:
        if not acquired:
            return {'action':action,'status':'already-running'}
        if action == 'collect':
            result = factory.collect(spool,tenant,identity,repository,pages=pages)
        else:
            # Delivery does not query GitHub: source outages cannot starve pending work.
            feed.deliver(spool,config['IngressUrl'],document['Shared']['ModuleAuthentication']['SharedKey'])
            result = {'pending':sum(1 for _ in spool.glob('*.pending')),
                      'retrying':sum(1 for _ in spool.glob('*.retry'))}
        return {'action':action,'status':'completed',**result}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('action',choices=['collect','deliver'])
    parser.add_argument('--credentials',required=True)
    parser.add_argument('--spool',required=True)
    args = parser.parse_args()
    try:
        print(json.dumps(run(args.action,args.credentials,args.spool)))
        return 0
    except Exception:
        print(json.dumps({'action':args.action,'status':'failed','code':'PRESENCA_FACTORY_JOB_FAILED'}),file=sys.stderr)
        return 1

if __name__ == '__main__':
    sys.exit(main())
