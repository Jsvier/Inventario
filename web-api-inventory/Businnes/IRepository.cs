namespace api_inventory.Model
{
 public interface IRepository  
    {  
        object Version();
        object Store();
        object Inventory();       
        object Inventory(int Id);       
    }   
}