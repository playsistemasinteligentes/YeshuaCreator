// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Interfaces;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using IRepository.Write;
using Command.UseCase;

namespace Command.Receivers.UseCase
{
    public partial class GirarFotoHandler
    {
        private readonly IAlbumFotoWriteRepository _photos;

        public GirarFotoHandler(ILogger logger, IExecutionContext context, IAlbumFotoWriteRepository photos)
            : base(logger, context)
        {
            _logger = logger;
            _executionContext = context;
            _photos = photos;
        }

        protected partial Task<State<GirarFotoOutputCommand>> CustomActionHookAsync(
            State<GirarFotoOutputCommand> state, GirarFotoInputCommand comand, CancellationToken cancellationToken)
        {
            if (comand.AlbumFotoId <= 0 || comand.Rotacao is not (0 or 90 or 180 or 270))
                return Task.FromResult(ValidationError("Informe a foto e uma rotacao de 0, 90, 180 ou 270 graus."));
            if (_executionContext.TenantID <= 0 || _executionContext.UserId <= 0
                || !_photos.TrySetRotation(comand.AlbumFotoId, _executionContext.TenantID, _executionContext.UserId, comand.Rotacao, DateTime.UtcNow))
                return Task.FromResult(ValidationError("Foto indisponivel ou album em publicacao."));
            return Task.FromResult(Success("Orientacao da foto salva.", new GirarFotoOutputCommand
            {
                AlbumFotoId = comand.AlbumFotoId, Rotacao = comand.Rotacao
            }));
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
