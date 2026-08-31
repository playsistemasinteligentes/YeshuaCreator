# CT-e - Fontes Oficiais

Pesquisa inicial realizada em 2026-08-28.

Este diretorio guarda a base oficial usada para desenhar o modulo de emissao
de CT-e no Yeshua. Sempre que formos implementar regra fiscal, endpoint SEFAZ,
assinatura, schema ou DACTE, a fonte primaria deve ser o Portal CT-e.

## Manuais Baixados

Arquivos locais:

- [MOC_CTe_Visao_Geral_v4.00.pdf](oficial/MOC_CTe_Visao_Geral_v4.00.pdf)
- [MOC_CTe_Anexo_I_Leiaute_Regras_v4.00.pdf](oficial/MOC_CTe_Anexo_I_Leiaute_Regras_v4.00.pdf)
- [MOC_CTe_Anexo_II_DACTE_v4.00.pdf](oficial/MOC_CTe_Anexo_II_DACTE_v4.00.pdf)
- [NT_CTe_2026_002_v1.01.pdf](oficial/NT_CTe_2026_002_v1.01.pdf)
- [NT_CTe_2026_001_RTC_Vinculacao_Pagamento_v1.01.pdf](oficial/NT_CTe_2026_001_RTC_Vinculacao_Pagamento_v1.01.pdf)
- [NT_CTe_2025_001_RTC_v1.14b.pdf](oficial/NT_CTe_2025_001_RTC_v1.14b.pdf)

Documentos de trabalho:

- [CTE_EMISSAO_CONTEXTO.md](CTE_EMISSAO_CONTEXTO.md)
- [CTE_MODULARIZACAO.md](CTE_MODULARIZACAO.md)
- [CTE_FUNCOES_OFICIAIS.md](CTE_FUNCOES_OFICIAIS.md)
- [CTE_PLANO_DE_PESQUISA.md](CTE_PLANO_DE_PESQUISA.md)
- [CTE_DOSSIE_ASSUNTOS.md](CTE_DOSSIE_ASSUNTOS.md)
- [CTE_BACKLOG_IMPLEMENTACAO.md](CTE_BACKLOG_IMPLEMENTACAO.md)
- [REFERENCIAS_CODIGO_ABERTO.md](REFERENCIAS_CODIGO_ABERTO.md)

Links oficiais:

- Portal CT-e - Manuais: https://www.cte.fazenda.gov.br/portal/listaConteudo.aspx?tipoConteudo=YIi%2BH8VETH0%3D
- Portal CT-e - Esquemas XML: https://www.cte.fazenda.gov.br/portal/listaConteudo.aspx?tipoConteudo=0xlG1bdBass%3D
- Portal CT-e - Notas Tecnicas: https://www.cte.fazenda.gov.br/portal/listaConteudo.aspx?tipoConteudo=Y0nErnoZpsg%3D
- Portal CT-e - Relacao de Servicos Web: https://www.cte.fazenda.gov.br/portal/webServices.aspx?tipoConteudo=wpdBtfbTMrw%3D
- Portal CT-e Homologacao - Relacao de Servicos Web: https://hom.cte.fazenda.gov.br/portal/webServices.aspx?tipoConteudo=wpdBtfbTMrw%3D

## Pacotes De Schema Acompanhar

Na consulta de 2026-08-28, o Portal CT-e/SVRS listava como referencias
recentes:

- Schemas NT 2026.001 RTC Vinculacao Pagamento v1.01c correcao 2, publicado
  em 21/08/2026.
- Schemas NT 2026.002 correcao 2, publicado em 21/08/2026.
- Schemas XML CT-e - Pacote de Liberacao 4.00 ref. NT 2026.001 v.1.01 corrigido, publicado em 08/06/2026.
- Schemas XML CT-e - Pacote de Liberacao 4.00 ref. NT 2025.001 v.1.14, publicado em 07/04/2026.
- Schemas NT 2024.002 - CT-e Simplificado v1.05, publicado em 11/10/2024.
- Schemas CT-e 4.00, publicado em 28/04/2023.

Pendencia: baixar e versionar o ZIP de schemas exato usado pelo modulo assim
que iniciarmos a validacao XSD real.

## Observacoes De Uso

- Os PDFs neste diretorio sao referencia operacional, nao fonte gerada pela
  Engine.
- O modulo Fiscal.CTe deve registrar no banco qual versao de schema/NT foi
  usada para emitir, validar e consultar cada documento.
- Endpoints devem ser tratados como configuracao por UF, autorizador e ambiente.
  Nunca fixar URL SEFAZ dentro da regra de negocio.
- Projetos open-source sao referencias tecnicas auxiliares e ficam separados
  das fontes oficiais em [REFERENCIAS_CODIGO_ABERTO.md](REFERENCIAS_CODIGO_ABERTO.md).
