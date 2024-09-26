
namespace Dominio
{
    public class InteractionMenu
    {
        public InteractionMenu(Hub hub, string name)
        {
            Hub = hub;
            Name = name;
            Options = new Dictionary<int, string>();
        }

        public Hub Hub { get; set; }
        public string Name { get; set; }
        public Dictionary<int, string> Options { get; set; }

        public InteractionMenu AddOption(int id, string name)
        {
            Options.Add(id, name);
            return this;
        }
    }
}