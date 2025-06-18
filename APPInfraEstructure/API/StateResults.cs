using global::Comandos.Pateners.Command;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API
{
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

        public static Results<Ok<State<T>>, BadRequest<State<T>>, ProblemHttpResult> Try<T>(
            Func<State<T>> func)
        {
            try
            {
                var result = func();
                return From(result);
            }
            catch (ReceiverException<T> rex)
            {
                return TypedResults.BadRequest(rex.State);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}

