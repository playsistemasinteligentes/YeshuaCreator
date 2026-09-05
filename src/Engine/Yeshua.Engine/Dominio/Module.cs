using Dominio;
using Dominio.TiposPrimitivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Dominio
{
    public class Module
    {
        public Module(string key, string description)
        {
            Key = key;
            Description = description;
        }
        public Module(string key)
        {
            Key = key;
            Description = "";
            Existe = true;
        }
        public Descricao Description { get; set; }
        public bool Existe { get; }
        public bool Inserir { set; get; } = false;
        public string Key
        {
            get; set;
        }
        public List<Entity> Entities { get; set; } = new List<Entity>();
        public List<ModuleCustomPage> CustomPages { get; set; } = new List<ModuleCustomPage>();
        public List<ModuleMenuGroup> MenuGroups { get; set; } = new List<ModuleMenuGroup>();

    }

    public class ModuleCustomPage
    {
        public ModuleCustomPage(string title, string page, string scope = "", string menuGroup = "")
        {
            Title = title;
            Page = page;
            Scope = scope;
            MenuGroup = menuGroup;
        }

        public string Title { get; set; }
        public string Page { get; set; }
        public string Scope { get; set; }
        public string MenuGroup { get; set; }
    }

    public class ModuleMenuGroup
    {
        public ModuleMenuGroup(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
        public List<string> Items { get; set; } = new List<string>();
        public List<string> Prefixes { get; set; } = new List<string>();
        public bool IncludeRemaining { get; set; }

        public ModuleMenuGroup AddItem(string item)
        {
            if (!string.IsNullOrWhiteSpace(item)
                && !Items.Any(x => x.Equals(item, StringComparison.OrdinalIgnoreCase)))
            {
                Items.Add(item);
            }

            return this;
        }

        public ModuleMenuGroup AddPrefix(string prefix)
        {
            if (!string.IsNullOrWhiteSpace(prefix)
                && !Prefixes.Any(x => x.Equals(prefix, StringComparison.OrdinalIgnoreCase)))
            {
                Prefixes.Add(prefix);
            }

            return this;
        }
    }
}
