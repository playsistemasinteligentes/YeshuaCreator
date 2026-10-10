// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using RepositoryInterfaces.Patterns.Saga;
using Dominio.Saga;
using System;
using System.Collections.Generic;

namespace Command.Receivers
{
    public class PublicarAlbumYouTubeSagaHandlerResolver : ISagaHandlerResolver
    {
        private readonly PrepararManifestoAlbumHandler _PrepararManifestoAlbumHandler;
        private readonly RenderizarVideoAlbumHandler _RenderizarVideoAlbumHandler;
        private readonly EnviarVideoParaYouTubeHandler _EnviarVideoParaYouTubeHandler;
        private readonly FinalizarPublicacaoAlbumHandler _FinalizarPublicacaoAlbumHandler;

        public PublicarAlbumYouTubeSagaHandlerResolver(PrepararManifestoAlbumHandler PrepararManifestoAlbumHandler, RenderizarVideoAlbumHandler RenderizarVideoAlbumHandler, EnviarVideoParaYouTubeHandler EnviarVideoParaYouTubeHandler, FinalizarPublicacaoAlbumHandler FinalizarPublicacaoAlbumHandler)
        {
            _PrepararManifestoAlbumHandler = PrepararManifestoAlbumHandler;
            _RenderizarVideoAlbumHandler = RenderizarVideoAlbumHandler;
            _EnviarVideoParaYouTubeHandler = EnviarVideoParaYouTubeHandler;
            _FinalizarPublicacaoAlbumHandler = FinalizarPublicacaoAlbumHandler;
        }

        public Dictionary<string, ISagaStepHandler> GetHandlers()
        {
            return new Dictionary<string, ISagaStepHandler>
            {
                { PublicarAlbumYouTubeSaga.STEP_1, _PrepararManifestoAlbumHandler },
                { PublicarAlbumYouTubeSaga.STEP_2, _RenderizarVideoAlbumHandler },
                { PublicarAlbumYouTubeSaga.STEP_3, _EnviarVideoParaYouTubeHandler },
                { PublicarAlbumYouTubeSaga.STEP_4, _FinalizarPublicacaoAlbumHandler },
            };
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers