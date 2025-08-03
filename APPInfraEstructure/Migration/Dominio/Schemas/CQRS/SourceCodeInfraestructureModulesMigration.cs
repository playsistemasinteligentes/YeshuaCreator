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
            sb.AppendLine("        public List<SubMenu> SubMenus { get; set; } = new();");
            sb.AppendLine("");
            sb.AppendLine("        public Menu(string title)");
            sb.AppendLine("        {");
            sb.AppendLine("            Title = title;");
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
            sb.AppendLine("        public string Route { get; set; }");
            sb.AppendLine("");
            sb.AppendLine("        public SubMenu(string title, string route)");
            sb.AppendLine("        {");
            sb.AppendLine("            Title = title;");
            sb.AppendLine("            Route = route;");
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

                foreach (var menu in mol.Entities)
                {
                    sb.AppendLine($"        Modules.LastOrDefault().Menus.Add(new Menu(\"{menu.EntityName}\"));");
                    //foreach (var sub in menu.SubMenus)
                    //sb.AppendLine($"        menu.SubMenus.Add(new SubMenu(\"{sub.Title}\", \"{sub.Route}\"));");
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
        private void setResultHttp(StringBuilder sb, string result)
        {
            sb.AppendLine("try");
            sb.AppendLine("{");
            sb.AppendLine("var result = receiver.Execute(command);");
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