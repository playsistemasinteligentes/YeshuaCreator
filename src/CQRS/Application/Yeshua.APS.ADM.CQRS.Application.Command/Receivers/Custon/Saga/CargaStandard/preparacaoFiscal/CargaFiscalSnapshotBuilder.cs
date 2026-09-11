// <yeshua>
// artifact: IA_DEV_CUSTOM
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// </yeshua>

using Dominio.Patterns.Saga;
using IRepository.Read;
using Repositorio.Outputs;
using System;
using System.Collections.Generic;

namespace Command.Receivers
{
    internal sealed class CargaFiscalSnapshotBuilder
    {
        private readonly ICargaReadRepository _cargaReadRepository;
        private readonly IVeiculoReadRepository _veiculoReadRepository;
        private readonly ITransportadoraReadRepository _transportadoraReadRepository;

        public CargaFiscalSnapshotBuilder(
            ICargaReadRepository cargaReadRepository,
            IVeiculoReadRepository veiculoReadRepository,
            ITransportadoraReadRepository transportadoraReadRepository)
        {
            _cargaReadRepository = cargaReadRepository;
            _veiculoReadRepository = veiculoReadRepository;
            _transportadoraReadRepository = transportadoraReadRepository;
        }

        public CargaProntaParaEmissaoFiscalV1 Build(SagaBase saga, SagaStepBase step)
        {
            var carga = FindCarga(saga.EntityId);

            var snapshot = new CargaProntaParaEmissaoFiscalV1
            {
                Origem = "APSADM",
                ModuloOrigem = "APSADM",
                SagaOrigem = "CargaStandard",
                StepOrigem = "publicarCargaProntaParaEmissaoFiscal",
                ModuloDestino = "Fiscal",
                SagaDestino = "EmissaoFiscalCargaStandard",
                VersaoContrato = 1,
                CargaId = saga.EntityId,
                SagaId = saga.Id,
                SagaCorrelationId = saga.CorrelationId,
                StepId = step.Id,
                StepKey = step.Key,
                StepCorrelationId = step.CorrelationId,
                GeradoEmUtc = DateTime.UtcNow,
                Carga = new CargaFiscalCargaSnapshot
                {
                    CargaId = saga.EntityId
                },
                Rota = new CargaFiscalRotaSnapshot(),
                Transporte = new CargaFiscalTransporteSnapshot(),
                PreferenciasFiscais = new CargaFiscalPreferenciasSnapshot(),
                DocumentosOriginarios = new List<CargaFiscalDocumentoOriginarioSnapshot>(),
                Pendencias = new List<CargaFiscalPendencia>()
            };

            FillCarga(snapshot, carga);
            FillTransporte(snapshot, carga);
            AddRequiredPendencies(snapshot);
            snapshot.ProntoParaPublicacao = snapshot.Pendencias.Count == 0;

            return snapshot;
        }

        public object BuildPreparationEvidence(SagaBase saga, SagaStepBase step)
        {
            var snapshot = Build(saga, step);

            return new
            {
                origem = snapshot.Origem,
                cargaId = snapshot.CargaId,
                contrato = "CargaProntaParaEmissaoFiscal.v1",
                prontoParaPublicacao = snapshot.ProntoParaPublicacao,
                pendencias = snapshot.Pendencias
            };
        }

        public object BuildBlockedPublicationEvidence(CargaProntaParaEmissaoFiscalV1 snapshot)
        {
            return new
            {
                origem = snapshot.Origem,
                cargaId = snapshot.CargaId,
                contrato = "CargaProntaParaEmissaoFiscal.v1",
                publicado = false,
                motivo = "Snapshot fiscal incompleto.",
                pendencias = snapshot.Pendencias
            };
        }

