using Repositorio.Outputs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;

namespace Command.Receivers
{
    internal static class FiscalContingenciaPayload
    {
        public static int EntradaId(string payload)
            => Int(payload, "entradaFiscalContingenciaId", "EntradaFiscalContingenciaId");

        public static string Text(string? json, params string[] names)
        {
            if (string.IsNullOrWhiteSpace(json))
                return string.Empty;

            try
            {
                using var document = JsonDocument.Parse(json);
                return Text(document.RootElement, names);
            }
            catch (JsonException)
            {
                return string.Empty;
            }
        }

        public static int Int(string? json, params string[] names)
        {
            if (string.IsNullOrWhiteSpace(json))
                return 0;

            try
            {
                using var document = JsonDocument.Parse(json);
                foreach (var name in names)
                {
                    if (!TryGetProperty(document.RootElement, name, out var value))
                        continue;

                    if (value.ValueKind == JsonValueKind.Number && value.TryGetInt32(out var intValue))
                        return intValue;

                    if (value.ValueKind == JsonValueKind.String && int.TryParse(value.GetString(), out intValue))
                        return intValue;
                }
            }
            catch (JsonException)
            {
            }

            return 0;
        }

        public static string ComplementoText(string payload, params string[] names)
        {
            var complemento = Text(payload, "dadosComplementaresJson", "DadosComplementaresJson");
            return Text(complemento, names);
        }

        public static string ComplementoJson(EntradaFiscalContingenciaDTO entrada)
        {
            var complemento = Text(entrada.snapshotjson, "dadosComplementaresJson", "DadosComplementaresJson");
            if (!string.IsNullOrWhiteSpace(complemento))
                return complemento;

            complemento = Text(entrada.snapshotjson, "preferenciasFiscaisJson", "PreferenciasFiscaisJson");
            return string.IsNullOrWhiteSpace(complemento) ? "{}" : complemento;
        }

        public static decimal Number(string? json, params string[] names)
        {
            if (string.IsNullOrWhiteSpace(json))
                return 0m;

            try
            {
                using var document = JsonDocument.Parse(json);
                foreach (var name in names)
                {
                    if (!TryGetProperty(document.RootElement, name, out var value))
                        continue;

                    if (value.ValueKind == JsonValueKind.Number && value.TryGetDecimal(out var decimalValue))
                        return decimalValue;

                    if (value.ValueKind == JsonValueKind.String && TryParseDecimal(value.GetString(), out decimalValue))
                        return decimalValue;
                }
            }
            catch (JsonException)
            {
            }

            return 0m;
        }

        public static List<string> Pendencias(EntradaFiscalContingenciaDTO entrada, IEnumerable<NFeProdutoSnapshotDTO> documentos)
        {
            var pendencias = new List<string>();
            var complemento = ComplementoJson(entrada);

            Require(pendencias, entrada.cargaid, "CargaId");
            Require(pendencias, Value(entrada.rntrc, complemento, "rntrc", "RNTRC"), "RNTRC");
            Require(pendencias, Value(entrada.placaveiculo, complemento, "placaVeiculo", "placa"), "PlacaVeiculo");
            Require(pendencias, Value(entrada.ufveiculo, complemento, "ufVeiculo", "UFVeiculo"), "UFVeiculo");
            Require(pendencias, Value(entrada.condutordocumento, complemento, "condutorDocumento", "cpfMotorista", "cpfCondutor"), "CondutorDocumento");
            Require(pendencias, Value(entrada.condutornome, complemento, "condutorNome", "nomeMotorista", "nomeCondutor"), "CondutorNome");
            Require(pendencias, Value(entrada.ufinicio, complemento, "ufInicio", "UFInicio"), "UFInicio");
            Require(pendencias, Value(entrada.uffim, complemento, "ufFim", "UFFim"), "UFFim");
            Require(pendencias, Value(entrada.municipioiniciocodigoibge, complemento, "municipioInicioCodigoIbge", "codigoMunicipioInicio"), "MunicipioInicioCodigoIbge");
            Require(pendencias, Value(entrada.municipiofimcodigoibge, complemento, "municipioFimCodigoIbge", "codigoMunicipioFim"), "MunicipioFimCodigoIbge");

            if (string.IsNullOrWhiteSpace(complemento) || complemento == "{}")
            {
                pendencias.Add("DadosComplementaresJson");
            }
            else
            {
                Require(pendencias, Text(complemento, "tipoAgrupamentoCTe", "tipoAgrupamentoCte"), "TipoAgrupamentoCTe");
                Require(pendencias, Text(complemento, "estrategiaRateioFrete"), "EstrategiaRateioFrete");

                if (Number(complemento, "valorFrete", "valorServico") <= 0m)
                    pendencias.Add("ValorFrete");
            }

            if (!documentos.Any())
                pendencias.Add("DocumentosOriginarios");

            return pendencias;
        }

