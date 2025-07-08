using Dominio.TiposPrimitivos;
using Migration.Dominio.Schemas;
using System.Collections.Generic;
using System.Data.Common;

namespace Dominio
{
    public class Agent
    {
        public Agent(string name, string description, UseCaseGroup hub)
        {
            this.Name = name;
            this.Description = description;
            this.Hub = hub;
            this.Methods = new List<UseCase>();
            this.Menus = new List<Menu>();
        }

        public UseCaseGroup Hub { get; set; }
        public List<UseCase> Methods { get; set; }
        public List<Menu> Menus { get; set; }
        public Descricao Name { get; private set; }
        private string Description { get; set; }

        public UseCaseGroup AddMenu(Menu menu)
        {
            Menus.Add(menu);
            return this.Hub;
        }


        public UseCaseGroup AddMethod(UseCase method)
        {
            Methods.Add(method);
            return this.Hub;
        }

    }
}