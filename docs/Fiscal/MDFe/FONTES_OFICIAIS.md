# MDF-e - Fontes Oficiais

Pesquisa inicial consolidada em 2026-08-28.

Este diretorio guarda a base oficial usada para desenhar o modulo Fiscal.MDFe
no Yeshua. Toda regra fiscal, endpoint SEFAZ, assinatura, schema, evento ou
DAMDFE deve partir do Portal MDF-e/SVRS e dos documentos oficiais vigentes.

## Manuais Oficiais Identificados

O Portal MDF-e/SVRS lista como manuais de referencia:

- MOC MDFe 3.00b Visao Geral.
- MOC MDFe 3.00b Anexo I - Leiaute e Regras de Validacao.
- MOC MDFe 3.00b Anexo II - DAMDFE.

Links oficiais:

- Portal MDF-e - Home: https://dfe-portal.svrs.rs.gov.br/Mdfe
- Portal MDF-e - Sobre: https://dfe-portal.svrs.rs.gov.br/Mdfe/Sobre
- Portal MDF-e - Documentos: https://dfe-portal.svrs.rs.gov.br/Mdfe/Documentos
- Portal MDF-e - Servicos Web: https://dfe-portal.svrs.rs.gov.br/Mdfe/Servicos
- Portal MDF-e - Legislacao: https://dfe-portal.svrs.rs.gov.br/Mdfe/Legislacao
- Portal MDF-e - QR Code: https://dfe-portal.svrs.rs.gov.br/mdfe/qrCode

Documentos de trabalho:

- [MDFE_EMISSAO_CONTEXTO.md](MDFE_EMISSAO_CONTEXTO.md)
- [MDFE_MODULARIZACAO.md](MDFE_MODULARIZACAO.md)
- [MDFE_FUNCOES_OFICIAIS.md](MDFE_FUNCOES_OFICIAIS.md)
- [MDFE_PLANO_DE_PESQUISA.md](MDFE_PLANO_DE_PESQUISA.md)
- [MDFE_DOSSIE_ASSUNTOS.md](MDFE_DOSSIE_ASSUNTOS.md)
- [MDFE_BACKLOG_IMPLEMENTACAO.md](MDFE_BACKLOG_IMPLEMENTACAO.md)
- [REFERENCIAS_CODIGO_ABERTO.md](REFERENCIAS_CODIGO_ABERTO.md)

## Referencias Tecnicas Nao Oficiais

As referencias open-source ajudam a estudar implementacao, transporte SOAP,
assinatura, parser, organizacao de codigo e exemplos. Elas nao substituem MOC,
schemas, WSDLs, notas tecnicas ou paginas oficiais.

Catalogo atual:

- DFe.NET / ZeusAutomacao, snapshot local em
  `C:\Users\AngeloRicardoFontana\Documents\Yeshua\ReferenciasOpenSource\DFe.NET`.
- Unimake.DFe, snapshot local em
  `C:\Users\AngeloRicardoFontana\Documents\Yeshua\ReferenciasOpenSource\Unimake.DFe`.

O catalogo [REFERENCIAS_CODIGO_ABERTO.md](REFERENCIAS_CODIGO_ABERTO.md)
registra o que ja foi encontrado, o que ainda precisa ser baixado e quais
partes podem inspirar o desenho do Fiscal.MDFe sem virar regra fiscal oficial.

## Pacotes De Schema Acompanhar

Na consulta de 2026-08-28, o Portal MDF-e/SVRS listava como referencias:

- Schemas NT 2025.001 v 1.04, publicado em 25/04/2026.
- Schemas NT 2024.002 v1.01, publicado em 16/08/2024.
- Schemas NT 2024.001 v1.02, publicado em 12/03/2024.
- Schemas NT 2023.002 - Integracao InfraSA, publicado em 11/08/2023.
- Schemas da versao 3.00b do MDFe, publicado em 12/12/2022.
- Schemas NT 2022.001 v1.03, publicado em 23/03/2022.
- NT 2015.002 - Distribuicao aos Atores v1.00b, publicado em 23/03/2016.

Pendencia: baixar e versionar o ZIP de schemas exato usado pelo modulo assim
que iniciarmos validacao XSD real para emissao, evento ou consulta.

## Notas Tecnicas E Informes Relevantes

- NT 2026.001: CIOT obrigatorio em prestacoes rodoviarias por conta de terceiros
  e mediante remuneracao, conforme Ajuste SINIEF 03/2026.
- NT 2025.001: ajustes de leiaute e regras de validacao do MDF-e.
- NT DFe Conjunta CNPJ Alfanumerico v1.00: impacto transversal em DFe,
  incluindo MDF-e.
- NT 2024.002: alteracoes no MDF-e para suportar CT-e Simplificado.
- NT 2024.001: qualidade da informacao, encerramento pelo transportador,
  limite de documentos originarios por municipio de descarregamento e excecoes
  ANTT/BPe.
- NT 2023.002: integracao InfraSA no retorno de consulta situacao.
- NT 2023.001: deixa de executar a rejeicao 203 no evento de encerramento e na
  consulta de MDF-e nao encerrados.
- NT 2022.002: PAA para MDF-e.
- NT 2022.001: contrato, pagamento, confirmacao de servico e alteracao de
  pagamento.
- NT 2020.001: MDF-e Integrado.
- NT 2020.002: Nota Fiscal Facil.
- NT 2015.002: distribuicao aos atores interessados.

## Tabelas Oficiais Acompanhar

- Tabela de Codigo de Classificacao Tributaria da Reforma Tributaria.
- Tabela de Codigos de Credito Presumido.
- Tabela de Meios de Pagamento.
- Relacao de CNPJ de fornecedores de vale pedagio da ANTT.
- Informes tecnicos sobre meios de pagamento e split.

## Observacoes De Uso

- O modulo Fiscal.MDFe deve registrar qual pacote de schema e qual nota tecnica
  foram usados para validar e transmitir cada documento/evento.
- URLs SEFAZ devem ser configuracao por ambiente e servico. No MDF-e atual,
  a relacao oficial usa SVRS como ambiente nacional.
- O primeiro recorte do Yeshua e encerramento de MDF-e ja autorizado, nao
  emissao completa.
- O playground `tools/Yeshua.Engine.Playground` contem uma prova isolada de
  encerramento por `MDFeRecepcaoEvento`.
