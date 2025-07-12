namespace Dominio
{
    public class Strategy
    {
        public Strategy(Type type)
        {
            Type = type;
        }

        public Type Type { get; set; }
        public List<Type> StrategyAgregate { get; set; } = new List<Type>();


    }
}