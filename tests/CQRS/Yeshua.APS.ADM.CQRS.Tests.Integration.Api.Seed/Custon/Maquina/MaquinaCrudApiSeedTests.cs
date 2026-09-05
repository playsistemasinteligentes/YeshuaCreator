// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration
// </yeshua>

using System.Text.Json.Nodes;

namespace Yeshua.APS.ADM.CQRS.Tests.Integration.Api.Seed.Migration.Maquina;

public partial class MaquinaCrudApiSeedTests
{
    partial void CustomizeCreatePayload(JsonObject payload)
    {
        payload["MAQ_ACOMPANHA_LOTE_PILOTO"] = "08:00|17:00";
    }

    partial void CustomizeReadPayload(JsonObject payload)
    {
    }

    partial void CustomizeUpdatePayload(JsonObject payload)
    {
        payload["MAQ_ACOMPANHA_LOTE_PILOTO"] = "09:00|18:00";
    }
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration
