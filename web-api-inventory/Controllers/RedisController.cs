using api_inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;
using System;

namespace CacheRepository.Controllers
{

  [Produces("application/json")]      
  public class RedisController : Controller
  { 
    private readonly IDistributedCache _Cache;

    public RedisController(IDistributedCache distributedCache) => _Cache = distributedCache;
  
    // GET api/values
    [Route("api/GetUser/{name}")]
    public async Task<ActionResult<User>> GetUser(string name)
    {
      User user = new User{Token = "abcz009", Email ="test@test.com", UserID = 0 ,Id= 0, Name="test"};
      try
      {
        if (!string.IsNullOrEmpty(name))
        {
          user = await RedisCache.GetObjectAsync<User>(_Cache, name);
        }
        else
        {
          await RedisCache.SetObjectAsync<User>(_Cache, "demo", user);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }

      return user;
    }
  }
}
