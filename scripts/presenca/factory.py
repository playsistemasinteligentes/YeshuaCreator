"""Read-only bridge from the factory's public GitHub records to the existing spool.
Run independently of task completion. Collection never contacts Presenca. A separate
feed.py deliver invocation drains confirmed, durable public envelopes.
This is a bounded snapshot collector, not a lossless GitHub audit stream.
"""
import argparse
import json
from pathlib import Path
import re
import urllib.request
import feed


def github_get(path):
    request = urllib.request.Request('https://api.github.com' + path,
        headers={'Accept': 'application/vnd.github+json', 'User-Agent': 'Yeshua-Presenca-Factory/1.0',
                 'X-GitHub-Api-Version': '2026-03-10'})
    class NoRedirect(urllib.request.HTTPRedirectHandler):
        def redirect_request(self, req, fp, code, msg, headers, newurl):
            return None
    with urllib.request.build_opener(NoRedirect).open(request, timeout=30) as response:
        # Bound memory; never persist the original response (titles, bodies, actors).
        raw = response.read(2_000_001)
        if len(raw) > 2_000_000:
            raise ValueError('Public factory response exceeds the collection limit.')
        return json.loads(raw)


def collect(spool, tenant, identity, repository, get=github_get, pages=1):
    if not re.fullmatch(r'[A-Za-z0-9_.-]+/[A-Za-z0-9_.-]+', repository) or len(repository) > 120:
        raise ValueError('Explicit repository invalid.')
    if type(pages) is not int or not 1 <= pages <= 10:
        raise ValueError('Collection page limit must be between 1 and 10.')
    root = '/repos/' + repository
    repo = get(root)
    if repo.get('private') is not False or repo.get('full_name', '').lower() != repository.lower():
        raise ValueError('Only the explicitly selected public repository may be collected.')
    collected = 0
    truncated = []
    for resource in ('issues', 'pulls', 'releases', 'deployments'):
        for page in range(1, pages + 1):
            query = '?per_page=100&page=' + str(page)
            if resource in ('issues', 'pulls'):
                query += '&state=all&sort=updated&direction=desc'
            rows = get(root + '/' + resource + query)
            if not isinstance(rows, list) or len(rows) > 100:
                raise ValueError('Invalid bounded GitHub page.')
            for row in rows:
                if resource == 'issues' and 'pull_request' in row:
                    continue  # Pulls are read separately with their own revision.
                if resource == 'releases' and (row.get('draft') is not False):
                    continue
                kind = {'issues':'issue', 'pulls':'pull_request', 'releases':'release', 'deployments':'deploy'}[resource]
                number = row.get('number') if resource in ('issues','pulls') else row.get('id')
                action = 'updated'
                stamp = row.get('updated_at')
                reference = row.get('html_url')
                if resource == 'pulls' and row.get('merged_at'):
                    action = 'merged'
                elif resource in ('issues','pulls') and row.get('state') == 'closed':
                    action = 'closed'
                elif resource == 'releases':
                    action = 'published'
                elif resource == 'deployments':
                    statuses = get(root + '/deployments/' + str(number) + '/statuses?per_page=1')
                    if not statuses or statuses[0].get('state') != 'success':
                        continue  # No claim of successful deploy based on creation alone.
                    stamp = statuses[0].get('updated_at') or statuses[0].get('created_at')
                    reference = 'https://api.github.com' + root + '/deployments/' + str(number)
                    action = 'completed'
                if not isinstance(stamp, str) or not stamp:
                    raise ValueError('Public factory revision missing.')
                # Stable bounded movement ID: source record + revision, never a title/body.
                revision = feed.hashlib.sha256(stamp.encode()).hexdigest()
                payload = feed.factory_input(repository, identity,
                    {'kind':kind,'action':action,'id':number,'revision':revision,'url':reference})
                feed.enqueue(spool, tenant, 'Fabrica', payload)
                collected += 1
            if len(rows) < 100:
                break
            if page == pages:
                truncated.append(resource)
    return {'observed':collected,'truncatedResources':truncated,'coverage':'public snapshots; intermediate changes between polls can be missed',
            'presencaContacted':False}


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--spool', required=True)
    parser.add_argument('--tenant', required=True, type=int)
    parser.add_argument('--identity', required=True)
    parser.add_argument('--repository', required=True)
    parser.add_argument('--pages', type=int, default=1)
    args = parser.parse_args()
    print(json.dumps(collect(args.spool,args.tenant,args.identity,args.repository,pages=args.pages)))

if __name__ == '__main__':
    main()
