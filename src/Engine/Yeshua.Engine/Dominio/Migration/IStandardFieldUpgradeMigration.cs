namespace Dominio.Migration;

public interface IStandardFieldUpgradeMigration
{
    IReadOnlyCollection<string> FieldNames { get; }
}
