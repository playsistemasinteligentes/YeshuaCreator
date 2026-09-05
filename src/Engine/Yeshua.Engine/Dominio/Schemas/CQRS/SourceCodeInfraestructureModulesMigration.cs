using Interfaces.Schemas;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using System.Data.Common;
using System.Globalization;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureModulesMigration : SourceCodeBase
    {
        private readonly Migration.MigrationBase _migration;



        public SourceCodeInfraestructureModulesMigration(Migration.MigrationBase migration)
            : base()
        {
            _migration = migration;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"namespace {CQRSParam.I.NameSpaceModules}");
            sb.AppendLine("{");

            sb.AppendLine("    public class Module");
            sb.AppendLine("    {");
            sb.AppendLine("        public string Key { get; set; }");
            sb.AppendLine("        public string Title { get; set; }");
            sb.AppendLine("        public List<Menu> Menus { get; set; } = new();");
            sb.AppendLine("");
            sb.AppendLine("        public Module(string key, string title)");
            sb.AppendLine("        {");
            sb.AppendLine("            Key = key;");
            sb.AppendLine("            Title = title;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        public Module AddMenu(Menu menu)");
            sb.AppendLine("        {");
            sb.AppendLine("            Menus.Add(menu);");
            sb.AppendLine("            return this;");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("    public class Menu");
            sb.AppendLine("    {");
            sb.AppendLine("        public string Title { get; set; }");
            sb.AppendLine("        public string Endpoint { get; set; }");
            sb.AppendLine("        public string Type { get; set; }");
            sb.AppendLine("        public string Page { get; set; }");
            sb.AppendLine("        public string Scope { get; set; }");
            sb.AppendLine("        public List<SubMenu> SubMenus { get; set; } = new();");
            sb.AppendLine("");
            sb.AppendLine("        public Menu(string title, string endpoint = \"\", string type = \"crud\", string page = \"\", string scope = \"\")");
            sb.AppendLine("        {");
            sb.AppendLine("            Title = title;");
            sb.AppendLine("            Endpoint = endpoint;");
            sb.AppendLine("            Type = type;");
            sb.AppendLine("            Page = page;");
            sb.AppendLine("            Scope = scope;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        public Menu AddSubMenu(SubMenu submenu)");
            sb.AppendLine("        {");
            sb.AppendLine("            SubMenus.Add(submenu);");
            sb.AppendLine("            return this;");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("");
            sb.AppendLine("    public class SubMenu");
            sb.AppendLine("    {");
            sb.AppendLine("        public string Title { get; set; }");
            sb.AppendLine("        public string Endpoint { get; set; }");
            sb.AppendLine("        public string Type { get; set; }");
            sb.AppendLine("        public string Page { get; set; }");
            sb.AppendLine("        public string Scope { get; set; }");
            sb.AppendLine("");
            sb.AppendLine("        public SubMenu(string title, string endpoint = \"\", string type = \"crud\", string page = \"\", string scope = \"\")");
            sb.AppendLine("        {");
            sb.AppendLine("            Title = title;");
            sb.AppendLine("            Endpoint = endpoint;");
            sb.AppendLine("            Type = type;");
            sb.AppendLine("            Page = page;");
            sb.AppendLine("            Scope = scope;");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("");



            sb.AppendLine("public static class StaticModules");
            sb.AppendLine("{");
            sb.AppendLine("    public static readonly List<Module> Modules = new List<Module>();");
            sb.AppendLine("");
            sb.AppendLine("    static StaticModules()");
            sb.AppendLine("    {");

            sb.AppendLine($"        Modules.Clear();");
            foreach (var mol in _migration.Modules)
            {
                sb.AppendLine($"        Modules.Add(new Module(\"{mol.Key}\", \"{mol.Description}\"));");

                var menuDefinitions = BuildMenuDefinitions(mol);
                var groupedMenuDefinitions = new HashSet<GeneratedMenuDefinition>();

                for (var menuGroupIndex = 0; menuGroupIndex < mol.MenuGroups.Count; menuGroupIndex++)
                {
                    var menuGroup = mol.MenuGroups[menuGroupIndex];
                    var groupItems = menuDefinitions
                        .Where(definition => !groupedMenuDefinitions.Contains(definition) && GroupMatches(menuGroup, definition))
                        .ToList();

                    if (!groupItems.Any())
                        continue;

                    var menuVariable = $"menuGroup{menuGroupIndex}";
                    sb.AppendLine($"        var {menuVariable} = new Menu(\"{Escape(menuGroup.Title)}\", \"\", \"menuGroup\");");

                    foreach (var menuItem in groupItems)
                    {
                        sb.AppendLine($"        {menuVariable}.AddSubMenu(new SubMenu(\"{Escape(menuItem.Title)}\", \"{Escape(menuItem.Endpoint)}\", \"{Escape(menuItem.Type)}\", \"{Escape(menuItem.Page)}\", \"{Escape(menuItem.Scope)}\"));");
                        groupedMenuDefinitions.Add(menuItem);
                    }

                    sb.AppendLine($"        Modules.LastOrDefault().Menus.Add({menuVariable});");
                }

                foreach (var menuItem in menuDefinitions.Where(x => !groupedMenuDefinitions.Contains(x)))
                {
                    sb.AppendLine($"        Modules.LastOrDefault().Menus.Add(new Menu(\"{Escape(menuItem.Title)}\", \"{Escape(menuItem.Endpoint)}\", \"{Escape(menuItem.Type)}\", \"{Escape(menuItem.Page)}\", \"{Escape(menuItem.Scope)}\"));");
                }
            }

            sb.AppendLine("    }");
            sb.AppendLine("}");



            sb.AppendLine("}");

            return sb;
        }
        protected override StringBuilder GenerateCustonCode()
        {
            return new StringBuilder();
        }

        private static List<GeneratedMenuDefinition> BuildMenuDefinitions(Module mol)
        {
            var menuDefinitions = new List<GeneratedMenuDefinition>();

            foreach (var customPage in mol.CustomPages)
            {
                menuDefinitions.Add(new GeneratedMenuDefinition(
                    customPage.Title,
                    $"#{customPage.Page}",
                    "customPage",
                    customPage.Page,
                    customPage.Scope));
            }

            foreach (var entity in mol.Entities)
            {
                menuDefinitions.Add(new GeneratedMenuDefinition(
                    entity.EntityName,
                    $"/getMetaData{entity.EntityName}",
                    "crud",
                    "",
                    ""));
            }

            return menuDefinitions;
        }

        private static string Escape(string value)
        {
            return (value ?? string.Empty).Replace("\\", "\\\\").Replace("\"", "\\\"");
        }

        private sealed class GeneratedMenuDefinition
        {
            public GeneratedMenuDefinition(string title, string endpoint, string type, string page, string scope)
            {
                Title = title ?? string.Empty;
                Endpoint = endpoint ?? string.Empty;
                Type = type ?? string.Empty;
                Page = page ?? string.Empty;
                Scope = scope ?? string.Empty;
            }

            public string Title { get; }
            public string Endpoint { get; }
            public string Type { get; }
            public string Page { get; }
            public string Scope { get; }

            public bool Matches(string item)
            {
                if (string.IsNullOrWhiteSpace(item))
                    return false;

                var normalizedItem = item.Trim().TrimStart('#');
                return Title.Equals(normalizedItem, StringComparison.OrdinalIgnoreCase)
                    || Page.Equals(normalizedItem, StringComparison.OrdinalIgnoreCase)
                    || Endpoint.Equals(item.Trim(), StringComparison.OrdinalIgnoreCase)
                    || Endpoint.TrimStart('#').Equals(normalizedItem, StringComparison.OrdinalIgnoreCase);
            }
        }

        private static bool GroupMatches(ModuleMenuGroup group, GeneratedMenuDefinition definition)
        {
            if (group.IncludeRemaining)
                return true;

            return group.Items.Any(definition.Matches)
                || group.Prefixes.Any(prefix => definition.Title.StartsWith(prefix, StringComparison.OrdinalIgnoreCase));
        }
        private void setResultHttp(StringBuilder sb, string result)
        {
            sb.AppendLine("try");
            sb.AppendLine("{");
            sb.AppendLine("var result = await receiver.ExecuteAsync(command);");
            sb.AppendLine("if (result.StatusCode == 200)");
            sb.AppendLine($"    return Results.Ok({result});");
            sb.AppendLine("else");
            sb.AppendLine("    return Results.BadRequest(result);");
            sb.AppendLine("}");
            sb.AppendLine("catch (Exception ex)");
            sb.AppendLine("{");
            sb.AppendLine("return Results.Problem(ex.Message);");
            sb.AppendLine("}");
        }
    }
}
