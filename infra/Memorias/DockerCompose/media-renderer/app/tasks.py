import json
import traceback
import uuid

from app.celery_app import celery_app
from app.messaging import publish_render_result
from app.render import render_album


@celery_app.task(name="app.tasks.render_album")
def render_album_task(correlationId, payload):
    message_id = str(uuid.uuid4())

    try:
        request = json.loads(payload) if isinstance(payload, str) else payload
        manifest_storage_key = request.get("ManifestPath") or request.get("manifestPath")
        if not manifest_storage_key:
            raise ValueError("ManifestPath e obrigatorio.")

        result = render_album(manifest_storage_key)
        response = {
            "messageId": message_id,
            "correlationId": str(correlationId),
            "status": "media.album.render.completed",
            "result": result,
            "error": None,
        }
    except Exception as exception:
        response = {
            "messageId": message_id,
            "correlationId": str(correlationId),
            "status": "media.album.render.failed",
            "result": None,
            "error": {
                "type": type(exception).__name__,
                "message": str(exception),
                "details": traceback.format_exc(limit=8),
            },
        }

    publish_render_result(response)
    return response
