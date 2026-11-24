using Dominio.Migration;
using Dominio.Schemas.CQRS;
// Safe by default: this Studio never discovers or opens a database connection.
if (args.Length != 2 || args[0] != "--codegen-only")
    throw new ArgumentException("Use --codegen-only <repository-root>.");
new MigrationBuilder().ADDSchema(new CSharpCQRS("Presenca", Path.GetFullPath(args[1]), "Yeshua.Studio.Presenca")).Build().Run();
