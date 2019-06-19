using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Distributed;

public interface IDistributedCache
{
    byte[] Get(string key);
    Task<byte[]> GetAsync(string key, CancellationToken token = default(CancellationToken));
    void Set(string key, byte[] value, DistributedCacheEntryOptions options);
    Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default(CancellationToken));
    void Refresh(string key);
    Task RefreshAsync(string key, CancellationToken token = default(CancellationToken));
    void Remove(string key);
    Task RemoveAsync(string key, CancellationToken token = default(CancellationToken));
}