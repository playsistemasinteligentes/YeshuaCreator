"""Explicit administration of the Memorias integration, not environment secrets."""
import argparse
import base64
import getpass
import os
from pathlib import Path
import sys
import uuid

sys.path.insert(0, str(Path(__file__).resolve().parents[2] / "private"))
from credentials import ConfigurationError, read_json, write_new_json


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--file", default="/root/YeshuaPrivate/production/apps/Memorias/integracoes/youtube/bootstrap.json")
    args = parser.parse_args()
    path = Path(args.file).absolute()
    try:
        config = read_json(path) if path.exists() else {}
        client_id = input("Client ID OAuth: ").strip()
        client_secret = getpass.getpass("Client Secret OAuth: ")
        key = config.get("EncryptionKey") or getpass.getpass("Chave de protecao existente (base64 de 32 bytes): ")
        if not client_id or not client_secret or len(base64.b64decode(key, validate=True)) != 32:
            raise ConfigurationError("Client ID/Secret e chave base64 valida de 32 bytes sao obrigatorios.")
        config.update(ClientId=client_id, ClientSecret=client_secret, EncryptionKey=key)
        temporary = path.with_name(path.name + ".new-" + uuid.uuid4().hex)
        try:
            write_new_json(temporary, config)
            os.replace(temporary, path)
        finally:
            temporary.unlink(missing_ok=True)
        print("Integracao Memorias salva em area privada. Nenhuma chave foi gerada e nenhum cofre foi alterado.")
        return 0
    except (ConfigurationError, OSError, ValueError):
        print("Configuracao nao atualizada. Confira campos e permissoes; conteudo omitido.", file=sys.stderr)
        return 1


if __name__ == "__main__":
    sys.exit(main())
