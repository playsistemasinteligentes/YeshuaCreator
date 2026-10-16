namespace Dominio.Migration;

public partial class MigrationBuilder
{
    public static void ValidateInternalEntities(IEnumerable<MigrationBase> migrations)
    {
        var declarations = migrations.ToList();
        var entities = declarations.SelectMany(m => m.Entitys).ToList();
        var commands = declarations.SelectMany(m => m.UseCaseGroup)
            .SelectMany(g => g.UseCaseSubGroup.SelectMany(s => s.UseCaseCommand
                .Select(c => (Group: g.Name._value, SubGroup: s.Name._value, Command: c))))
            .ToList();
        var internalEntities = new Dictionary<string, Entity>(StringComparer.OrdinalIgnoreCase);

        foreach (var group in entities.GroupBy(e => e.EntityName, StringComparer.OrdinalIgnoreCase))
        {
            var entity = group.FirstOrDefault(e => e.create) ?? group.First();
            foreach (var declaration in group)
            {
                if (declaration.IsGlobal) entity.Global();
                if (declaration.InternalOwner is { } owner)
                    entity.InternalToUseCase(owner.Group, owner.SubGroup, owner.Command);
            }

            if (entity.IsGlobal && !entity.IsInternal)
                throw new InvalidOperationException($"Entidade Global '{entity.EntityName}' exige InternalToUseCase nesta versao.");
            if (!entity.IsInternal) continue;
            if (group.Any(e => e.CachedTable || e.IsFromView))
                throw new InvalidOperationException($"Entidade interna '{entity.EntityName}' nao suporta Cached ou FromView nesta versao.");
            if (group.Any(e => e.Queries.Count != 0))
                throw new InvalidOperationException($"Entidade interna '{entity.EntityName}' usa metodos especificos nos repositories Custon; AddQuery ainda nao e suportado nesta versao.");
            if (entity.IsGlobal && group.SelectMany(e => e.AddColumns.Concat(e.AlterColumns))
                .Any(c => c.Name.Equals("TenantID", StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"Entidade Global '{entity.EntityName}' nao pode declarar TenantID.");
            internalEntities.Add(entity.EntityName, entity);
        }

        foreach (var item in commands)
        {
            if (item.Command.IsInternal && item.Command.EntityActions.Count != 0)
                throw new InvalidOperationException($"Command interno '{item.Command.Name}' nao pode expor acao de tela.");
            foreach (var reference in item.Command.Entitys)
            {
                if (internalEntities.TryGetValue(reference.EntityName, out var entity) && !IsOwner(entity, item.Group, item.SubGroup, item.Command))
                    throw new InvalidOperationException($"Entidade interna '{entity.EntityName}' so pode ser associada ao seu use case proprietario.");
            }
            if (item.Command.EntityActions.Any(a => internalEntities.ContainsKey(a.EntityName)))
                throw new InvalidOperationException($"Command '{item.Command.Name}' nao pode expor acao de entidade interna.");
        }

        foreach (var module in declarations.SelectMany(m => m.Modules))
        {
            if (module.MenuGroups.SelectMany(g => g.Items).Any(internalEntities.ContainsKey))
                throw new InvalidOperationException("Entidade interna nao pode ser incluida explicitamente em menu.");
        }

        foreach (var entity in entities)
        {
            var isInternal = internalEntities.ContainsKey(entity.EntityName);
            if (isInternal && entity.CustomTabs.Count != 0)
                throw new InvalidOperationException($"Entidade interna '{entity.EntityName}' nao pode expor abas.");
            if (isInternal) continue;
            if (entity.CustomTabs.Any(tab => commands.Any(c => c.Command.IsInternal
                && (tab.UseCaseName.Equals(c.Command.Name._value, StringComparison.OrdinalIgnoreCase)
                    || tab.UseCaseName.Equals($"{c.Group}.{c.SubGroup}.{c.Command.Name}", StringComparison.OrdinalIgnoreCase)))))
                throw new InvalidOperationException($"Aba de '{entity.EntityName}' nao pode expor Command interno.");
            if (entity.IsFromView && internalEntities.ContainsKey(entity.ViewSourceName))
                throw new InvalidOperationException($"Visao publica '{entity.EntityName}' nao pode expor entidade interna.");
            if (entity.AddColumns.Concat(entity.AlterColumns).Any(c => c.IsFK && internalEntities.ContainsKey(c.FkEntityName)))
                throw new InvalidOperationException($"Entidade publica '{entity.EntityName}' nao pode declarar FK para entidade interna nesta versao.");
            foreach (var query in entity.Queries.OfType<IQueryWithMeta>())
            {
                var sources = query.Meta.SelectFields.Select(f => f.EntityName)
                    .Concat(query.Meta.WhereParameters.Values.SelectMany(v => v).Select(f => f.EntityName))
                    .Concat(query.Meta.WhereContextParameters.Values.SelectMany(v => v).Select(f => f.EntityName));
                if (sources.Any(source => internalEntities.ContainsKey(source ?? string.Empty)))
                    throw new InvalidOperationException($"Query publica de '{entity.EntityName}' nao pode expor entidade interna.");
            }
        }

        foreach (var entity in internalEntities.Values)
        {
            var owners = commands.Where(c => IsOwner(entity, c.Group, c.SubGroup, c.Command)).ToList();
            if (owners.Count != 1 || !owners[0].Command.IsInternal)
                throw new InvalidOperationException($"Entidade interna '{entity.EntityName}' exige um unico proprietario existente com Internal() no mesmo aplicativo.");
            var owner = owners[0].Command;
            owner.Entitys.RemoveAll(e => e.EntityName.Equals(entity.EntityName, StringComparison.OrdinalIgnoreCase));
            owner.Entitys.Add(entity);
        }
    }

    private static bool IsOwner(Entity entity, string group, string subGroup, UseCaseCommand command)
    {
        var owner = entity.InternalOwner!;
        return owner.Group.Equals(group, StringComparison.OrdinalIgnoreCase)
            && owner.SubGroup.Equals(subGroup, StringComparison.OrdinalIgnoreCase)
            && owner.Command.Equals(command.Name._value, StringComparison.OrdinalIgnoreCase);
    }
}