        private static void AddRequiredPendencies(CargaProntaParaEmissaoFiscalV1 snapshot)
        {
            if (string.IsNullOrWhiteSpace(snapshot.CargaId))
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.Carga", "Carga sem identificador operacional."));

            if (!snapshot.CargaEncontrada)
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.Carga", "Carga nao encontrada no cadastro operacional do APS."));

            if (!snapshot.Ambiente.HasValue)
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.AmbienteFiscal", "Informar ambiente fiscal da carga: homologacao ou producao."));

            if (string.IsNullOrWhiteSpace(snapshot.Carga.NumeroCarga))
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.Carga", "Carregar numero/identificacao real da carga."));

            if (!snapshot.Carga.ValorTotal.HasValue)
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.Carga", "Carregar valor total real da carga para rateio e documentos fiscais."));

            if (!snapshot.Carga.PesoTotal.HasValue)
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.Carga", "Carregar peso total real da carga."));

            if (!snapshot.Rota.CodigoMunicipioOrigem.HasValue || !snapshot.Rota.CodigoMunicipioDestino.HasValue)
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.Rota", "Carregar municipios IBGE de origem e destino."));

            if (string.IsNullOrWhiteSpace(snapshot.Transporte.CodigoTransportadora))
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.Transporte", "Carregar transportadora operacional da carga."));

            if (string.IsNullOrWhiteSpace(snapshot.Transporte.PlacaVeiculo))
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.Transporte", "Carregar placa do veiculo da carga."));

            if (string.IsNullOrWhiteSpace(snapshot.Transporte.Rntrc))
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.Transporte", "Carregar RNTRC cadastral do transportador."));

            if (string.IsNullOrWhiteSpace(snapshot.Transporte.CnpjTransportador))
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.Transporte", "Carregar CNPJ cadastral do transportador."));

            if (string.IsNullOrWhiteSpace(snapshot.Transporte.InscricaoEstadualTransportador))
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.Transporte", "Carregar inscricao estadual cadastral do transportador."));

            if (string.IsNullOrWhiteSpace(snapshot.Transporte.UfVeiculo))
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.Transporte", "Carregar UF cadastral do veiculo."));

            if (string.IsNullOrWhiteSpace(snapshot.Transporte.CpfCondutor))
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.Transporte", "Carregar condutor vinculado ao veiculo/carga quando o MDF-e exigir."));

            if (!snapshot.PreferenciasFiscais.GerarCTe.HasValue || !snapshot.PreferenciasFiscais.GerarMDFe.HasValue)
                snapshot.Pendencias.Add(new CargaFiscalPendencia("APS.PreferenciasFiscais", "Carregar decisoes fiscais da carga: gerar CT-e, gerar MDF-e e agrupamento."));
        }

        private CargaDTO? FindCarga(string? entityId)
        {
            if (string.IsNullOrWhiteSpace(entityId))
                return null;

            if (int.TryParse(entityId, out var id))
            {
                var cargaById = _cargaReadRepository.FirstById(id);
                if (cargaById != null)
                    return cargaById;
            }

            return _cargaReadRepository.FirstByCAR_ID(entityId);
        }

        private static void FillCarga(CargaProntaParaEmissaoFiscalV1 snapshot, CargaDTO? carga)
        {
            if (carga == null)
                return;

            snapshot.CargaEncontrada = true;
            snapshot.Carga.CargaId = FirstText(carga.car_id, snapshot.Carga.CargaId);
            snapshot.Carga.NumeroCarga = carga.car_id;
            snapshot.Carga.PesoTotal = FirstPositive(carga.car_peso_real, carga.car_peso_teorico, carga.car_peso_saida - carga.car_peso_entrada);
            snapshot.Carga.VolumeTotal = FirstPositive(carga.car_volume_real, carga.car_volume_teorico);
        }

        private void FillTransporte(CargaProntaParaEmissaoFiscalV1 snapshot, CargaDTO? carga)
        {
            if (carga == null)
                return;

            snapshot.Transporte.CodigoTransportadora = EmptyToNull(carga.tra_id);
            snapshot.Transporte.PlacaVeiculo = EmptyToNull(carga.vei_placa);

            if (!string.IsNullOrWhiteSpace(carga.vei_placa))
            {
                var veiculo = _veiculoReadRepository.FirstByVEI_PLACA(carga.vei_placa);
                if (veiculo != null)
                {
                    snapshot.Transporte.PlacaVeiculo = FirstText(veiculo.vei_placa, snapshot.Transporte.PlacaVeiculo);
                    snapshot.Transporte.UfVeiculo = EmptyToNull(veiculo.vei_uf);
                    snapshot.Transporte.NomeCondutor = EmptyToNull(veiculo.vei_nome_motorista);
                    snapshot.Transporte.CpfCondutor = EmptyToNull(veiculo.vei_cpf_motorista);
                }
            }

            if (!string.IsNullOrWhiteSpace(carga.tra_id))
            {
                var transportadora = _transportadoraReadRepository.FirstByTRA_ID(carga.tra_id);
                if (transportadora != null)
                {
                    snapshot.Transporte.CodigoTransportadora = FirstText(transportadora.tra_id, snapshot.Transporte.CodigoTransportadora);
                    snapshot.Transporte.RazaoSocialTransportador = EmptyToNull(transportadora.tra_nome);
                    snapshot.Transporte.CnpjTransportador = EmptyToNull(transportadora.tra_cnpj);
                    snapshot.Transporte.InscricaoEstadualTransportador = EmptyToNull(transportadora.tra_inscricao_estadual);
                    snapshot.Transporte.Rntrc = EmptyToNull(transportadora.tra_rntrc);
                }
            }
        }

