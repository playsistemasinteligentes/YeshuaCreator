import os
import torch
from threading import Lock
from transformers import AutoTokenizer, AutoModelForCausalLM, pipeline

# ── Configuração ──────────────────────────────────────────────
MODEL_ID = os.environ.get("SUMMARIZER_MODEL", "Qwen/Qwen2.5-0.5B-Instruct")

# "cpu" | "cuda" | "mps" — troca de CPU para GPU só mudando env var
DEVICE = os.environ.get("SUMMARIZER_DEVICE", "cpu")

_pipeline = None
_lock = Lock()


# ── Carregamento lazy (singleton) ────────────────────────────
def _get_pipeline():
    global _pipeline

    if _pipeline is None:
        with _lock:
            if _pipeline is None:
                print(f"[Summarizer] Carregando modelo {MODEL_ID} em {DEVICE}...")

                tokenizer = AutoTokenizer.from_pretrained(MODEL_ID)

                # CPU: float32 | GPU: float16 automaticamente
                dtype = torch.float16 if DEVICE != "cpu" else torch.float32

                model = AutoModelForCausalLM.from_pretrained(
                    MODEL_ID,
                    torch_dtype=dtype,
                    device_map=DEVICE,
                )

                _pipeline = pipeline(
                    "text-generation",
                    model=model,
                    tokenizer=tokenizer,
                )

                print(f"[Summarizer] Modelo carregado.")

    return _pipeline


# ── Prompts clínicos ─────────────────────────────────────────
PROMPT_PRONTUARIO = """Você é um assistente clínico especializado em psicologia.
Com base na transcrição da sessão abaixo, gere um PRONTUÁRIO CLÍNICO resumido.

Regras:
- Linguagem clínica, objetiva e neutra
- Não inclua interpretações subjetivas ou opiniões
- Foque apenas em: queixa principal, relato do paciente, conduta/encaminhamento
- Máximo de 200 palavras
- Formato:
  Queixa principal: ...
  Relato da sessão: ...
  Conduta: ...

Transcrição:
{text}

Prontuário:"""

PROMPT_RELATORIO = """Você é um assistente clínico especializado em psicologia.
Com base na transcrição da sessão abaixo, gere um RELATÓRIO CLÍNICO detalhado.

Regras:
- Linguagem clínica, porém mais descritiva e analítica
- Inclua observações sobre padrões emocionais, comportamentais e relacionais identificados
- Registre temas recorrentes, avanços e pontos de atenção
- Máximo de 500 palavras
- Formato:
  Resumo da sessão: ...
  Temas abordados: ...
  Observações clínicas: ...
  Padrões identificados: ...
  Pontos de atenção: ...
  Evolução/Avanços: ...

Transcrição:
{text}

Relatório:"""


# ── Geração ───────────────────────────────────────────────────
def _generate(prompt: str, max_new_tokens: int) -> str:
    pipe = _get_pipeline()

    output = pipe(
        prompt,
        max_new_tokens=max_new_tokens,
        max_length=None,
        do_sample=False,
        repetition_penalty=1.1,
        pad_token_id=pipe.tokenizer.eos_token_id,
    )

    generated = output[0]["generated_text"]

    # Remove o prompt do início — retorna só o que o modelo gerou
    return generated[len(prompt):].strip()


def gerar_prontuario(text: str) -> str:
    prompt = PROMPT_PRONTUARIO.format(text=text[:3000])
    return _generate(prompt, max_new_tokens=300)


def gerar_relatorio(text: str) -> str:
    prompt = PROMPT_RELATORIO.format(text=text[:3000])
    return _generate(prompt, max_new_tokens=700)