// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Patterns.Saga;

namespace Dominio.Saga
{
    public class PublicarAlbumYouTubeSaga : SagaBase
    {
        public const string STEP_1 = "PrepararManifestoAlbum";
        public const string STEP_2 = "RenderizarVideoAlbum";
        public const string STEP_3 = "EnviarVideoParaYouTube";
        public const string STEP_4 = "FinalizarPublicacaoAlbum";

        public PublicarAlbumYouTubeSaga()
        {
            AddStep(new PublicarAlbumYouTubeStep(STEP_1, 1));
            AddStep(new PublicarAlbumYouTubeStep(STEP_2, 2));
            AddStep(new PublicarAlbumYouTubeStep(STEP_3, 3));
            AddStep(new PublicarAlbumYouTubeStep(STEP_4, 4));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers