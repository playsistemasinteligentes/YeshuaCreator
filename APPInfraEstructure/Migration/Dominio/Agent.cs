using Migration.Dominio.Schemas;
using System.Collections.Generic;
using System.Data.Common;

namespace Dominio
{
    public class Agent
    {
        public Agent(string name, string description, Hub hub)
        {
            this.Name = name;
            this.Description = description;
            this.Hub = hub;
            this.Methods = new List<Method>();
            this.InteractionMenu = new List<InteractionMenu>();
        }

        public Hub Hub { get; set; }
        public List<Method> Methods { get; set; }
        public List<InteractionMenu> InteractionMenu { get; set; }
        public string Name { get; private set; }
        private string Description { get; set; }

        public Hub AddInteractionMenu(InteractionMenu menu)
        {
            InteractionMenu.Add(menu);
            return this.Hub;
        }


        public Hub AddMethod(Method method)
        {
            Methods.Add(method);
            return this.Hub;
        }

    }
}