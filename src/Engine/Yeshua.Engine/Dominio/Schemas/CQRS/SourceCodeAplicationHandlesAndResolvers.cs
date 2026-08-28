
using Migration.Dominio;
using System.Text;
using Migration.Dominio.Schemas.CQRS;
using static Dapper.SqlMapper;
using System.Reflection;


namespace Dominio.Schemas.CQRS
{
    public class SourceCodeAplicationHandlesAndResolvers : SourceCodeBase
    {
        private UseCaseGroup _useCaseGroup;
        private CommandType _commandType;
        private UseCaseSubGroup _useCaseSubGroup;
        private UseCaseCommand _useCase;
        private string _nameSpace;
        private string _nameSpaceCommand;
        private List<SagaStep> _steps;
        private List<Dominio.Saga.Migration.Saga> _sagas;
        private SagaStep _step;
        private Dominio.Saga.Migration.Saga _saga;



        private Strategy _strategy;
        private Type _type;
        private ExportPathsSourceCodeAplicationCommandReceiversUseCase _exportPath;

        public SourceCodeAplicationHandlesAndResolvers(UseCaseGroup hub)
            : base()
        {
            _useCaseGroup = hub;
            _nameSpace = CQRSParam.I.NameSpaceCommandReceiversHub;
            _commandType = CommandType.UseCaseGroup;
        }
        public SourceCodeAplicationHandlesAndResolvers(List<Dominio.Saga.Migration.Saga> sagas)
                    : base()
        {
            _sagas = sagas;
            _nameSpace = CQRSParam.I.SagaResolverRegistry;
            _commandType = CommandType.SagaResolverRegistry;
        }
        public SourceCodeAplicationHandlesAndResolvers(Dominio.Saga.Migration.Saga saga, SagaStep step): base()
        {
            _step = step;
            _nameSpace = CQRSParam.I.NameSpaceSagaHandler;
            _commandType = CommandType.SagaStepHandler;
            _saga = saga;

        }

        public SourceCodeAplicationHandlesAndResolvers(Dominio.Saga.Migration.Saga saga, CommandType commandType) : base()
        {
            _nameSpace = CQRSParam.I.NameSpaceSagaHandler;
            _commandType = commandType;
            _saga = saga;
        }

        public SourceCodeAplicationHandlesAndResolvers(Dominio.Saga.Migration.Saga saga, List<SagaStep> steps) : base()
        {
            //_useCaseGroup = useCase.UseCaseGroup;
            //_useCaseSubGroup = useCase.UseCaseSubGroup;
            _commandType = CommandType.SagaHandlerResolver;
            //_useCase = useCase;
            _steps = steps;
            _saga = saga;
            _nameSpace = CQRSParam.I.NameSpaceSagaHandlerResolver;
            //_nameSpaceCommand = CQRSParam.I.NameSpaceCommandCommandsUseCases;
        }
        

        public SourceCodeAplicationHandlesAndResolvers(UseCaseCommand useCase, CommandType commandType)
            : base()
        {
            _useCaseGroup = useCase.UseCaseGroup;
            _useCaseSubGroup = useCase.UseCaseSubGroup;
            _commandType = commandType;
            _useCase = useCase;

            _nameSpace = CQRSParam.I.NameSpaceCommandCommandsSaga;
            if (commandType == CommandType.UseCaseCommandHandler)
                _nameSpace = CQRSParam.I.NameSpaceCommandReceiversUseCase;
            else if (commandType == CommandType.SagaResolverRegistry)
                _nameSpace = CQRSParam.I.SagaResolverRegistry;
            else if (commandType == CommandType.SagaHandlerResolver)
                _nameSpace = CQRSParam.I.NameSpaceSagaHandlerResolver;
            else if (commandType == CommandType.SagaStepHandler)
                _nameSpace = CQRSParam.I.NameSpaceSagaHandler;
            

            _nameSpaceCommand = CQRSParam.I.NameSpaceCommandCommandsUseCases;
        }
        public SourceCodeAplicationHandlesAndResolvers(UseCaseCommand useCase, Strategy strategy, ExportPathsSourceCodeAplicationCommandReceiversUseCase exportPath, ref List<CodigoGerado> CodigoGerado, CommandType commandType)
            : base()
        {
            _strategy = strategy;
            _type = strategy.Type;
            _useCaseGroup = useCase.UseCaseGroup;
            _useCaseSubGroup = useCase.UseCaseSubGroup;
            _commandType = commandType;
            _useCase = useCase;
            _nameSpace = CQRSParam.I.NameSpaceCommandCommandsSaga;
            if (commandType == CommandType.UseCaseCommandHandler)
                _nameSpace = CQRSParam.I.NameSpaceCommandReceiversUseCase;
            _nameSpaceCommand = CQRSParam.I.NameSpaceCommandCommandsUseCases;
            _exportPath = exportPath;

            CodigoGerado = new List<CodigoGerado>();

            CodigoGerado.AddRange(TypeExporter.ExportFromRootInterface(_strategy.Type, _exportPath));

            CodigoGerado.AddRange(TypeExporter.ExportTypes(_strategy.StrategyAgregate, _exportPath));

        }

