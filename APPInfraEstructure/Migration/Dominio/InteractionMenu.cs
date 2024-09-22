
namespace Dominio
{
    public class InteractionMenu
    {
        public InteractionMenu(Entity entity, string name)
        {
            Entity = entity;
            Name = name;
            Options = new Dictionary<int, string>();
        }

        public Entity Entity { get; set; }
        public string Name { get; set; }
        public Dictionary<int, string> Options { get; set; }

        public InteractionMenu AddOption(int id, string name)
        {
            Options.Add(id, name);
            return this;
        }
    }
}