        private static decimal? FirstPositive(params decimal[] values)
        {
            foreach (var value in values)
            {
                if (value > 0)
                    return value;
            }

            return null;
        }

        private static string? FirstText(string? value, string? fallback)
        {
            return string.IsNullOrWhiteSpace(value) ? fallback : value;
        }

        private static string? EmptyToNull(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }
    }

    internal sealed class CargaProntaParaEmissaoFiscalV1
    {
        public string Origem { get; set; } = string.Empty;
        public string ModuloOrigem { get; set; } = string.Empty;
        public string SagaOrigem { get; set; } = string.Empty;
        public string StepOrigem { get; set; } = string.Empty;
        public string ModuloDestino { get; set; } = string.Empty;
        public string SagaDestino { get; set; } = string.Empty;
        public int VersaoContrato { get; set; }
        public string? CargaId { get; set; }
        public long SagaId { get; set; }
        public Guid SagaCorrelationId { get; set; }
        public long StepId { get; set; }
        public string? StepKey { get; set; }
        public string? StepCorrelationId { get; set; }
        public DateTime GeradoEmUtc { get; set; }
        public int? Ambiente { get; set; }
        public bool ProntoParaPublicacao { get; set; }
        public bool CargaEncontrada { get; set; }
        public CargaFiscalCargaSnapshot Carga { get; set; } = new CargaFiscalCargaSnapshot();
        public CargaFiscalRotaSnapshot Rota { get; set; } = new CargaFiscalRotaSnapshot();
        public CargaFiscalTransporteSnapshot Transporte { get; set; } = new CargaFiscalTransporteSnapshot();
        public CargaFiscalPreferenciasSnapshot PreferenciasFiscais { get; set; } = new CargaFiscalPreferenciasSnapshot();
        public List<CargaFiscalDocumentoOriginarioSnapshot> DocumentosOriginarios { get; set; } = new List<CargaFiscalDocumentoOriginarioSnapshot>();
        public List<CargaFiscalPendencia> Pendencias { get; set; } = new List<CargaFiscalPendencia>();
    }

    internal sealed class CargaFiscalCargaSnapshot
    {
        public string? CargaId { get; set; }
        public string? NumeroCarga { get; set; }
        public decimal? ValorTotal { get; set; }
        public decimal? PesoTotal { get; set; }
        public decimal? VolumeTotal { get; set; }
    }

    internal sealed class CargaFiscalRotaSnapshot
    {
        public int? CodigoMunicipioOrigem { get; set; }
        public string? MunicipioOrigem { get; set; }
        public string? UfOrigem { get; set; }
        public int? CodigoMunicipioDestino { get; set; }
        public string? MunicipioDestino { get; set; }
        public string? UfDestino { get; set; }
    }

    internal sealed class CargaFiscalTransporteSnapshot
    {
        public string? CodigoTransportadora { get; set; }
        public string? CnpjTransportador { get; set; }
        public string? RazaoSocialTransportador { get; set; }
        public string? InscricaoEstadualTransportador { get; set; }
        public string? Rntrc { get; set; }
        public string? PlacaVeiculo { get; set; }
        public string? UfVeiculo { get; set; }
        public string? NomeCondutor { get; set; }
        public string? CpfCondutor { get; set; }
    }

    internal sealed class CargaFiscalPreferenciasSnapshot
    {
        public bool? GerarCTe { get; set; }
        public bool? GerarMDFe { get; set; }
        public string? AgrupamentoCTe { get; set; }
        public string? AgrupamentoMDFe { get; set; }
    }

    internal sealed class CargaFiscalDocumentoOriginarioSnapshot
    {
        public string Tipo { get; set; } = string.Empty;
        public string? Chave { get; set; }
        public string? Numero { get; set; }
        public string? Serie { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Peso { get; set; }
        public string? CnpjEmitente { get; set; }
        public string? CnpjDestinatario { get; set; }
    }

    internal sealed class CargaFiscalPendencia
    {
        public CargaFiscalPendencia(string origem, string descricao)
        {
            Origem = origem;
            Descricao = descricao;
        }

        public string Origem { get; }
        public string Descricao { get; }
    }
}
