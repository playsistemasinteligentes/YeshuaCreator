using Migration.Dominio.Schemas;
using System.Collections.Generic;
using System.Data.Common;

namespace Dominio
{
    public class Agent
    {
        public Agent(string name, string description, Entity entity)
        {
            this.Name = name;
            this.Description = description;
            this.Entity = entity;
            this.Methods = new List<Method>();
            this.InteractionMenu = new List<InteractionMenu>();
        }

        public Entity Entity { get; set; }
        public List<Method> Methods { get; set; }
        public List<InteractionMenu> InteractionMenu { get; set; }
        public string Name { get; private set; }
        private string Description { get; set; }

        public Entity AddInteractionMenu(InteractionMenu menu)
        {
            InteractionMenu.Add(menu);
            return this.Entity;
        }


        public Entity AddMethod(Method method)
        {
            Methods.Add(method);
            return this.Entity;
        }

    }
}