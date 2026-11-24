namespace Read.Repository;
public partial class ySagaReadRepository
{
 // Reuse the generated claim predicate so health does not invent another eligibility rule.
 public static string PredicadoProntoParaSaude {get;}=RunnableSagaPredicate("s");
}
