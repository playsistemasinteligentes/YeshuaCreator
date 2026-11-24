using Microsoft.AspNetCore.Http;
using RepositoryInterfaces.Patterns.Command;

namespace API;

public static class StateResults
{
    public static IResult From<T>(State<T> state)
    {
        return state.StatusCode switch
        {
            202 => TypedResults.Accepted((string?)null, state),
            >= 200 and < 300 => TypedResults.Ok(state),
            >= 400 and < 500 => TypedResults.BadRequest(state),
            _ => TypedResults.Problem(state.Message)
        };
    }

    public static async Task<IResult> TryAsync<T>(Func<Task<State<T>>> action)
    {
        try
        {
            return From(await action());
        }
        catch (ReceiverException<T> exception)
        {
            return TypedResults.BadRequest(exception.State);
        }
        catch
        {
            return TypedResults.Problem("Nao foi possivel concluir a operacao.");
        }
    }
}