        protected override StringBuilder GenerateCode()
        {
            StringBuilder sb = new StringBuilder();
            
            if (_type != null)
            {
                return sb;
            }


            if (_commandType == CommandType.SagaBase)
            {
                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioPatternsSaga};");
                sb.AppendLine();

                sb.AppendLine($"namespace {CQRSParam.I.NameSpaceDominioSaga}");
                sb.AppendLine("{");

                if (_saga != null)
                {
                    var sagaCommand = new UseCaseCommand(_saga.Name.ToString());
                    var sagaName = $"{sagaCommand.Name.SourceType()}Saga";

                    sb.AppendLine($"    public class {sagaName} : SagaBase");
                    sb.AppendLine("    {");

                    // 🔥 CONSTANTES STEP_X
                    if (_saga.SagaStepGroup != null)
                    {
                        foreach (var group in _saga.SagaStepGroup)
                        {
                            foreach (var step in group.Steps)
                            {
                                sb.AppendLine($"        public const string STEP_{step.Orden} = \"{step.Name.SourceType()}\";");
                            }
                        }
                    }

                    sb.AppendLine();

                    // 🔥 CONSTRUTOR
                    sb.AppendLine($"        public {sagaName}()");
                    sb.AppendLine("        {");

                    if (_saga.SagaStepGroup != null)
                    {
                        foreach (var group in _saga.SagaStepGroup)
                        {
                            foreach (var step in group.Steps)
                            {
                                var stepClassName = $"{sagaCommand.Name.SourceType()}Step";

                                // 🔥 AGORA COM ORDEM EXPLÍCITA
                                sb.AppendLine($"            AddStep(new {stepClassName}(STEP_{step.Orden}, {step.Orden}));");
                            }
                        }
                    }

                    sb.AppendLine("        }");

                    sb.AppendLine("    }");
                }
                else
                {
                    sb.AppendLine("    // Saga não informada");
                }

                sb.AppendLine("}");

                return sb;
            }
            else if (_commandType == CommandType.SagaStepBase)
            {
                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioPatternsSaga};");
                sb.AppendLine();

                sb.AppendLine($"namespace {CQRSParam.I.NameSpaceDominioSaga}");
                sb.AppendLine("{");

                if (_saga != null)
                {
                    var sagaCommand = new UseCaseCommand(_saga.Name.ToString());

                    var stepClassName = $"{sagaCommand.Name.SourceType()}Step";

                    sb.AppendLine($"    public class {stepClassName} : SagaStepBase");
                    sb.AppendLine("    {");

                    sb.AppendLine($"        public {stepClassName}(string key, int order) : base(key)");
                    sb.AppendLine("        {");
                    sb.AppendLine("             Key = key;");
                    sb.AppendLine("             SetOrder(order);");
                    sb.AppendLine("        }");

                    sb.AppendLine("    }");
                }
                else
                {
                    sb.AppendLine("    // Saga não informada");
                }

                sb.AppendLine("}");

