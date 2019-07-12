using System.Threading.Tasks;
using api_inventory.Models;
using System.Collections.Generic;

namespace api_inventory.Interface
{
 public interface IRepository  
    {  
        string Version();
        string Store();
        Task<List<Inventory>> Inventory();       
        Task<Inventory> Inventory(int id);       
        Task<int> Remove(int id);     
        Task<List<Parameter>> OracleConfig();
    }   
}