using Shered.DB;
namespace IQuery.Read
{
    public interface IDisponibilidadeAgendaQueryRead 
    {
        public QueryModel DisponibilidadeAgendaQuery(Command.Read.DisponibilidadeAgendaReadCommand Command);
        public QueryModel DisponibilidadeAgendaProfissionalIdQuery(Command.Patterns.Command.SearchFKCommand Command);
        public QueryModel ExistsByIdQuery(int value);
        public QueryModel ExistsByProfissionalIdQuery(int value);
        public QueryModel ExistsByDataHoraQuery(DateTime value);
        public QueryModel FirstByIdQuery(int value);
        public QueryModel FirstByProfissionalIdQuery(int value);
        public QueryModel FirstByDataHoraQuery(DateTime value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration