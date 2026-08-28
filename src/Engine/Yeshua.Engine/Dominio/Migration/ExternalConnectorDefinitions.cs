using System;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Migration
{
    public enum ExternalConnectorProtocol
    {
        Rest = 1,
        Soap = 2,
        File = 3,
        Text = 4,
        Spreadsheet = 5
    }

    public sealed class ExternalConnectorDefinition
    {
        public ExternalConnectorDefinition(string key, string description)
        {
            Key = key;
            Description = description;
        }

        public string Key { get; }
        public string Description { get; }
        public ExternalConnectorProtocol Protocol { get; set; } = ExternalConnectorProtocol.Rest;
        public bool TokenRequired { get; set; }
        public List<ExternalConnectorOperationDefinition> Operations { get; } = new();
    }

    public sealed class ExternalConnectorOperationDefinition
    {
        public ExternalConnectorOperationDefinition(string service, string operation, string route)
        {
            Service = service;
            Operation = operation;
            Route = route;
        }

        public string Service { get; }
        public string Operation { get; }
        public string Route { get; }
        public bool StoreRawPayload { get; set; } = true;
        public bool DeferredProcessing { get; set; } = true;
    }

    public sealed class ExternalConnectorBuilder
    {
        private readonly ExternalConnectorDefinition _definition;

        internal ExternalConnectorBuilder(ExternalConnectorDefinition definition)
        {
            _definition = definition;
        }

        public ExternalConnectorBuilder UseSoap()
        {
            _definition.Protocol = ExternalConnectorProtocol.Soap;
            return this;
        }

        public ExternalConnectorBuilder UseRest()
        {
            _definition.Protocol = ExternalConnectorProtocol.Rest;
            return this;
        }

        public ExternalConnectorBuilder RequireToken()
        {
            _definition.TokenRequired = true;
            return this;
        }

        public ExternalConnectorBuilder AddOperation(string service, string operation, string route = "")
        {
            if (string.IsNullOrWhiteSpace(service))
                throw new ArgumentException("Servico do conector nao informado.", nameof(service));

            if (string.IsNullOrWhiteSpace(operation))
                throw new ArgumentException("Operacao do conector nao informada.", nameof(operation));

            var resolvedRoute = string.IsNullOrWhiteSpace(route)
                ? $"{service}/{operation}"
                : route.Trim('/');

            if (!_definition.Operations.Any(x =>
                    string.Equals(x.Service, service, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(x.Operation, operation, StringComparison.OrdinalIgnoreCase)))
            {
                _definition.Operations.Add(new ExternalConnectorOperationDefinition(service, operation, resolvedRoute));
            }

            return this;
        }
    }

    public abstract partial class MigrationBase
    {
        public List<ExternalConnectorDefinition> ExternalConnectors { get; } = new();

        public ExternalConnectorBuilder AddExternalConnector(string key, string description)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Chave do conector nao informada.", nameof(key));

            var connector = ExternalConnectors.FirstOrDefault(x =>
                string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase));

            if (connector == null)
            {
                connector = new ExternalConnectorDefinition(key, description);
                ExternalConnectors.Add(connector);
            }

            return new ExternalConnectorBuilder(connector);
        }
    }
}