                return sb;
            }
            else if (_commandType == CommandType.SagaStepHandler)
            {
                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioSaga};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceIRepositoryWrite};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfacePatternsSaga};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioPatternsSaga};");
                sb.AppendLine($"using System;");
                sb.AppendLine();

                sb.AppendLine($"namespace {_nameSpace}");
                sb.AppendLine("{");

                if (_step != null)
                {
                    var sagaComandHandler = new UseCaseCommand(_saga.Name.ToString());

                    var sagaName = $"{sagaComandHandler.Name.SourceType()}Saga";
                    var handlerName = $"{_step.Name.SourceType()}Handler";
                    var stepConst = $"{sagaName}.STEP_{_step.Orden}";

                    sb.AppendLine($"    public partial class {handlerName} : ISagaStepHandler");
                    sb.AppendLine("    {");

                    sb.AppendLine($"        public string Key => {stepConst};");
                    sb.AppendLine();
                    sb.AppendLine($"        public bool IsAsync => true;");
                    sb.AppendLine();

                    // =============================
                    // EXECUTE
                    // =============================
                    sb.AppendLine("        public void Execute(SagaBase saga, SagaStepBase step)");
                    sb.AppendLine("        {");
                    sb.AppendLine("            try");
                    sb.AppendLine("            {");

                    sb.AppendLine("                // marca execução");
                    sb.AppendLine("                step.SetInProgress();");
                    sb.AppendLine();

                    sb.AppendLine("                // lógica de domínio");
                    sb.AppendLine("                CustomExecute(saga, step);");
                    sb.AppendLine();

                    sb.AppendLine("                // define próximo estado");
                    sb.AppendLine("                if (IsAsync)");
                    sb.AppendLine("                {");
                    sb.AppendLine("                    step.SetWaiting();");
                    sb.AppendLine("                }");
                    sb.AppendLine("                else");
                    sb.AppendLine("                {");
                    sb.AppendLine("                    step.SetPendingApply();");
                    sb.AppendLine("                }");

                    sb.AppendLine("            }");
                    sb.AppendLine("            catch (Exception ex)");
                    sb.AppendLine("            {");
                    sb.AppendLine("                saga.MarkFailed(ex.Message);");
                    sb.AppendLine("                throw;");
                    sb.AppendLine("            }");
                    sb.AppendLine("        }");
                    sb.AppendLine();

                    // =============================
                    // APPLY RESPONSE
                    // =============================
                    sb.AppendLine("        public void ApplyResponse(SagaBase saga, SagaStepBase step, string payload)");
                    sb.AppendLine("        {");
                    sb.AppendLine("            try");
                    sb.AppendLine("            {");

                    sb.AppendLine("                // aplica no domínio");
                    sb.AppendLine("                CustomApplyResponse(saga, step, payload);");
                    sb.AppendLine();

                    sb.AppendLine("            }");
                    sb.AppendLine("            catch (Exception ex)");
                    sb.AppendLine("            {");
                    sb.AppendLine("                saga.MarkFailed(ex.Message);");
                    sb.AppendLine("                throw;");
                    sb.AppendLine("            }");
                    sb.AppendLine("        }");
                    sb.AppendLine();

                    // =============================
                    // EXTENSÕES
                    // =============================
                    sb.AppendLine("        partial void CustomExecute(SagaBase saga, SagaStepBase step);");
                    sb.AppendLine("        partial void CustomApplyResponse(SagaBase saga, SagaStepBase step, string payload);");

                    sb.AppendLine("    }");
                }
                else
                {
                    sb.AppendLine("    // Step não informado");
                }

                sb.AppendLine("}");

            }
            else if (_commandType == CommandType.SagaHandlerResolver)
            {
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfacePatternsSaga};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioSaga};");
                sb.AppendLine("using System;");
                sb.AppendLine("using System.Collections.Generic;");
                sb.AppendLine();

                sb.AppendLine($"namespace {_nameSpace}");
                sb.AppendLine("{");

                var sagaName = $"{_saga.Name}Saga";
                var resolverName = $"{sagaName}HandlerResolver";

                sb.AppendLine($"    public class {resolverName} : ISagaHandlerResolver");
                sb.AppendLine("    {");


                // 🔥 CAMPOS PRIVADOS (handlers)
                if (_steps != null && _steps.Any())
                {
                    foreach (var step in _steps)
                    {
                        var handlerName = $"{step.Name.SourceType()}Handler";
                        var paramName = step.Name.SourceType() + "Handler";

                        sb.AppendLine($"        private readonly {handlerName} _{paramName};");
                    }
                }

                sb.AppendLine();


                // 🔥 CONSTRUTOR COM DI
                sb.Append("        public " + resolverName + "(");

                if (_steps != null && _steps.Any())
                {
                    for (int i = 0; i < _steps.Count; i++)
                    {
                        var step = _steps[i];
                        var handlerName = $"{step.Name.SourceType()}Handler";
                        var paramName = step.Name.SourceType() + "Handler";

                        sb.Append($"{handlerName} {paramName}");

                        if (i < _steps.Count - 1)
                            sb.Append(", ");
                    }
                }

                sb.AppendLine(")");
                sb.AppendLine("        {");

                if (_steps != null && _steps.Any())
                {
                    foreach (var step in _steps)
                    {
                        var paramName = step.Name.SourceType() + "Handler";
                        sb.AppendLine($"            _{paramName} = {paramName};");
                    }
                }

                sb.AppendLine("        }");
                sb.AppendLine();


                // 🔥 GET HANDLERS
                sb.AppendLine("        public Dictionary<string, ISagaStepHandler> GetHandlers()");
                sb.AppendLine("        {");
                sb.AppendLine("            return new Dictionary<string, ISagaStepHandler>");
                sb.AppendLine("            {");

                if (_steps != null && _steps.Any())
                {
                    foreach (var step in _steps)
                    {
                        var handlerName = $"{step.Name.SourceType()}Handler";
                        var paramName = step.Name.SourceType() + "Handler";
                        var stepConst = $"{sagaName}.STEP_{step.Orden}";

                        sb.AppendLine($"                {{ {stepConst}, _{paramName} }},");
                    }
                }
                else
                {
                    sb.AppendLine("                // Nenhum step configurado");
                }

                sb.AppendLine("            };");
                sb.AppendLine("        }");

                sb.AppendLine("    }");
                sb.AppendLine("}");
            }
            else if (_commandType == CommandType.SagaResolverRegistry)
            {
                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioSaga};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfacePatternsSaga};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioPatternsSaga};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceRepositorioOutputs};");

                sb.AppendLine("using System;");
                sb.AppendLine("using System.Collections.Generic;");
                sb.AppendLine("using System.Linq;");
                sb.AppendLine();

                sb.AppendLine($"namespace {_nameSpace}");
                sb.AppendLine("{");

                sb.AppendLine("    public class SagaResolverRegistry : ISagaResolverRegistry");
                sb.AppendLine("    {");

                sb.AppendLine("        private readonly Dictionary<string, ISagaHandlerResolver> _resolverMap;");
                sb.AppendLine("        private readonly Dictionary<string, Func<SagaBase>> _factoryMap;");
                sb.AppendLine();


                // 🔥 CONSTRUTOR DINÂMICO COM DI
                // pendencia: revisar a DSL para definir quais sagas pertencem ao Studio ativo antes de montar o registry; hoje o registry assume contexto global.
                sb.Append("        public SagaResolverRegistry(");

                for (int i = 0; i < _sagas.Count; i++)
                {
                    var saga = _sagas[i];
                    var sagaName = $"{saga.Name}Saga";
                    var resolverName = $"{sagaName}HandlerResolver";
                    var paramName = saga.Name.SourceType() + "Resolver";

                    sb.Append($"{resolverName} {paramName}");

                    if (i < _sagas.Count - 1)
                        sb.Append(", ");
                }

                sb.AppendLine(")");
                sb.AppendLine("        {");

                // 🔥 RESOLVER MAP
                sb.AppendLine("            _resolverMap = new Dictionary<string, ISagaHandlerResolver>");
                sb.AppendLine("            {");

                foreach (var saga in _sagas)
                {
                    var sagaName = $"{saga.Name}Saga";
                    var paramName = saga.Name.SourceType() + "Resolver";

                    sb.AppendLine($"                {{ nameof({sagaName}), {paramName} }},");
                }

                sb.AppendLine("            };");
                sb.AppendLine();

                // 🔥 FACTORY MAP
                sb.AppendLine("            _factoryMap = new Dictionary<string, Func<SagaBase>>");
                sb.AppendLine("            {");

                foreach (var saga in _sagas)
                {
                    var sagaName = $"{saga.Name}Saga";

                    sb.AppendLine($"                {{ nameof({sagaName}), () => new {sagaName}() }},");
                }

                sb.AppendLine("            };");

                sb.AppendLine("        }");
                sb.AppendLine();


                // 🔥 RESOLVE
                sb.AppendLine("        public ISagaHandlerResolver Resolve(SagaBase saga)");
                sb.AppendLine("        {");
                sb.AppendLine("            var key = saga.Type;");
                sb.AppendLine();
                sb.AppendLine("            if (!_resolverMap.TryGetValue(key, out var resolver))");
                sb.AppendLine("                throw new Exception($\"Resolver não encontrado para {key}\");");
                sb.AppendLine();
                sb.AppendLine("            return resolver;");
                sb.AppendLine("        }");
                sb.AppendLine();


                // 🔥 CREATE
                sb.AppendLine("        public SagaBase Create(string type)");
                sb.AppendLine("        {");
                sb.AppendLine("            if (!_factoryMap.TryGetValue(type, out var factory))");
                sb.AppendLine("                throw new Exception($\"Saga não registrada: {type}\");");
                sb.AppendLine();
                sb.AppendLine("            return factory();");
                sb.AppendLine("        }");
                sb.AppendLine();


                // 🔥 MAP
                sb.AppendLine("        public SagaBase Map(ySagaDTO dto)");
                sb.AppendLine("        {");
                sb.AppendLine("            var saga = Create(dto.type);");
                sb.AppendLine();
                sb.AppendLine("            saga.Id = dto.id;");
                sb.AppendLine("            saga.SetCorrelationId(dto.correlationid);");
                sb.AppendLine("            saga.SetStatus(dto.status);");
                sb.AppendLine("            saga.Type = dto.type;");
                sb.AppendLine("            saga.KeyCurrentStep = dto.keycurrentstep;");
                sb.AppendLine("            saga.CreatedAt = dto.createdat;");
                sb.AppendLine("            saga.CompletedAt = dto.completedat;");
                sb.AppendLine("            saga.EntityType = dto.entitytype;");
                sb.AppendLine("            saga.EntityId = dto.entityid;");
                sb.AppendLine();

                sb.AppendLine("            if (dto.Steps != null && dto.Steps.Any())");
                sb.AppendLine("            {");
                sb.AppendLine("                foreach (var step in saga.Steps)");
                sb.AppendLine("                {");
                sb.AppendLine("                    var dtoStep = dto.Steps.FirstOrDefault(s => s.stepkey == step.Key);");
                sb.AppendLine();
                sb.AppendLine("                    if (dtoStep == null)");
                sb.AppendLine("                        continue;");
                sb.AppendLine();
                sb.AppendLine("                    step.Hydrate(dtoStep.id, dtoStep.status, dtoStep.correlationid, dtoStep.completedat, dtoStep.retrycount, dtoStep.payload);");
                sb.AppendLine("                }");
                sb.AppendLine("            }");
                sb.AppendLine();
                sb.AppendLine("            return saga;");
                sb.AppendLine("        }");

                sb.AppendLine("    }");
                sb.AppendLine("}");
                return sb;
            }
            else
            {
                // Adiciona os usings

                sb.AppendLine($"// Escopo: {string.Join(",", _useCase.Scopes)}");

                sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandWrite};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceUnitOfWork};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioInterface};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandCommandsUseCases};");

                sb.AppendLine($"using System;");
                sb.AppendLine($"using System.Collections.Generic;");
                sb.AppendLine($"using System.Linq;");
                sb.AppendLine($"using System.Text;");
                sb.AppendLine($"using System.Threading;");
                sb.AppendLine($"using System.Threading.Tasks;");
                sb.AppendLine();

                // Adiciona o namespace e a classe
                sb.AppendLine($"namespace {_nameSpace}");
                sb.AppendLine("{");

                sb.AppendLine($"    public partial class {_useCase.HandlerName} : ReciverBase< {_useCase.InputCommandName}, {_useCase.OutputCommandName}>");
                sb.AppendLine("    {");
                sb.AppendLine();

                sb.AppendLine("		   private readonly Dominio.Interfaces.ILogger _logger;");
                sb.AppendLine("        private readonly Aplication.Interfaces.Services.IExecutionContext _executionContext;");


                sb.AppendLine($"        public {_useCase.HandlerName}(");
                sb.AppendLine($"            Dominio.Interfaces.ILogger logger,");
                sb.AppendLine($"            Aplication.Interfaces.Services.IExecutionContext context)");
                sb.AppendLine($"            : base(logger, context)");
                sb.AppendLine("        {");
                sb.AppendLine("            _logger = logger;");
                sb.AppendLine("            _executionContext = context;");
                sb.AppendLine("        }");
                sb.AppendLine();

                sb.AppendLine();
                sb.AppendLine($"        protected override async Task<State<{_useCase.OutputCommandName}>> ActionAsync({_useCase.InputCommandName} comand, CancellationToken cancellationToken = default)");
                sb.AppendLine("        {");
                sb.AppendLine("            try");
                sb.AppendLine("            {");
                // chamar o custon receiver

                sb.AppendLine($"                 State<{_useCase.OutputCommandName}> retorno = Success(\"OK\", null);");


                sb.AppendLine("                 return await CustomActionHookAsync(retorno, comand, cancellationToken);");

                sb.AppendLine("            }");

                CQRSParam.I.AddExeptionReceiver(sb, $"{_useCase.OutputCommandName}");

                sb.AppendLine("        }");
                sb.AppendLine($"protected partial Task<State<{_useCase.OutputCommandName}>> CustomActionHookAsync(State<{_useCase.OutputCommandName}> state, {_useCase.InputCommandName} comand, CancellationToken cancellationToken);");
                sb.AppendLine("}");
                //foreach (var menu in _agent.Menus)
                //{
                //    sb.AppendLine($"           private List<string> {menu.Name.SourceType()}()");
                //    sb.AppendLine("            {");
                //    sb.AppendLine("                 return new List<string>() {");

                //    List<string> lista = new List<string>();
                //    lista.AddRange(menu.SubMenus.Select(x => x.Name.SourceType()));
                //    lista.AddRange(menu.Options.Select(x => x.Value.SourceType()));
                //    sb.AppendLine($"{string.Join(",", lista.Select(m => "\"" + m + "\""))}");
                //    sb.AppendLine("                ");
                //    sb.AppendLine("                 };");
                //    sb.AppendLine("            }");
                //}
                //sb.AppendLine("    }");




                //foreach (var menu in _agent.Menus)
                //{
                //    // Nome do enum baseado no menu
                //    string enumName = $"{menu.Name.SourceType()}";
                //    sb.AppendLine($"public enum {enumName}");
                //    sb.AppendLine("{");

                //    int id = 0; // Inicia um contador para os IDs

                //    // Adiciona submenus e opções ao enum
                //    List<string> lista = new List<string>();
                //    lista.AddRange(menu.SubMenus.Select(x => x.Name.SourceType()));
                //    lista.AddRange(menu.Options.Select(x => x.Value.SourceType()));

                //    foreach (var item in lista)
                //    {
                //        sb.AppendLine($"    {item} = {id},"); // Atribui um ID a cada item
                //        id++; // Incrementa o ID
                //    }

                //    sb.AppendLine("}");
                //    sb.AppendLine(); // Adiciona uma linha em branco entre os enums
                //}

                // name space
                sb.AppendLine("}");
            }

            return sb;

        }
        protected override StringBuilder GenerateCustonCode()
        {
            StringBuilder sb = new StringBuilder();
            // Adiciona os usings


            if (_commandType == CommandType.SagaStepHandler)
            {
            }
            else if (_commandType == CommandType.SagaBase)
            {
            }
            else if (_commandType == CommandType.SagaStepBase)
            {
            }
            else if (_commandType == CommandType.SagaHandlerResolver)
            {
            }
            else if (_commandType == CommandType.SagaResolverRegistry)
            { 
            }
            else
            {
                foreach (var scope in _useCase.Scopes)
                    sb.AppendLine($"//scope;");

                sb.AppendLine($"using {CQRSParam.I.NameSpaceDominioInterface};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceIterfaceAplicationServices};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceInterfaceCommandsPartners};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceUnitOfWork};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceIRepositoryRead};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceIRepositoryWrite};");
                sb.AppendLine($"using {CQRSParam.I.NameSpaceCommandCommandsUseCases};");



                sb.AppendLine();

                // Adiciona o namespace e a classe
                sb.AppendLine($"namespace {_nameSpace}");
                sb.AppendLine("{");
                sb.AppendLine($"    public partial class {_useCase.HandlerName}");
                sb.AppendLine("    {");

                //foreach (var scope in _useCase.Scopes)
                //    sb.AppendLine($"private readonly I{scope} _{scope};");

                if (_useCase != null && _useCase.Entitys.Count > 0)
                {
                    sb.AppendLine("        private readonly IUnitOfWork _unitOfWork;");
                    sb.AppendLine("        private readonly IDomainTrackingPolicy _domainTrackingPolicy;");
                    foreach (var entity in _useCase.Entitys)
                    {
                        sb.AppendLine($"        private readonly I{entity.EntityName}ReadRepository _repRead{entity.EntityName};");
                        sb.AppendLine($"        private readonly I{entity.EntityName}WriteRepository _repWrite{entity.EntityName};");
                    }

                    sb.Append($"        public {_useCase.HandlerName}(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy");
                    for (int i = 0; i < _useCase.Entitys.Count; i++)
                    {
                        var entity = _useCase.Entitys[i];
                        sb.Append($",I{entity.EntityName}ReadRepository repRead{entity.EntityName}, I{entity.EntityName}WriteRepository repWrite{entity.EntityName}");
                    }
                    sb.AppendLine(")");
                    sb.AppendLine("            : base(logger, executionContext)");
                    sb.AppendLine("        {");

                    sb.AppendLine($"           _unitOfWork = unitOfWork;");
                    sb.AppendLine($"           _logger = logger;");
                    sb.AppendLine("           _executionContext = executionContext;");
                    sb.AppendLine("           _domainTrackingPolicy = domainTrackingPolicy;");


                    foreach (var entity in _useCase.Entitys)
                    {
                        sb.AppendLine($"            _repRead{entity.EntityName} = repRead{entity.EntityName};");
                        sb.AppendLine($"            _repWrite{entity.EntityName} = repWrite{entity.EntityName};");
                    }
                    sb.AppendLine("        }");
                }


                sb.AppendLine($"protected partial async Task<State<{_useCase.OutputCommandName}>> CustomActionHookAsync(State<{_useCase.OutputCommandName}> state, {_useCase.InputCommandName} comand, CancellationToken cancellationToken)");
                sb.AppendLine("{");
                sb.AppendLine("    return state;");
                sb.AppendLine("}");






                sb.AppendLine("    }");
                sb.AppendLine("}");
            }
            return sb;
        }






        public class ExportPathsSourceCodeAplicationCommandReceiversUseCase
        {

            public string EnumPath { get; set; } = "";
            public string InterfacePath { get; set; } = "";
            public string ClassPath { get; set; } = "";
            public string CustomClassPath { get; set; } = "";
            public string FactoryInterfacePath { get; set; } = "";
            public string FactoryClassPath { get; set; } = "";
            public string DependencyInjectionPath { get; set; } = "";

            public string EnumNamespace { get; set; } = "Dominio.Enum.Strategy";
            public string InterfaceNamespace { get; set; } = "Dominio.Interfaces.Strategy";
            public string ClassNamespace { get; set; } = CQRSParam.I.NameSpaceClassesConcretasStrategy;
            public string CustomClassNamespace { get; set; } = "Shered.Patterns.Strategy";
            public string FactoryInterfaceNamespace { get; set; } = "Dominio.Interfaces.Strategy";
            public string FactoryClassNamespace { get; set; } = "Shered.Patterns.Strategy";
            public string DependencyInjectionNamespace { get; set; } = "Shered.Patterns.Strategy";

        }

        public class CodigoGerado
        {
            public string CaminhoArquivo { get; set; } = string.Empty;
            public StringBuilder Conteudo { get; set; } = new StringBuilder();
            public bool Custom { get; set; } = false;
            public CommandType CommandType { get; set; }

        }

        public static class TypeExporter
        {
            private static readonly HashSet<Type> ProcessedTypes = new();
            private static readonly List<string> AggregatedClassNames = new();
            public static List<CodigoGerado> ExportFromRootInterface(Type rootInterface, ExportPathsSourceCodeAplicationCommandReceiversUseCase paths)
            {
                if (!rootInterface.IsInterface)
                    throw new InvalidOperationException("O tipo inicial deve ser uma interface.");

                List<CodigoGerado> codigos = new();
                ExportTypeRecursive(rootInterface, paths, codigos);

                codigos.AddRange(GenerateDependencyInjectionFile(rootInterface, paths));
                return codigos;
            }
            public static List<CodigoGerado> ExportTypes(IEnumerable<Type> types, ExportPathsSourceCodeAplicationCommandReceiversUseCase paths)
            {
                ProcessedTypes.Clear();
                AggregatedClassNames.Clear();

                List<CodigoGerado> codigos = new();

                foreach (var type in types)
                {
                    ExportTypeRecursive(type, paths, codigos);
                }

                codigos.AddRange(GenerateDependencyInjectionFile(types.First(), paths));
                return codigos;
            }
            private static void ExportTypeRecursive(Type type, ExportPathsSourceCodeAplicationCommandReceiversUseCase paths, List<CodigoGerado> codigos)
            {
                if (ProcessedTypes.Contains(type) || type.Namespace?.StartsWith("System") == true)
                    return;

                ProcessedTypes.Add(type);

                string folderPath = type.IsEnum ? paths.EnumPath :
                                     type.IsInterface ? paths.InterfacePath :
                                     paths.ClassPath;

                string filePath = Path.Combine(folderPath, $"{type.Name}.cs");

                StringBuilder sb = new();

                HashSet<string> dependencies = CollectDependencies(type, paths);
                foreach (var dep in dependencies)
                {
                    sb.AppendLine($"using {dep};");
                }

                sb.AppendLine();
                string ns = type.IsEnum ? paths.EnumNamespace :
                              type.IsInterface ? paths.InterfaceNamespace :
                              paths.ClassNamespace;

                if (type.IsEnum)
                {
                    sb.AppendLine($"namespace {ns};");
                    sb.AppendLine();
                    sb.AppendLine($"public enum {type.Name}");
                    sb.AppendLine("{");
                    foreach (var value in Enum.GetValues(type))
                    {
                        int intValue = (int)value!;
                        string name = Enum.GetName(type, value)!;
                        sb.AppendLine($"    {name} = {intValue},");
                    }
                    sb.AppendLine("}");

                    codigos.Add(new CodigoGerado { CaminhoArquivo = filePath, Conteudo = sb });
                }
                else if (type.IsInterface)
                {
                    sb.AppendLine($"using {paths.EnumNamespace};");
                    sb.AppendLine($"namespace {ns};");
                    sb.AppendLine();
                    sb.AppendLine($"public interface {type.Name}");
                    sb.AppendLine("{");

                    foreach (var prop in type.GetProperties())
                    {
                        string accessors = string.Join(" ", prop.GetAccessors().Select(a => a.Name.StartsWith("get_") ? "get;" : "set;"));
                        sb.AppendLine($"    {prop.PropertyType.Name} {prop.Name} {{ {accessors} }}");
                        ExportTypeRecursive(prop.PropertyType, paths, codigos);
                    }

                    foreach (var method in type.GetMethods().Where(m => m.DeclaringType == type && !m.IsSpecialName))
                    {
                        foreach (var param in method.GetParameters())
                            ExportTypeRecursive(param.ParameterType, paths, codigos);

                        ExportTypeRecursive(method.ReturnType, paths, codigos);

                        string parameters = string.Join(", ",
                            method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                        string returnType = method.ReturnType == typeof(void) ? "void" : method.ReturnType.Name;
                        sb.AppendLine($"    {returnType} {method.Name}({parameters});");
                    }

                    sb.AppendLine("}");

                    codigos.Add(new CodigoGerado { CaminhoArquivo = filePath, Conteudo = sb });
                    codigos.AddRange(GenerateConcreteClassesForEnum(type, paths));
                }
                else if (type.IsClass)
                {
                    sb.AppendLine($"namespace {ns};");
                    sb.AppendLine();

                    var interfaces = type.GetInterfaces()
                                         .Where(i => !i.Namespace?.StartsWith("System") == true)
                                         .Select(i => i.Name)
                                         .ToList();

                    string interfaceList = interfaces.Count > 0
                        ? " : " + string.Join(", ", interfaces)
                        : "";

                    if (!string.IsNullOrEmpty(interfaceList))
                    {
                        sb.AppendLine($"using {paths.InterfaceNamespace};");
                        AggregatedClassNames.Add($"{paths.InterfaceNamespace}.{interfaces.FirstOrDefault()},{ns}.{type.Name}");
                    }
                    else
                        AggregatedClassNames.Add($"{ns}.{type.Name}");

                    sb.AppendLine($"public partial class {type.Name}{interfaceList}");
                    sb.AppendLine("{");
                    foreach (var prop in type.GetProperties())
                    {
                        sb.AppendLine($"    public {prop.PropertyType.Name.ToLower()} {prop.Name} {{ get; set; }}");
                        ExportTypeRecursive(prop.PropertyType, paths, codigos);
                    }
                    sb.AppendLine("}");

                    codigos.Add(new CodigoGerado { CaminhoArquivo = filePath, Conteudo = sb });

                    string customFilePath = Path.Combine(paths.CustomClassPath, $"{type.Name}.cs");
                    StringBuilder sbCustom = new();
                    sbCustom.AppendLine($"namespace {paths.CustomClassNamespace};");
                    sbCustom.AppendLine();
                    sbCustom.AppendLine($"public partial class {type.Name}");
                    sbCustom.AppendLine("{");
                    sbCustom.AppendLine("    // Adicione sua implementação personalizada aqui");
                    sbCustom.AppendLine("}");

                    codigos.Add(new CodigoGerado { CaminhoArquivo = customFilePath, Conteudo = sbCustom, Custom = true });

                }
            }
            private static HashSet<string> CollectDependencies(Type type, ExportPathsSourceCodeAplicationCommandReceiversUseCase paths)
            {
                HashSet<string> namespaces = new();

                void AddNamespace(Type t)
                {
                    if (t.Namespace != null &&
                        !t.Namespace.StartsWith("System") &&
                        t.Namespace != type.Namespace)
                    {
                        namespaces.Add(t.Namespace);
                    }
                }

                if (type.IsEnum) return namespaces;

                foreach (var prop in type.GetProperties())
                    AddNamespace(prop.PropertyType);

                foreach (var method in type.GetMethods().Where(m => m.DeclaringType == type && !m.IsSpecialName))
                {
                    AddNamespace(method.ReturnType);
                    foreach (var param in method.GetParameters())
                        AddNamespace(param.ParameterType);
                }

                return namespaces;
            }
            private static List<CodigoGerado> GenerateConcreteClassesForEnum(Type interfaceType, ExportPathsSourceCodeAplicationCommandReceiversUseCase paths)
            {
                List<CodigoGerado> codigos = new();
                var enumProp = interfaceType.GetProperties().FirstOrDefault(p => p.PropertyType.IsEnum);

                if (enumProp == null)
                    return codigos;

                Type enumType = enumProp.PropertyType;
                List<string> classNames = new();

                foreach (var enumValue in Enum.GetNames(enumType))
                {
                    string className = $"{enumValue}Notification";
                    classNames.Add(className);

                    string classFilePath = Path.Combine(paths.ClassPath, $"{className}.cs");
                    StringBuilder sbClass = new();
                    sbClass.AppendLine($"using {paths.InterfaceNamespace};");
                    sbClass.AppendLine($"using {paths.EnumNamespace};");
                    sbClass.AppendLine();
                    sbClass.AppendLine($"namespace {paths.ClassNamespace};");
                    sbClass.AppendLine();
                    sbClass.AppendLine($"public partial class {className} : {interfaceType.Name}");
                    sbClass.AppendLine("{");
                    sbClass.AppendLine($"    public {enumType.Name} Type => {enumType.Name}.{enumValue};");
                    sbClass.AppendLine();

                    foreach (var method in interfaceType.GetMethods().Where(m => !m.IsSpecialName))
                    {
                        string parameters = string.Join(", ",
                            method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                        string returnType = method.ReturnType == typeof(void) ? "void" : method.ReturnType.Name;

                        sbClass.AppendLine($"    public partial {returnType} {method.Name}({parameters});");
                    }

                    sbClass.AppendLine("}");

                    codigos.Add(new CodigoGerado { CaminhoArquivo = classFilePath, Conteudo = sbClass });

                    string customFilePath = Path.Combine(paths.CustomClassPath, $"{className}.cs");
                    StringBuilder sbCustom = new();
                    sbCustom.AppendLine($"using {paths.InterfaceNamespace};");
                    sbCustom.AppendLine($"using {paths.EnumNamespace};");
                    sbCustom.AppendLine($"namespace {paths.CustomClassNamespace};");
                    sbCustom.AppendLine();
                    sbCustom.AppendLine($"public partial class {className}");
                    sbCustom.AppendLine("{");
                    foreach (var method in interfaceType.GetMethods().Where(m => !m.IsSpecialName))
                    {
                        string parameters = string.Join(", ",
                            method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                        string returnType = method.ReturnType == typeof(void) ? "void" : method.ReturnType.Name;

                        sbCustom.AppendLine($"    public partial {returnType} {method.Name}({parameters})");
                        sbCustom.AppendLine("    {");
                        sbCustom.AppendLine("        throw new NotImplementedException();");
                        sbCustom.AppendLine("    }");
                    }
                    sbCustom.AppendLine("}");

                    codigos.Add(new CodigoGerado { CaminhoArquivo = customFilePath, Conteudo = sbCustom, Custom = true });

                    AggregatedClassNames.Add($"{paths.ClassNamespace}.{className}");
                }
                codigos.AddRange(GenerateFactory(interfaceType, enumType, classNames, paths));
                return codigos;
            }
            private static List<CodigoGerado> GenerateFactory(Type interfaceType, Type enumType, List<string> classNames, ExportPathsSourceCodeAplicationCommandReceiversUseCase paths)
            {
                List<CodigoGerado> codigos = new();

                string factoryInterfaceName = $"I{interfaceType.Name}Factory";
                string factoryClassName = $"{interfaceType.Name.TrimStart('I')}Factory";

                string interfaceFilePath = Path.Combine(paths.FactoryInterfacePath, $"{factoryInterfaceName}.cs");
                StringBuilder sbInterface = new();
                sbInterface.AppendLine($"using {paths.InterfaceNamespace};");
                sbInterface.AppendLine($"using {paths.EnumNamespace};");
                sbInterface.AppendLine();
                sbInterface.AppendLine($"namespace {paths.FactoryInterfaceNamespace};");
                sbInterface.AppendLine();
                sbInterface.AppendLine($"public interface {factoryInterfaceName}");
                sbInterface.AppendLine("{");
                sbInterface.AppendLine($"    {interfaceType.Name} GetType({enumType.Name} type);");
                sbInterface.AppendLine("}");

                codigos.Add(new CodigoGerado { CaminhoArquivo = interfaceFilePath, Conteudo = sbInterface });

                string classFilePath = Path.Combine(paths.FactoryClassPath, $"{factoryClassName}.cs");
                StringBuilder sbClass = new();
                sbClass.AppendLine($"using {paths.InterfaceNamespace};");
                sbClass.AppendLine($"using {paths.EnumNamespace};");
                sbClass.AppendLine($"using {paths.ClassNamespace};");
                sbClass.AppendLine();
                sbClass.AppendLine($"namespace {paths.FactoryClassNamespace};");
                sbClass.AppendLine();
                sbClass.AppendLine($"public class {factoryClassName} : {factoryInterfaceName}");
                sbClass.AppendLine("{");
                foreach (var className in classNames)
                    sbClass.AppendLine($"    private readonly {className} _{className.ToLower()};");
                sbClass.AppendLine();
                sbClass.AppendLine($"    public {factoryClassName}(");
                sbClass.AppendLine(string.Join(",\n", classNames.Select(c => $"        {c} {c.ToLower()}")));
                sbClass.AppendLine("    )");
                sbClass.AppendLine("    {");
                foreach (var className in classNames)
                    sbClass.AppendLine($"        _{className.ToLower()} = {className.ToLower()};");
                sbClass.AppendLine("    }");
                sbClass.AppendLine();
                sbClass.AppendLine($"    public {interfaceType.Name} GetType({enumType.Name} type)");
                sbClass.AppendLine("    {");
                sbClass.AppendLine("        return type switch");
                sbClass.AppendLine("        {");
                foreach (var className in classNames)
                {
                    string enumValue = className.Replace("Notification", "");
                    sbClass.AppendLine($"            {enumType.Name}.{enumValue} => _{className.ToLower()},");
                }
                sbClass.AppendLine("            _ => throw new ArgumentException(\"Invalid Type\")");
                sbClass.AppendLine("        };\n    }\n}");

                codigos.Add(new CodigoGerado { CaminhoArquivo = classFilePath, Conteudo = sbClass });

                AggregatedClassNames.Add($"{paths.InterfaceNamespace}.{factoryInterfaceName},{paths.FactoryClassNamespace}.{factoryClassName}");

                return codigos;
            }
            private static List<CodigoGerado> GenerateDependencyInjectionFile(Type interfaceType, ExportPathsSourceCodeAplicationCommandReceiversUseCase paths)
            {
                List<CodigoGerado> codigos = new();

                string fileName = $"{interfaceType.Name.TrimStart('I')}DependencyInjection.cs";
                string filePath = Path.Combine(paths.DependencyInjectionPath, fileName);

                StringBuilder sb = new();
                foreach (var className in AggregatedClassNames.Distinct())
                    sb.AppendLine(className);

                codigos.Add(new CodigoGerado { CaminhoArquivo = filePath, Conteudo = sb, CommandType = CommandType.DependencyIngection });
                return codigos;
            }
        }
    }
}