        public static string SummaryJson(EntradaFiscalContingenciaDTO entrada, IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos)
        {
            var complemento = ComplementoJson(entrada);

            return JsonSerializer.Serialize(new
            {
                entrada.id,
                entrada.correlationid,
                entrada.cargaid,
                entrada.tiposolicitante,
                entrada.ambiente,
                rntrc = Value(entrada.rntrc, complemento, "rntrc", "RNTRC"),
                placaveiculo = Value(entrada.placaveiculo, complemento, "placaVeiculo", "placa"),
                ufveiculo = Value(entrada.ufveiculo, complemento, "ufVeiculo", "UFVeiculo"),
                condutordocumento = Value(entrada.condutordocumento, complemento, "condutorDocumento", "cpfMotorista", "cpfCondutor"),
                condutornome = Value(entrada.condutornome, complemento, "condutorNome", "nomeMotorista", "nomeCondutor"),
                ufinicio = Value(entrada.ufinicio, complemento, "ufInicio", "UFInicio"),
                uffim = Value(entrada.uffim, complemento, "ufFim", "UFFim"),
                municipioiniciocodigoibge = Value(entrada.municipioiniciocodigoibge, complemento, "municipioInicioCodigoIbge", "codigoMunicipioInicio"),
                municipiofimcodigoibge = Value(entrada.municipiofimcodigoibge, complemento, "municipioFimCodigoIbge", "codigoMunicipioFim"),
                quantidadeDocumentos = documentos.Count,
                valorCarga = documentos.Sum(x => x.valordocumento),
                pesoBruto = documentos.Sum(x => x.pesobruto),
                volume = documentos.Sum(x => x.volume),
                valorFrete = Number(complemento, "valorFrete", "valorServico"),
                tipoAgrupamentoCTe = Text(complemento, "tipoAgrupamentoCTe", "tipoAgrupamentoCte"),
                estrategiaRateioFrete = Text(complemento, "estrategiaRateioFrete"),
                origemRotaFiscal = Text(complemento, "origemRotaFiscal"),
                observacaoFiscal = Text(complemento, "observacaoFiscal"),
                dadosComplementaresJson = complemento,
                documentos = documentos.Select(x => new
                {
                    x.chaveacesso,
                    x.emitentedocumento,
                    x.destinatariodocumento,
                    x.uforigem,
                    x.ufdestino,
                    x.municipioorigemcodigoibge,
                    x.municipiodestinocodigoibge,
                    x.valordocumento,
                    x.pesobruto,
                    x.volume
                })
            });
        }

