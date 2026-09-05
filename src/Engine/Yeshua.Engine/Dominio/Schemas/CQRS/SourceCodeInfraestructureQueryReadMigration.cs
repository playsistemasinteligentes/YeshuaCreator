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
                        sb.AppendLine($"    public QueryModel {methodName}({CQRSParam.I.NameSpaceCommandRead}.{_entity.EntityName}{ctxName}Command Command {takeOff});");
                    }

                    // Wheres
                    foreach (var whName in query.Meta.WhereParameters.Keys)
                    {
                        string methodName = $"{_entity.EntityName}{whName}";
                        sb.AppendLine($"    public QueryModel {methodName}Query({CQRSParam.I.NameSpaceCommandRead}.{methodName}Command Command {takeOff});");
                    }
                }

                sb.AppendLine("    }");
                sb.AppendLine("}");

            }
            else
            {
                sb.AppendLine("using Shered.DB;");
                sb.AppendLine("using System.Data.SqlTypes;");
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

                sb.AppendLine($"        protected readonly IExecutionContext _executionContext;");

                sb.AppendLine($"        public {_entity.EntityName}QueryRead(IExecutionContext executionContext)");
                sb.AppendLine("        {");
                sb.AppendLine($"            _executionContext = executionContext;");
                sb.AppendLine("        }");

                sb.AppendLine($"        public QueryModel {_entity.EntityName}Query({CQRSParam.I.NameSpaceCommandRead}.{_entity.EntityName}{CommandType.Read}Command Command {takeOff})");
                sb.AppendLine("        {");
                sb.AppendLine($"            this.Parameters = null;");
                sb.AppendLine($"            var whereClauses = new List<string>();");
                sb.AppendLine($"            dynamic parameters = new ExpandoObject();");
                sb.AppendLine($"            var dict = (IDictionary<string, object>)parameters;");


                var sourceName = GetReadSourceName(_entity);
                var columnsString = BuildReadSelectColumns(_entity, _entity.AddColumns);
                sb.AppendLine($"            this.Query = $@\" select {columnsString} from {sourceName} \";");


                foreach (var item in _entity.AddColumns.Where(x => !x.IsBackEndField))
                    Parameters(sb, item);


                sb.AppendLine("            if (whereClauses.Any()) ");
                sb.AppendLine("                 this.Query += $\" WHERE {string.Join(\" AND \", whereClauses)}\"; ");

                // Paginação
                sb.AppendLine("            int page = Command.Paginacao?.Page ?? 1;");
                sb.AppendLine("            int pageSize = Command.Paginacao?.PageSize ?? 20;");
                sb.AppendLine("            int offset = (page - 1) * pageSize;");
                sb.AppendLine("            dict[\"Offset\"] = offset;");
                sb.AppendLine("            dict[\"PageSize\"] = pageSize;");
                var orderColumnModel = _entity.AddColumns.FirstOrDefault(x => x.IsKey && !x.IsBackEndField)
                    ?? _entity.AddColumns.First(x => !x.IsBackEndField);
                var orderColumn = GetReadSqlColumn(_entity, orderColumnModel);
                sb.AppendLine($"            Query += \" ORDER BY {orderColumn} OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY\"; ");

                sb.AppendLine($"            this.Parameters = parameters;");
                sb.AppendLine("            return new QueryModel(this.Query, this.Parameters);");
                sb.AppendLine("        }");


                foreach (var column in _entity.AddColumns.Where(x => x.IsFK && !x.IsBackEndField))
                {
                    sb.AppendLine($"        public QueryModel {_entity.EntityName}{column.Name}Query({CQRSParam.I.NameSpaceCommandPatterns}.SearchFKCommand Command {takeOff})");
                    sb.AppendLine("        {");

                    columnsString = BuildReadSelectColumns(column.EntityFK, column.EntityFK.AddColumns.Where(x => x.DisplayFK));
                    var fkSourceName = GetReadSourceName(column.EntityFK);
                    var fkReferenceColumn = column.EntityFK.AddColumns.FirstOrDefault(x => x.Name == column.ColumnReference);
                    var fkReferenceSqlColumn = fkReferenceColumn == null ? column.ColumnReference : GetReadSqlColumn(column.EntityFK, fkReferenceColumn);
                    sb.AppendLine($"            this.Query = $@\" select {columnsString} from {fkSourceName} \";");
                    sb.AppendLine($"            this.Parameters = null;");
                    sb.AppendLine($"            var whereClauses = new List<string>();");
                    sb.AppendLine($"            dynamic parameters = new ExpandoObject();");
                    sb.AppendLine($"            var dict = (IDictionary<string, object>)parameters;");

                    sb.AppendLine("            if (!string.IsNullOrEmpty(Command.searchFK)) ");
                    sb.AppendLine("            {");
                    sb.AppendLine("                 if (int.TryParse(Command.searchFK, out int numero)) ");
                    sb.AppendLine("                 {");

                    sb.AppendLine($"                      dict[\"{column.ColumnReference}\"] = numero; //01");
                    sb.AppendLine($"                      whereClauses.Add($\" {fkReferenceSqlColumn} = @{column.ColumnReference}\");//01 ");

                    sb.AppendLine("                 }");
                    sb.AppendLine("                 else ");
                    sb.AppendLine("                 {");

                    foreach (var item in column.EntityFK.AddColumns.Where(x => x.DisplayFK))
                    {
                        sb.AppendLine($"                      dict[\"{item.Name}\"] = $\"%{{Command.searchFK}}%\";//02 ");
                        var displaySqlColumn = GetReadSqlColumn(column.EntityFK, item);
                        sb.AppendLine($"                      whereClauses.Add($\" {displaySqlColumn} like @{item.Name} \");//02");
                    }
                    sb.AppendLine("                 }");
                    sb.AppendLine("           }");
                    foreach (var item in column.EntityFK.AddColumns.Where(x => x.WhereNeedBe))
                        Parameters(sb, item, true, column.EntityFK);

                    if (!string.IsNullOrEmpty(column.ClausesWhere))
                        sb.AppendLine($"                      whereClauses.Add(\" {column.ClausesWhere} \"); //03");

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
                    sb.AppendLine($"            var dict = (IDictionary<string, object>)parameters;");
                    sb.AppendLine($"            this.Query = $\"SELECT 1 FROM {GetReadSourceName(_entity)} \";");

                    foreach (var item in _entity.AddColumns.Where(x => x.WhereNeedBe))
                        Parameters(sb, item);


                    sb.AppendLine($"                      dict[\"{column.Name}\"] = value; //04");
                    sb.AppendLine($"                      whereClauses.Add($\" {GetReadSqlColumn(_entity, column)} = @{column.Name} \");//04");
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
                    sb.AppendLine($"            var dict = (IDictionary<string, object>)parameters;");

                    sb.AppendLine($"            this.Query = $\"SELECT {BuildReadSelectColumns(_entity, _entity.AddColumns)} FROM {GetReadSourceName(_entity)} \";");
                    foreach (var item in _entity.AddColumns.Where(x => x.WhereNeedBe))
                        Parameters(sb, item);

                    sb.AppendLine($"                      dict[\"{column.Name}\"] = value; //06");
                    sb.AppendLine($"                      whereClauses.Add($\" {GetReadSqlColumn(_entity, column)} = @{column.Name} \");//06");
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
                        sb.AppendLine($"        public QueryModel {methodName}(Command.Read.{commandName} Command {takeOff})");
                        sb.AppendLine("        {");
                        sb.AppendLine($"            this.Query = \"{query.Meta.SqlBase}\";");
                        sb.AppendLine("            var whereClauses = new List<string>();");
                        sb.AppendLine("            dynamic parameters = new ExpandoObject();");
                        sb.AppendLine("            var dict = (IDictionary<string, object>)parameters;");
                        int indexParam = 0;
                        foreach (var cond in query.Meta.WhereContextParameters[ctxName])
                        {
                            indexParam++;
                            sb.AppendLine("");
                            string param = $"{cond.Field}_{indexParam}";
                            string rightExpr = cond.RightExpression;


                            // Ajuste de acordo com o tipo do campo
                            var typeCode = Type.GetTypeCode(cond.FieldType);
                            switch (typeCode)
                            {
                                case TypeCode.String:
                                    sb.AppendLine($"                dict[\"{param}\"] = $\"{{{rightExpr}}}\";");
                                    sb.AppendLine($"                whereClauses.Add(\"{cond.Prefix}.{cond.Field} {cond.Operator} @{param}\");//07");
                                    break;

                                case TypeCode.Boolean:
                                    sb.AppendLine($"                dict[\"{param}\"] = {rightExpr} ? 1 : 0;");
                                    sb.AppendLine($"                whereClauses.Add(\"{cond.Prefix}.{cond.Field} {cond.Operator} @{param}\");//07");
                                    break;

                                case TypeCode.DateTime:
                                    sb.AppendLine($"                dict[\"{param}\"] = {rightExpr};");
                                    sb.AppendLine($"                whereClauses.Add(\"{cond.Prefix}.{cond.Field} {cond.Operator} @{param}\");//07");
                                    break;

                                case TypeCode.Int32:
                                case TypeCode.Double:
                                case TypeCode.Decimal:
                                default:
                                    sb.AppendLine($"                dict[\"{param}\"] = {rightExpr};");
                                    sb.AppendLine($"                whereClauses.Add(\"{cond.Prefix}.{cond.Field} {cond.Operator} @{param}\");//07");
                                    break;
                            }

                        }

                        // Condições fixas
                        if (string.IsNullOrWhiteSpace(takeOff))
                        {
                            sb.AppendLine("");
                            sb.AppendLine("            dict[\"Deleted\"] = 0;");
                            sb.AppendLine("            dict[\"TenantID\"] = _executionContext.TenantID;");
                            foreach (var prefix in prefixoList)
                            {
                                sb.AppendLine("");
                                sb.AppendLine($"            whereClauses.Add(\"{prefix}.TenantID = @TenantID\");");
                                sb.AppendLine($"            whereClauses.Add(\"{prefix}.Deleted = @Deleted\");");
                            }
                        }
                        else
                        {
                            sb.AppendLine("");
                            sb.AppendLine("            dict[\"Deleted\"] = 0;");
                            sb.AppendLine("            if (!TakeOffTenantID) dict[\"TenantID\"] = _executionContext.TenantID;");

                            foreach (var prefix in prefixoList)
                            {
                                sb.AppendLine("");
                                sb.AppendLine($"            if (!TakeOffTenantID) whereClauses.Add(\"{prefix}.TenantID = @TenantID\");");
                                sb.AppendLine($"            whereClauses.Add(\"{prefix}.Deleted = @Deleted\");");
                            }
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

                        sb.AppendLine($"        public QueryModel {methodName}(Command.Read.{commandName} Command {takeOff})");
                        sb.AppendLine("        {");
                        sb.AppendLine($"            this.Query = \"{query.Meta.SqlBase}\";");
                        sb.AppendLine("            var whereClauses = new List<string>();");
                        sb.AppendLine("            dynamic parameters = new ExpandoObject();");
                        sb.AppendLine("            var dict = (IDictionary<string, object>)parameters;");

                        int indexParam = 0;
                        foreach (var cond in wh.Value)
                        {
                            sb.AppendLine("");

                            if (cond.Column.Enum != null)
                            {
                                EnumParameters(sb, cond.Column);
                                continue;
                            }



                            string param = $"{cond.Field}_{indexParam}";

                            if (cond.Operator == "LIKE")
                            {
                                sb.AppendLine($"            if (Command.{cond.Field} != null)");
                                sb.AppendLine("            {");
                                sb.AppendLine($"                dict[\"{param}\"] = $\"%{{Command.{cond.Field}}}%\";");
                                sb.AppendLine($"                whereClauses.Add(\"{cond.Prefix}.{cond.Field} LIKE @{param}\");//08");
                            }
                            else if (Type.GetTypeCode(cond.FieldType) == TypeCode.DateTime)
                            {

                                sb.AppendLine($"            if (Command.{cond.Field} != null  && Command.DataFim > (DateTime)SqlDateTime.MinValue)");
                                sb.AppendLine("            {");
                                sb.AppendLine($"                dict[\"{param}\"] = Command.{cond.Field};");
                                sb.AppendLine($"                whereClauses.Add(\"{cond.Prefix}.{cond.Field} {cond.Operator} @{param}\");//08");
                            }
                            else
                            {
                                sb.AppendLine($"            if (Command.{cond.Field} != null)");
                                sb.AppendLine("            {");
                                sb.AppendLine($"                dict[\"{param}\"] = Command.{cond.Field};");
                                sb.AppendLine($"                whereClauses.Add(\"{cond.Prefix}.{cond.Field} {cond.Operator} @{param}\");//08");
                            }

                            sb.AppendLine("            }");
                        }


                        sb.AppendLine("");
                        sb.AppendLine("            dict[\"Deleted\"] = 0;");
                        sb.AppendLine("            dict[\"TenantID\"] = _executionContext.TenantID;");
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

        private void EnumParameters(StringBuilder sb, Column colunm)
        {
            if (colunm.Enum != null && colunm.Enum.Count() > 0)
            {
                sb.AppendLine($"if (Command.{colunm.Name} != null && Command.{colunm.Name}.Any())");
                sb.AppendLine("{");
                sb.AppendLine($"    var paramList_{colunm.Name} = new List<string>();");
                sb.AppendLine($"    for (int i = 0; i < Command.{colunm.Name}.Count; i++)");
                sb.AppendLine("    {");
                sb.AppendLine($"        string paramName = \"{colunm.Name}_\" + i;");
                sb.AppendLine($"        dict[paramName] = Command.{colunm.Name}[i];");
                sb.AppendLine($"        paramList_{colunm.Name}.Add(\"@\" + paramName);");
                sb.AppendLine("    }");
                sb.AppendLine($"    whereClauses.Add($\"t0.{colunm.Name} IN ({{string.Join(\", \", paramList_{colunm.Name})}})\");");
                sb.AppendLine("}");
            }
        }
        private string GetReadSourceName(Entity entity)
        {
            var sourceName = entity.IsFromView ? entity.ViewSourceName : entity.EntityName;
            return SqlIdentifier(sourceName);
        }

        private string GetReadSqlColumn(Entity entity, Column column)
        {
            var columnName = entity.IsFromView && column.HasLegacyColumn ? column.LegacyColumnName : column.Name;
            return SqlIdentifier(columnName);
        }

        private string BuildReadSelectColumns(Entity entity, IEnumerable<Column> columns)
        {
            return string.Join(", ", columns.Select(column =>
            {
                var sqlColumnName = entity.IsFromView && column.HasLegacyColumn ? column.LegacyColumnName : column.Name;
                var sqlColumn = SqlIdentifier(sqlColumnName);
                var columnAlias = SqlIdentifier(column.Name);
                return sqlColumnName == column.Name ? columnAlias : $"{sqlColumn} AS {columnAlias}";
            }));
        }

        private static string SqlIdentifier(string name)
        {
            return string.Join(".", name.Split('.').Select(part => $"[{part.Replace("]", "]]")}]"));
        }

        private void Parameters(StringBuilder sb, Column colunm, bool suarchFK = false, Entity sourceEntity = null)
        {
            var sqlColumnName = GetReadSqlColumn(sourceEntity ?? _entity, colunm);
            if (colunm.WhereNeedBe)
            {
                if (colunm.ValueDefault.StartsWith("#"))
                    sb.AppendLine($"{(colunm.WhereCanTakeOff && !suarchFK ? $"if (!TakeOff{colunm.Name}) " : "")} dict[\"{colunm.Name}\"] = {colunm.ValueDefault.Substring(1)};");

                else
                    sb.AppendLine($"{(colunm.WhereCanTakeOff && !suarchFK ? $"if (!TakeOff{colunm.Name}) " : "")} dict[\"{colunm.Name}\"] = {colunm.ValueDefault};");

                sb.AppendLine($"{(colunm.WhereCanTakeOff && !suarchFK ? $"if (!TakeOff{colunm.Name}) " : "")} whereClauses.Add($\"{sqlColumnName} = @{colunm.Name}\");");
            }
            else
            {

                if (colunm.Enum != null && colunm.Enum.Count() > 0)
                {
                    EnumParameters(sb, colunm);
                }
                else if (colunm.getCsharpType() == "string")
                {
                    sb.AppendLine($"if (!string.IsNullOrEmpty(Command.{colunm.Name})) dict[\"{colunm.Name}\"] = $\"%{{Command.{colunm.Name}}}%\";");
                    sb.AppendLine($"if (!string.IsNullOrEmpty(Command.{colunm.Name})) whereClauses.Add($\"{sqlColumnName} like @{colunm.Name}\");");
                }
                else if (colunm.getCsharpType() == "int")
                {
                    sb.AppendLine($"if (Command.{colunm.Name}.HasValue) dict[\"{colunm.Name}\"] = Command.{colunm.Name}.Value;");
                    sb.AppendLine($"if (Command.{colunm.Name}.HasValue) whereClauses.Add($\"{sqlColumnName} = @{colunm.Name}\");");
                }
                else if (colunm.getCsharpType() == "datetime")
                {
                    //sb.AppendLine($"if (Command.{colunm.Name} != null && Command.{colunm.Name} > (DateTime)SqlDateTime.MinValue) dict[\"{colunm.Name}\"] = Command.{colunm.Name}.Value;");
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
