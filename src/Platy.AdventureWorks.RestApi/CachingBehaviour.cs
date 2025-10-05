﻿using Ardalis.GuardClauses;
using Microsoft.Extensions.Caching.Memory;

namespace Platy.AdventureWorks.RestApi;

public class CachingBehavior<TRequest, TResponse> :
  IPipelineBehavior<TRequest, TResponse?>
  where TRequest : IRequest<TResponse>
{
  private readonly IMemoryCache _cache;

  private readonly MemoryCacheEntryOptions _cacheOptions = new MemoryCacheEntryOptions()
    .SetAbsoluteExpiration(TimeSpan.FromSeconds(10)); // TODO: Configure

  private readonly ILogger<Mediator> _logger;

  public CachingBehavior(IMemoryCache cache,
    ILogger<Mediator> logger)
  {
    _cache = cache;
    _logger = logger;
  }

  public async Task<TResponse?> Handle(TRequest request,
    RequestHandlerDelegate<TResponse?> next,
    CancellationToken cancellationToken)
  {
    Guard.Against.Null(request, nameof(request));

    var cacheKey = request.GetType().FullName ?? "";

    return await _cache.GetOrCreateAsync(cacheKey, async entry =>
    {
      _logger.LogInformation($"Cache miss. Getting data from database. ({cacheKey})");
      entry.SetOptions(_cacheOptions);
      return await next();
    });
  }
}
