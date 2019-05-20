using api_inventory.Models;

namespace api_inventory.Model
{
 public interface IRepository  
    {  
        object Version();
        object Store();
        object Inventory();       
        object Inventory(int Id);     
        NLS_Config NLS_Config();
    }   
}