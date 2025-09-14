using Dominio.Migration;
using Dominio.Schemas.CQRS.Abstraction;
using Migration.Dominio;
using Migration.Dominio.Schemas.CQRS;
using MyApp.QueryBuilder;
using System;
using System.Collections.Specialized;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Dynamic;
using System.Text;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio.Schemas.CQRS
{
    public class SourceCodeInfraestructureQueryReadMigration : SourceCodeBase
    {
        private readonly Entity _entity;
        private readonly bool _isInterface;
        public SourceCodeInfraestructureQueryReadMigration(Entity entity, bool isInterface)
            : base()
        {
            _entity = entity;
            _isInterface = isInterface;
        }

        protected override StringBuilder GenerateCode()
        {
            var sb = new StringBuilder();
            var itens = _entity.AddColumns.Where(x => x.WhereCanTakeOff).Select(colun => $"bool TakeOff{colun.Name} = false");
            string takeOff = itens.Any() ? ", " + string.Join(", ", itens) : string.Empty;

            if (_isInterface)
            {
                sb.AppendLine($"using Shered.DB;");
                sb.AppendLine($"namespace {CQRSParam.I.NameSpaceIQueryRead}");
                sb.AppendLine("{");
                sb.AppendLine($"    public interface I{_entity.EntityName}QueryRead ");
                sb.AppendLine("    {");

                sb.AppendLine($"        public QueryModel {_entity.EntityName}Query({CQRSParam.I.NameSpaceCommandRead}.{_entity.EntityName}{CommandType.Read}Command Command {takeOff});");
                foreach (var column in _entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                {
                    sb.AppendLine($"        public QueryModel {_entity.EntityName}{column.Name}Query({CQRSParam.I.NameSpaceCommandPatterns}.SearchFKCommand Command {takeOff});");
                }
                // exist retorno bool 
                foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
                {
                    string csharpType = column.getCsharpType();
                    sb.AppendLine($"        public QueryModel ExistsBy{column.Name}Query({csharpType} value {takeOff});");
                }
                // firt by 
                foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
                {
                    string csharpType = column.getCsharpType();
                    sb.AppendLine($"        public QueryModel FirstBy{column.Name}Query({csharpType} value {takeOff});");
                }
                //getall   pendencia

                // Queries via AddQuery
                foreach (var query in _entity.Queries.OfType<IQueryWithMeta>())
                {
                    // WhereContexts
                    foreach (var ctxName in query.Meta.WhereContextParameters.Keys)
                    {
                        string methodName = $"{_entity.EntityName}{ctxName}Query";
                        sb.AppendLine($"    public QueryModel {methodName}({CQRSParam.I.NameSpaceCommandRead}.{_entity.EntityName}{ctxName}Command Command);");
                    }

                    // Wheres
                    foreach (var whName in query.Meta.WhereParameters.Keys)
                    {
                        string methodName = $"{_entity.EntityName}{whName}";
                        sb.AppendLine($"    public QueryModel {methodName}Query({CQRSParam.I.NameSpaceCommandRead}.{methodName}Command Command);");
                    }
                }

                sb.AppendLine("    }");
                sb.AppendLine("}");

            }
            else
            {
                sb.AppendLine("using Shered.DB;");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandRead};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceIQueryRead};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceIterfaceAplicationServices};");


                sb.AppendLine("using System;");
                sb.AppendLine("using System.Collections.Generic;");
                sb.AppendLine("using System.Linq;");
                sb.AppendLine("using System.Text;");
                sb.AppendLine("using System.Dynamic;");
                sb.AppendLine("using System.Threading.Tasks;");

                sb.AppendLine();
                sb.AppendLine($"namespace {CQRSParam.I.NameSpaceQueryRead} ");
                sb.AppendLine("{");

                sb.AppendLine($"    public class {_entity.EntityName}QueryRead : QueryBase, I{_entity.EntityName}QueryRead");
                sb.AppendLine("    {");

                sb.AppendLine($"        protected readonly ICurrentUser _currentUser;");

                sb.AppendLine($"        public {_entity.EntityName}QueryRead(ICurrentUser currentUser)");
                sb.AppendLine("        {");
                sb.AppendLine($"            _currentUser = currentUser;");
                sb.AppendLine("        }");

                sb.AppendLine($"        public QueryModel {_entity.EntityName}Query({CQRSParam.I.NameSpaceCommandRead}.{_entity.EntityName}{CommandType.Read}Command Command {takeOff})");
                sb.AppendLine("        {");
                sb.AppendLine($"            this.Parameters = null;");
                sb.AppendLine($"            var whereClauses = new List<string>();");
                sb.AppendLine($"            dynamic parameters = new ExpandoObject();");
                sb.AppendLine($"            var parametersDict = (IDictionary<string, object>)parameters;");


                var columnsString = string.Join(", ", _entity.AddColumns.Select(x => x.Name));
                sb.AppendLine($"            this.Query = $@\" select {columnsString} from {_entity.EntityName} \";");


                foreach (var item in _entity.AddColumns.Where(x => !x.IsBackEndField))
                    Parameters(sb, item);


                sb.AppendLine("            if (whereClauses.Any()) ");
                sb.AppendLine("                 this.Query += $\" WHERE {string.Join(\" AND \", whereClauses)}\"; ");

                // Paginação
                sb.AppendLine("            int page = Command.Paginacao?.Page ?? 1;");
                sb.AppendLine("            int pageSize = Command.Paginacao?.PageSize ?? 20;");
                sb.AppendLine("            int offset = (page - 1) * pageSize;");
                sb.AppendLine("            parametersDict[\"Offset\"] = offset;");
                sb.AppendLine("            parametersDict[\"PageSize\"] = pageSize;");
                sb.AppendLine("            Query += \" ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY\"; ");

                sb.AppendLine($"            this.Parameters = parameters;");
                sb.AppendLine("            return new QueryModel(this.Query, this.Parameters);");
                sb.AppendLine("        }");


                foreach (var column in _entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                {
                    sb.AppendLine($"        public QueryModel {_entity.EntityName}{column.Name}Query({CQRSParam.I.NameSpaceCommandPatterns}.SearchFKCommand Command {takeOff})");
                    sb.AppendLine("        {");

                    columnsString = string.Join(", ", column.EntityFK.AddColumns.Where(x => x.DisplayFK).Select(x => x.Name));
                    sb.AppendLine($"            this.Query = $@\" select {columnsString} from {column.EntityFK.EntityName} \";");
                    sb.AppendLine($"            this.Parameters = null;");
                    sb.AppendLine($"            var whereClauses = new List<string>();");
                    sb.AppendLine($"            dynamic parameters = new ExpandoObject();");
                    sb.AppendLine($"            var parametersDict = (IDictionary<string, object>)parameters;");

                    sb.AppendLine("            if (!string.IsNullOrEmpty(Command.searchFK)) ");
                    sb.AppendLine("            {");
                    sb.AppendLine("                 if (int.TryParse(Command.searchFK, out int numero)) ");
                    sb.AppendLine("                 {");

                    sb.AppendLine($"                      parametersDict[\"{column.ColumnReference}\"] = numero; ");
                    sb.AppendLine($"                      whereClauses.Add($\" {column.ColumnReference} = @{column.ColumnReference}\"); ");

                    sb.AppendLine("                 }");
                    sb.AppendLine("                 else ");
                    sb.AppendLine("                 {");

                    foreach (var item in column.EntityFK.AddColumns.Where(x => x.DisplayFK))
                    {
                        sb.AppendLine($"                      parametersDict[\"{item.Name}\"] = $\"%{{Command.searchFK}}%\"; ");
                        sb.AppendLine($"                      whereClauses.Add($\" {item.Name} like @{item.Name} \");");
                    }
                    sb.AppendLine("                 }");
                    sb.AppendLine("           }");
                    foreach (var item in column.EntityFK.AddColumns.Where(x => x.WhereNeedBe))
                        Parameters(sb, item, true);

                    if (!string.IsNullOrEmpty(column.ClausesWhere))
                        sb.AppendLine($"                      whereClauses.Add(\" {column.ClausesWhere} \"); ");

                    sb.AppendLine("            if (whereClauses.Any()) ");
                    sb.AppendLine("            this.Query += $\" WHERE ({string.Join(\" AND \", whereClauses)})\"; "); // pendencia OR

                    sb.AppendLine($"            this.Parameters = parameters;");
                    sb.AppendLine("            return new QueryModel(this.Query, this.Parameters); ");
                    sb.AppendLine("        }");
                }


                // exist retorno bool 
                foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
                {
                    string csharpType = column.getCsharpType();
                    sb.AppendLine($"        public QueryModel ExistsBy{column.Name}Query({csharpType} value {takeOff})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            this.Parameters = null;");
                    sb.AppendLine($"            var whereClauses = new List<string>();");
                    sb.AppendLine($"            dynamic parameters = new ExpandoObject();");
                    sb.AppendLine($"            var parametersDict = (IDictionary<string, object>)parameters;");
                    sb.AppendLine($"            this.Query = $\"SELECT 1 FROM {_entity.EntityName} \";");

                    foreach (var item in _entity.AddColumns.Where(x => x.WhereNeedBe))
                        Parameters(sb, item);


                    sb.AppendLine($"                      parametersDict[\"{column.Name}\"] = value; ");
                    sb.AppendLine($"                      whereClauses.Add($\" {column.Name} = @{column.Name} \");");
                    sb.AppendLine("            if (whereClauses.Any()) ");
                    sb.AppendLine("            this.Query += $\" WHERE ({string.Join(\" AND \", whereClauses)})\"; "); // pendencia OR

                    sb.AppendLine($"            this.Parameters = parameters;");
                    sb.AppendLine("            return new QueryModel(this.Query, parameters);");
                    sb.AppendLine("        }");
                }


                // firt by 
                foreach (var column in _entity.AddColumns.Where(x => !x.IsBackEndField))
                {
                    string csharpType = column.getCsharpType();
                    sb.AppendLine($"        public QueryModel FirstBy{column.Name}Query({csharpType} value {takeOff})");
                    sb.AppendLine("        {");
                    sb.AppendLine($"            this.Parameters = null;");
                    sb.AppendLine($"            var whereClauses = new List<string>();");
                    sb.AppendLine($"            dynamic parameters = new ExpandoObject();");
                    sb.AppendLine($"            var parametersDict = (IDictionary<string, object>)parameters;");

                    sb.AppendLine($"            this.Query = $\"SELECT * FROM {_entity.EntityName} \";");
                    foreach (var item in _entity.AddColumns.Where(x => x.WhereNeedBe))
                        Parameters(sb, item);

                    sb.AppendLine($"                      parametersDict[\"{column.Name}\"] = value; ");
                    sb.AppendLine($"                      whereClauses.Add($\" {column.Name} = @{column.Name} \");");
                    sb.AppendLine("            if (whereClauses.Any()) ");
                    sb.AppendLine("            this.Query += $\" WHERE ({string.Join(\" AND \", whereClauses)})\"; "); // pendencia OR

                    sb.AppendLine($"            this.Parameters = parameters;");
                    sb.AppendLine("            return new QueryModel(this.Query, parameters);");
                    sb.AppendLine("        }");
                }


                foreach (var query in _entity.Queries.OfType<IQueryWithMeta>())
                {
                    var prefixoList = query.Meta.SelectFields.Select(x => x.Prefix).Distinct();

                    // ---- Context queries (WhereContextParameters)
                    foreach (var ctxName in query.Meta.WhereContextParameters.Keys)
                    {
                        string commandName = $"{_entity.EntityName}{ctxName}Command";
                        string methodName = $"{_entity.EntityName}{ctxName}Query";
                        sb.AppendLine($"        public QueryModel {methodName}(Command.Read.{commandName} Command)");
                        sb.AppendLine("        {");
                        sb.AppendLine($"            this.Query = \"{query.Meta.SqlBase}\";");
                        sb.AppendLine("            var whereClauses = new List<string>();");
                        sb.AppendLine("            dynamic parameters = new ExpandoObject();");
                        sb.AppendLine("            var dict = (IDictionary<string, object>)parameters;");
                        foreach (var cond in query.Meta.WhereContextParameters[ctxName])
                        {
                            sb.AppendLine("");
                            string param = cond.Field;
                            string rightExpr = cond.RightExpression;


                            // Ajuste de acordo com o tipo do campo
                            var typeCode = Type.GetTypeCode(cond.FieldType);
                            switch (typeCode)
                            {
                                case TypeCode.String:
                                    sb.AppendLine($"                dict[\"{param}\"] = $\"{{{rightExpr}}}\";");
                                    sb.AppendLine($"                whereClauses.Add(\"{cond.Prefix}.{param} {cond.Operator} @{param}\");");
                                    break;

                                case TypeCode.Boolean:
                                    sb.AppendLine($"                dict[\"{param}\"] = {rightExpr} ? 1 : 0;");
                                    sb.AppendLine($"                whereClauses.Add(\"{cond.Prefix}.{param} {cond.Operator} @{param}\");");
                                    break;

                                case TypeCode.DateTime:
                                    //sb.AppendLine($"if (Command.{param} != null && Command.{param} {cond.Operator} (DateTime)SqlDateTime.MinValue) parametersDict[\"{param}\"] = Command.{param}.Value;");
                                    //sb.AppendLine($"if (Command.{param} != null && Command.{param} {cond.Operator} (DateTime)SqlDateTime.MinValue) whereClauses.Add($\"{param} = @{param}\");");
                                    break;

                                case TypeCode.Int32:
                                case TypeCode.Double:
                                case TypeCode.Decimal:
                                default:
                                    sb.AppendLine($"                dict[\"{param}\"] = {rightExpr};");
                                    sb.AppendLine($"                whereClauses.Add(\"{cond.Prefix}.{param} {cond.Operator} @{param}\");");
                                    break;
                            }

                        }

                        // Condições fixas
                        sb.AppendLine("");
                        sb.AppendLine("            dict[\"Deleted\"] = 0;");
                        sb.AppendLine("            dict[\"TenantID\"] = _currentUser.TenantID;");
                        foreach (var prefix in prefixoList)
                        {
                            sb.AppendLine("");
                            sb.AppendLine($"            whereClauses.Add(\"{prefix}.TenantID = @TenantID\");");
                            sb.AppendLine($"            whereClauses.Add(\"{prefix}.Deleted = @Deleted\");");
                        }

                        sb.AppendLine("");
                        // Monta WHERE final
                        sb.AppendLine("            if (whereClauses.Any()) this.Query += $\" WHERE {string.Join(\" AND \", whereClauses)}\";");

                        // Paginação
                        sb.AppendLine("            int page = Command.Paginacao?.Page ?? 1;");
                        sb.AppendLine("            int pageSize = Command.Paginacao?.PageSize ?? 20;");
                        sb.AppendLine("            int offset = (page - 1) * pageSize;");
                        sb.AppendLine("            dict[\"Offset\"] = offset;");
                        sb.AppendLine("            dict[\"PageSize\"] = pageSize;");
                        sb.AppendLine("            Query += \" ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY\"; ");


                        sb.AppendLine("            this.Parameters = parameters;");
                        sb.AppendLine("            return new QueryModel(this.Query, this.Parameters);");
                        sb.AppendLine("        }");
                    }

                    // ---- Where queries (WhereParameters)
                    foreach (var wh in query.Meta.WhereParameters)
                    {
                        string methodName = $"{_entity.EntityName}{wh.Key}Query";
                        string commandName = $"{_entity.EntityName}{wh.Key}Command";

                        sb.AppendLine($"        public QueryModel {methodName}(Command.Read.{commandName} Command)");
                        sb.AppendLine("        {");
                        sb.AppendLine($"            this.Query = \"{query.Meta.SqlBase}\";");
                        sb.AppendLine("            var whereClauses = new List<string>();");
                        sb.AppendLine("            dynamic parameters = new ExpandoObject();");
                        sb.AppendLine("            var dict = (IDictionary<string, object>)parameters;");

                        foreach (var cond in wh.Value)
                        {
                            sb.AppendLine("");
                            string param = cond.Field;
                            sb.AppendLine($"            if (Command.{param} != null)");
                            sb.AppendLine("            {");
                            if (cond.Operator == "LIKE")
                            {
                                sb.AppendLine($"                dict[\"{param}\"] = $\"%{{Command.{param}}}%\";");
                                sb.AppendLine($"                whereClauses.Add(\"{cond.Prefix}.{param} LIKE @{param}\");");
                            }
                            else if (Type.GetTypeCode(cond.FieldType) == TypeCode.DateTime)
                            {
                                //sb.AppendLine($"if (Command.{param} != null && Command.{param} {cond.Operator} (DateTime)SqlDateTime.MinValue) parametersDict[\"{param}\"] = Command.{param}.Value;");
                                //sb.AppendLine($"if (Command.{param} != null && Command.{param} {cond.Operator} (DateTime)SqlDateTime.MinValue) whereClauses.Add($\"{param} = @{param}\");");

                            }
                            else
                            {
                                sb.AppendLine($"                dict[\"{param}\"] = Command.{param};");
                                sb.AppendLine($"                whereClauses.Add(\"{cond.Prefix}.{param} {cond.Operator} @{param}\");");
                            }

                            sb.AppendLine("            }");
                        }


                        sb.AppendLine("");
                        sb.AppendLine("            dict[\"Deleted\"] = 0;");
                        sb.AppendLine("            dict[\"TenantID\"] = _currentUser.TenantID;");
                        foreach (var prefix in prefixoList)
                        {
                            sb.AppendLine("");
                            sb.AppendLine($"            whereClauses.Add(\"{prefix}.TenantID = @TenantID\");");
                            sb.AppendLine($"            whereClauses.Add(\"{prefix}.Deleted = @Deleted\");");
                        }
                        // Monta WHERE final
                        sb.AppendLine("            if (whereClauses.Any()) this.Query += $\" WHERE {string.Join(\" AND \", whereClauses)}\";");

                        // Paginação
                        sb.AppendLine("            int page = Command.Paginacao?.Page ?? 1;");
                        sb.AppendLine("            int pageSize = Command.Paginacao?.PageSize ?? 20;");
                        sb.AppendLine("            int offset = (page - 1) * pageSize;");
                        sb.AppendLine("            dict[\"Offset\"] = offset;");
                        sb.AppendLine("            dict[\"PageSize\"] = pageSize;");
                        sb.AppendLine("            Query += \" ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY\"; ");

                        sb.AppendLine("            this.Parameters = parameters;");
                        sb.AppendLine("            return new QueryModel(this.Query, this.Parameters);");
                        sb.AppendLine("        }");
                    }
                }


                sb.AppendLine("    }");
                sb.AppendLine("}");

            }
            return sb;

        }

        private void Parameters(StringBuilder sb, Column colunm, bool suarchFK = false)
        {
            if (colunm.WhereNeedBe)
            {
                if (colunm.ValueDefault.StartsWith("#"))
                    sb.AppendLine($"{(colunm.WhereCanTakeOff && !suarchFK ? $"if (!TakeOff{colunm.Name}) " : "")} parametersDict[\"{colunm.Name}\"] = {colunm.ValueDefault.Substring(1)};");

                else
                    sb.AppendLine($"{(colunm.WhereCanTakeOff && !suarchFK ? $"if (!TakeOff{colunm.Name}) " : "")} parametersDict[\"{colunm.Name}\"] = {colunm.ValueDefault};");

                sb.AppendLine($"{(colunm.WhereCanTakeOff && !suarchFK ? $"if (!TakeOff{colunm.Name}) " : "")} whereClauses.Add($\"{colunm.Name} = @{colunm.Name}\");");
            }
            else
            {
                if (colunm.getCsharpType() == "string")
                {
                    sb.AppendLine($"if (!string.IsNullOrEmpty(Command.{colunm.Name})) parametersDict[\"{colunm.Name}\"] = $\"%{{Command.{colunm.Name}}}%\";");
                    sb.AppendLine($"if (!string.IsNullOrEmpty(Command.{colunm.Name})) whereClauses.Add($\"{colunm.Name} like @{colunm.Name}\");");
                }
                else if (colunm.getCsharpType() == "int")
                {
                    sb.AppendLine($"if (Command.{colunm.Name}.HasValue) parametersDict[\"{colunm.Name}\"] = Command.{colunm.Name}.Value;");
                    sb.AppendLine($"if (Command.{colunm.Name}.HasValue) whereClauses.Add($\"{colunm.Name} = @{colunm.Name}\");");
                }
                else if (colunm.getCsharpType() == "datetime")
                {
                    //sb.AppendLine($"if (Command.{colunm.Name} != null && Command.{colunm.Name} > (DateTime)SqlDateTime.MinValue) parametersDict[\"{colunm.Name}\"] = Command.{colunm.Name}.Value;");
                    //sb.AppendLine($"if (Command.{colunm.Name} != null && Command.{colunm.Name} > (DateTime)SqlDateTime.MinValue) whereClauses.Add($\"{colunm.Name} = @{colunm.Name}\");");
                }
            }
        }
        protected override StringBuilder GenerateCustonCode()
        {
            var sb = new StringBuilder();
            return new StringBuilder();
            // Adiciona o comentário de descrição da entidade
            sb.AppendLine("// " + _entity.EntityDescription);

            // Define a classe
            sb.AppendLine($"public partial class {_entity.EntityName}");
            sb.AppendLine("{");

            // Adiciona as propriedades da entidade
            foreach (var column in _entity.AddColumns)
            {
                sb.AppendLine($"    public {column.getCsharpType()} {column.Name} {{ get; set; }}");
            }

            // Fecha a classe
            sb.AppendLine("}");
            return sb;
        }
    }
}