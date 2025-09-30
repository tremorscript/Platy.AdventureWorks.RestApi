namespace Platy.AdventureWorks.RestApi;

public class CachingBehavior<TRequest, TResponse> :
  IPipelineBehavior<TRequest, TResponse?>
  where TRequest : IRequest<TResponse>
{
  public Task<TResponse?> Handle(TRequest request, RequestHandlerDelegate<TResponse?> next, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
