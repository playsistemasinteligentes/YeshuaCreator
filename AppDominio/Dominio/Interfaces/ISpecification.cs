namespace Dominio.Interfaces
{
    //🔹 Interface: ISpecification<T>
    //Padrão clássico de Eric Evans.

    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
        string Name { get; }
    }
    // Local: Domain.Specifications
    //Responsabilidade: Definir regras imutáveis da entidade.
}
