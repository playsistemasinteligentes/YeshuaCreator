import argparse
import base64
from concurrent.futures import ThreadPoolExecutor
import json
import secrets
import time
from urllib.error import HTTPError
from urllib.request import Request, urlopen
import uuid


def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--base-url", required=True)
    args = parser.parse_args()
    base = args.base_url.rstrip("/")
    checks = []

    def call(path, body=None, token=None):
        headers = {"Content-Type": "application/json"}
        if token:
            headers["Authorization"] = "Bearer " + token
        request = Request(base + path, data=json.dumps(body).encode() if body is not None else None, headers=headers)
        try:
            with urlopen(request, timeout=90) as response:
                text = response.read().decode('utf-8-sig')
                return response.status, json.loads(text) if text else None, dict(response.headers)
        except HTTPError as error:
            text = error.read().decode()
            try:
                payload = json.loads(text)
            except json.JSONDecodeError:
                payload = {"status": error.code}
            return error.code, payload, dict(error.headers)

    def expect(name, condition):
        if not condition:
            raise AssertionError(name)
        checks.append(name)

    def account():
        suffix = uuid.uuid4().hex[:12]
        password = secrets.token_urlsafe(24)
        email = "financeiro-" + suffix + "@example.invalid"
        status, created, _ = call(central_api + "/Y/ContascreateContaUseCase", {
            "cpfCnpj": str(secrets.randbelow(10**13)).zfill(14), "nome": "Teste financeiro " + suffix,
            "email": email, "phone": "11999999999", "password": password, "confirmpassword": password})
        expect("create-isolated-account", status == 200)
        status, login, _ = call(central_api + "/login", {"login": email, "password": password})
        expect("login", status == 200 and bool(login.get("token")))
        return login["token"], created.get("tenantId", created.get("TenantId"))

    def finance(command, body, token):
        return call(central_api + "/Central/Financeiro" + command + "UseCase", body, token)

    status, catalog, _ = call('/applications.json')
    expect('read-live-application-catalog', status == 200)
    central_api = next(application['apiBasePath'] for application in catalog if application['application'] == 'Central')
    clinic_api = next(application['apiBasePath'] for application in catalog if application['application'] == 'Clinica')
    owner, tenant_id = account()
    other, other_tenant_id = account()
    status, initial, _ = finance("ConsultarFinanceiro", {}, owner)
    expect("sandbox-explicitly-enabled", status == 200 and initial["simulacao"])
    expect("three-dsl-compatible-offers", len(initial["ofertas"]) == 3)
    expect("no-initial-credit", initial["saldo"] == 0)
    expect("anonymous-finance-rejected", finance("ConsultarFinanceiro", {}, None)[0] in (401, 403))
    expect("clinic-requires-purchased-period", call(clinic_api + "/getMenu", token=owner)[0] == 403)

    charge_request = {"requestId": str(uuid.uuid4()), "creditos": 500}
    status, charged, _ = finance("CriarRecarga", charge_request, owner)
    expect("creating-charge-does-not-credit-wallet", status == 200 and charged["saldo"] == 0)
    charge_id = charged["cobrancaId"]
    expect("charge-idempotency", finance("CriarRecarga", charge_request, owner)[1]["cobrancaId"] == charge_id)
    expect("charge-request-body-conflict", finance("CriarRecarga", {**charge_request, "creditos": 100}, owner)[0] == 400)
    expect("cross-tenant-payment-rejected", finance("ConfirmarPagamentoTeste", {"cobrancaId": charge_id}, other)[0] == 400)
    with ThreadPoolExecutor(max_workers=6) as pool:
        confirmations = list(pool.map(lambda _: finance("ConfirmarPagamentoTeste", {"cobrancaId": charge_id}, owner)[0], range(12)))
    expect("concurrent-confirmations-accepted", all(status == 200 for status in confirmations))
    snapshot = finance("ConsultarFinanceiro", {}, owner)[1]
    expect("payment-credits-exactly-once", snapshot["saldo"] == 500 and len(snapshot["movimentos"]) == 1)

    purchase = {"requestId": str(uuid.uuid4()), "oferta": "clinica-periodo", "quantidade": 1}
    status, contracted, _ = finance("ContratarUso", purchase, owner)
    expect("period-purchase", status == 200 and contracted["saldo"] == 400)
    expect("purchase-idempotency", finance("ContratarUso", purchase, owner)[1]["saldo"] == 400)
    expect("purchase-request-body-conflict", finance("ContratarUso", {**purchase, "quantidade": 2}, owner)[0] == 400)
    expect("insufficient-credit-blocks-purchase", finance("ContratarUso", {"requestId": str(uuid.uuid4()), "oferta": "clinica-periodo", "quantidade": 36}, owner)[0] == 400)
    owner = contracted["token"]
    central_claims = json.loads(base64.urlsafe_b64decode(owner.split(".")[1] + "=="))
    expect("period-in-signed-token", int(central_claims["usageUntil.clinica.access"]) > time.time())
    status, _, headers = call(clinic_api + "/getMenu", token=owner)
    application_token = next((value for key, value in headers.items() if key.lower() == "x-yeshua-application-token"), None)
    expect("paid-clinic-entry", status == 200 and bool(application_token))
    application_claims = json.loads(base64.urlsafe_b64decode(application_token.split(".")[1] + "=="))
    expect("application-token-does-not-extend-session", application_claims["exp"] <= central_claims["exp"])
    expect("rights-survive-application-entry", application_claims["usageRights"] == central_claims["usageRights"])
    expect("renewal-from-application-token", finance("AtualizarAcesso", {}, application_token)[0] == 200)

    def buy(_):
        return finance("ContratarUso", {"requestId": str(uuid.uuid4()), "oferta": "transcricao-creditos", "quantidade": 1}, owner)[0]
    with ThreadPoolExecutor(max_workers=6) as pool:
        results = list(pool.map(buy, range(25)))
    expect("concurrent-purchases-exhaust-only-available-credit", results.count(200) == 20 and results.count(400) == 5)
    final = finance("ConsultarFinanceiro", {}, owner)[1]
    expect("wallet-never-negative", final["saldo"] == 0)
    expect("purchased-quantity-preserved", next(right for right in final["contratacoes"] if right["recurso"] == "clinica.transcription")["unidadesContratadas"] == 200)
    expect("all-money-movements-accounted", len(final["movimentos"]) == 22)
    other_state = finance("ConsultarFinanceiro", {"tenantId": tenant_id}, other)[1]
    expect("tenant-isolation", other_state["saldo"] == 0 and not other_state["contratacoes"] and not other_state["movimentos"])
    expect("internal-wallet-crud-not-exposed", call(central_api + "/CarteiraCredito/PostCarteiraCredito", {}, owner)[0] == 404)
    print(json.dumps({"passed": True, "tenantIds": [tenant_id, other_tenant_id], "checks": checks,
                      "walletBalance": final["saldo"], "concurrentPurchasesAccepted": results.count(200)}, ensure_ascii=True))


if __name__ == "__main__":
    main()
