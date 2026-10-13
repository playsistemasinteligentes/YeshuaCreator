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
using System.Net;
using System.Net.Http.Json;

namespace Yeshua.Memorias.CQRS.Tests.Integration.Api.Seed.Migration.PublicacaoAlbum;

public partial class PublicacaoAlbumCrudApiSeedTests
{
    partial void CustomizeExecution(HttpClient client, ref Task? execution) => execution = AssertControlledPublicationAsync(client);

    private static async Task AssertControlledPublicationAsync(HttpClient client)
    {
        using var forbidden = await client.PostAsJsonAsync(CreateEndpoint, BuildCreatePayload(), JsonOptions);
        Assert.Equal(HttpStatusCode.BadRequest, forbidden.StatusCode);
        Assert.Contains("comandos de solicitar e retomar", await forbidden.Content.ReadAsStringAsync());
        using var read = await client.PostAsJsonAsync(ReadEndpoint, new { Paginacao = ApiTestData.Pagination() }, JsonOptions);
        ApiResponseAssertions.AssertReadReturnedItems(await ApiResponseAssertions.ReadSuccessStateAsync(read));
    }

    partial void CustomizeCreatePayload(JsonObject payload)
    {
    }

    partial void CustomizeReadPayload(JsonObject payload)
    {
    }

    partial void CustomizeReadAssertion(JsonObject readState, JsonNode id, ref bool handled)
    {
    }

    partial void CustomizeUpdatePayload(JsonObject payload)
    {
    }
}
//Dominio.Schemas.CQRS.SourceCodeIntegrationApiSeedCrudTestMigration
