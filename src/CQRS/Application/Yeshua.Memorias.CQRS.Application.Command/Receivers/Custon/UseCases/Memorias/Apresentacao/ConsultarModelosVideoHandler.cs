// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

//scope;
using Dominio.Interfaces;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Command.Interfaces.Patterns.FileStore;

namespace Command.Receivers.UseCase
{
    public partial class ConsultarModelosVideoHandler
    {
        private readonly IFileStorage _music;
        public ConsultarModelosVideoHandler(ILogger logger, IExecutionContext context, IFileStorage music) : this(logger, context) => _music = music;

protected partial async Task<State<ConsultarModelosVideoOutputCommand>> CustomActionHookAsync(State<ConsultarModelosVideoOutputCommand> state, ConsultarModelosVideoInputCommand comand, CancellationToken cancellationToken)
{
    var output = new ConsultarModelosVideoOutputCommand
    {
        Modelos = Dominio.Media.VideoPresentation.Models.Select(model => new VideoModelInfo
        {
            Id = model.Id, Nome = model.Name, Movimento = model.Motion, Transicao = model.Transition, MusicaSugeridaId = model.SuggestedMusicId
        }).ToList(),
        Musicas = new()
    };
    foreach (var track in Dominio.Media.VideoPresentation.Music)
        output.Musicas.Add(new MusicInfo
        {
            Id = track.Id, Titulo = track.Title, Autor = track.Artist, Categoria = track.Category,
            Licenca = track.License, UrlFonte = track.SourceUrl, UrlLicenca = track.LicenseUrl,
            Creditos = track.Credits, Disponivel = await _music.ExistsAsync(Command.Media.MemoriasStorage.MusicPath(track), cancellationToken)
        });
    return Success("OK", output);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