        public static string PlanoEmissaoJson(EntradaFiscalContingenciaDTO entrada, IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos)
        {
            var complemento = ComplementoJson(entrada);
            var tipoAgrupamento = FirstNonEmpty(
                Text(complemento, "tipoAgrupamentoCTe", "tipoAgrupamentoCte"),
                "um_cte_por_nfe");
            var estrategiaRateio = FirstNonEmpty(
                Text(complemento, "estrategiaRateioFrete"),
                "proporcional_valor_documento");
            var valorFrete = Number(complemento, "valorFrete", "valorServico");
            var grupos = AgruparDocumentos(entrada, documentos, tipoAgrupamento);
            var totalBaseRateio = grupos.Sum(x => BaseRateio(x.Documentos, estrategiaRateio));

            return JsonSerializer.Serialize(new
            {
                type = "fiscal.contingencia.plano-emissao",
                entrada.id,
                entrada.correlationid,
                entrada.cargaid,
                entrada.ambiente,
                rntrc = Value(entrada.rntrc, complemento, "rntrc", "RNTRC"),
                placaveiculo = Value(entrada.placaveiculo, complemento, "placaVeiculo", "placa"),
                ufveiculo = Value(entrada.ufveiculo, complemento, "ufVeiculo", "UFVeiculo"),
                condutordocumento = Value(entrada.condutordocumento, complemento, "condutorDocumento", "cpfMotorista", "cpfCondutor"),
                condutornome = Value(entrada.condutornome, complemento, "condutorNome", "nomeMotorista", "nomeCondutor"),
                ufinicio = Value(entrada.ufinicio, complemento, "ufInicio", "UFInicio"),
                uffim = Value(entrada.uffim, complemento, "ufFim", "UFFim"),
                municipioiniciocodigoibge = Value(entrada.municipioiniciocodigoibge, complemento, "municipioInicioCodigoIbge", "codigoMunicipioInicio"),
                municipiofimcodigoibge = Value(entrada.municipiofimcodigoibge, complemento, "municipioFimCodigoIbge", "codigoMunicipioFim"),
                quantidadeDocumentos = documentos.Count,
                valorCarga = documentos.Sum(x => x.valordocumento),
                pesoBruto = documentos.Sum(x => x.pesobruto),
                volume = documentos.Sum(x => x.volume),
                valorFrete,
                tipoAgrupamentoCTe = tipoAgrupamento,
                estrategiaRateioFrete = estrategiaRateio,
                origemRotaFiscal = Text(complemento, "origemRotaFiscal"),
                observacaoFiscal = Text(complemento, "observacaoFiscal"),
                dadosComplementaresJson = complemento,
                preferenciasFiscaisJson = complemento,
                pendencias = Pendencias(entrada, documentos),
                ctesPrevistos = grupos.Select(grupo =>
                {
                    var baseRateio = BaseRateio(grupo.Documentos, estrategiaRateio);
                    return new
                    {
                        grupo.Chave,
                        grupo.Descricao,
                        quantidadeDocumentos = grupo.Documentos.Count,
                        valorDocumentos = grupo.Documentos.Sum(x => x.valordocumento),
                        pesoBruto = grupo.Documentos.Sum(x => x.pesobruto),
                        valorFreteRateado = RatearValorFrete(valorFrete, estrategiaRateio, baseRateio, totalBaseRateio),
                        documentos = grupo.Documentos.Select(x => new
                        {
                            x.chaveacesso,
                            x.emitentedocumento,
                            x.destinatariodocumento,
                            x.uforigem,
                            x.ufdestino,
                            x.valordocumento,
                            x.pesobruto
                        })
                    };
                })
            });
        }

        private static string Text(JsonElement root, params string[] names)
        {
            foreach (var name in names)
            {
                if (!TryGetProperty(root, name, out var value))
                    continue;

                if (value.ValueKind == JsonValueKind.String)
                    return value.GetString() ?? string.Empty;

                if (value.ValueKind is JsonValueKind.Number or JsonValueKind.True or JsonValueKind.False)
                    return value.ToString();

                if (value.ValueKind is JsonValueKind.Object or JsonValueKind.Array)
                    return value.GetRawText();
            }

            return string.Empty;
        }

        private static bool TryGetProperty(JsonElement item, string name, out JsonElement value)
        {
            if (item.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in item.EnumerateObject())
                {
                    if (string.Equals(property.Name, name, StringComparison.OrdinalIgnoreCase))
                    {
                        value = property.Value;
                        return true;
                    }
                }
            }

            value = default;
            return false;
        }

