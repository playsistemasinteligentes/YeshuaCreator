using Microsoft.AspNetCore.Http.HttpResults;
using RepositoryInterfaces.Patterns.Command;

namespace API;

public static class StateResults
{
    public static Results<Ok<State<T>>, BadRequest<State<T>>, ProblemHttpResult> From<T>(State<T> state)
    {
        return state.StatusCode switch
        {
            >= 200 and < 300 => TypedResults.Ok(state),
            >= 400 and < 500 => TypedResults.BadRequest(state),
            _ => TypedResults.Problem(state.Message)
        };
    }

    public static Results<Ok<State<T>>, BadRequest<State<T>>, ProblemHttpResult> Try<T>(Func<State<T>> action)
    {
        try
        {
            return From(action());
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