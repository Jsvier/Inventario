namespace Core2API.Model
{
 public interface IRepository  
    {  
        object Version();
        object Store();
        object Inventory();       
        object Inventory(int Id);       
    }   
}