        private static void Require(List<string> pendencias, string? value, string field)
        {
            if (string.IsNullOrWhiteSpace(value))
                pendencias.Add(field);
        }

        private static string Value(string? entityValue, string complemento, params string[] names)
        {
            return string.IsNullOrWhiteSpace(entityValue)
                ? Text(complemento, names)
                : entityValue;
        }

        private static bool TryParseDecimal(string? value, out decimal result)
        {
            var text = (value ?? string.Empty).Trim();
            if (text.Contains(','))
                text = text.Replace(".", string.Empty).Replace(',', '.');

            return decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out result);
        }

        private static string FirstNonEmpty(string first, string fallback)
            => string.IsNullOrWhiteSpace(first) ? fallback : first;

        private static List<ContingenciaCteGrupo> AgruparDocumentos(
            EntradaFiscalContingenciaDTO entrada,
            IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos,
            string tipoAgrupamento)
        {
            var grupos = new Dictionary<string, ContingenciaCteGrupo>(StringComparer.OrdinalIgnoreCase);
            var index = 0;

            foreach (var documento in documentos)
            {
                index++;
                var chave = ChaveGrupo(entrada, documento, tipoAgrupamento, index);
                if (!grupos.TryGetValue(chave, out var grupo))
                {
                    grupo = new ContingenciaCteGrupo(chave, DescricaoGrupo(entrada, documento, tipoAgrupamento, index));
                    grupos.Add(chave, grupo);
                }

                grupo.Documentos.Add(documento);
            }

            return grupos.Values.ToList();
        }

        private static string ChaveGrupo(
            EntradaFiscalContingenciaDTO entrada,
            NFeProdutoSnapshotDTO documento,
            string tipoAgrupamento,
            int index)
        {
            return tipoAgrupamento switch
            {
                "agrupar_por_destinatario" => FirstNonEmpty(documento.destinatariodocumento, "sem-destinatario"),
                "cte_unico_da_carga" => FirstNonEmpty(entrada.cargaid, "carga"),
                _ => FirstNonEmpty(documento.chaveacesso, "documento-" + index)
            };
        }

        private static string DescricaoGrupo(
            EntradaFiscalContingenciaDTO entrada,
            NFeProdutoSnapshotDTO documento,
            string tipoAgrupamento,
            int index)
        {
            return tipoAgrupamento switch
            {
                "agrupar_por_destinatario" => "Destinatario " + FirstNonEmpty(documento.destinatariodocumento, "nao informado"),
                "cte_unico_da_carga" => "Carga " + FirstNonEmpty(entrada.cargaid, "sem codigo"),
                _ => "Documento " + FirstNonEmpty(documento.chaveacesso, index.ToString(CultureInfo.InvariantCulture))
            };
        }

        private static decimal BaseRateio(IReadOnlyCollection<NFeProdutoSnapshotDTO> documentos, string estrategiaRateio)
        {
            return estrategiaRateio switch
            {
                "proporcional_peso_bruto" => documentos.Sum(x => x.pesobruto),
                "manual" => 0m,
                "sem_rateio" => 0m,
                _ => documentos.Sum(x => x.valordocumento)
            };
        }

        private static decimal RatearValorFrete(decimal valorFrete, string estrategiaRateio, decimal baseGrupo, decimal totalBase)
        {
            if (valorFrete <= 0m || estrategiaRateio is "manual" or "sem_rateio")
                return 0m;

            if (totalBase <= 0m)
                return Math.Round(valorFrete, 2, MidpointRounding.AwayFromZero);

            return Math.Round(valorFrete * (baseGrupo / totalBase), 2, MidpointRounding.AwayFromZero);
        }

        private sealed class ContingenciaCteGrupo
        {
            public ContingenciaCteGrupo(string chave, string descricao)
            {
                Chave = chave;
                Descricao = descricao;
            }

            public string Chave { get; }
            public string Descricao { get; }
            public List<NFeProdutoSnapshotDTO> Documentos { get; } = new();
        }
    }
}
