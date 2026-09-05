// <yeshua>
// artifact: CUSTOM_OWNED_BY_DEV
// createdBy: IA_DEV
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// </yeshua>

using System;

namespace Repositorio.Outputs
{
    public sealed class PlanejamentoTransporteContextDTO
    {
        public int quantidadepedidos { get; set; }
        public int quantidadecargas { get; set; }
        public decimal peso { get; set; }
        public decimal volume { get; set; }
    }

    public sealed class PlanejamentoTransporteLensGroupDTO
    {
        public string valor { get; set; }
        public int quantidadepedidos { get; set; }
        public decimal peso { get; set; }
        public decimal volume { get; set; }
    }
}
