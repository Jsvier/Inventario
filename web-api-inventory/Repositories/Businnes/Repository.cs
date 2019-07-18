using Dapper;
using api_inventory.Interface;
using api_inventory.Model;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace api_inventory.Repositories
{
    public class Repository : IRepository  
    {  
        IConfiguration configuration;  
        public Repository(IConfiguration _configuration)  
        {  
            configuration = _configuration;  
        }

        public string Version()
        {
            return configuration.GetSection("Version").Value;
        }

        public string Store()
        {
            return configuration.GetSection("Store").Value;
        }

        public async Task<Inventory> Inventory(int id)  
        {  
            using (IDbConnection conn = this.GetConnection())
            {
                string sQuery = string.Format("SELECT * FROM INV_INVENTORIES WHERE INV_NO = {0}",id);
                conn.Open();
                var result = await conn.QueryAsync<Inventory>(sQuery);
                return result.FirstOrDefault();
            }
        }  
  
        public async Task<List<Inventory>> Inventory()  
        {  
            using (IDbConnection conn = this.GetConnection())
            {
                string sQuery = "SELECT INV_NO id , DATE_PLANNED, STORE_NO, TIPO, STATUS, DESCRIPCION FROM INV_INVENTORIES";
                conn.Open();
                var result = await conn.QueryAsync<Inventory>(sQuery);
                return result.ToList();
            } 
        }  
  
        public async Task<int> Remove(int id)  
        {  
            using (IDbConnection conn = this.GetConnection())
            {
                string sQuery = string.Format("DELETE FROM INV_INVENTORIES WHERE INV_NO = {0}",id);
                conn.Open();
                var result = await conn.QueryAsync<Inventory>(sQuery);
                return id;
            }
        }  

     //   public async Task<Inventory> Inventory(int id)  
     //   {  
      //      using (IDbConnection conn = this.GetConnection())
      //      {
      //          conn.Open();
      //          var queryParameters = new DynamicParameters();
      //          queryParameters.Add("@ID_INV", INV_NO);

      //          var result = await conn.QueryAsync<Inventory>(
       //             "InventoryDETAILS",
        //            queryParameters,
         //           commandType: CommandType.StoredProcedure);

           //     return result.FirstOrDefault();
            //} 
       // }  
  
        public async Task<List<Parameter>> OracleConfig()  
        {
            using (IDbConnection conn = this.GetConnection())
            {
                string sQuery = "SELECT * FROM v$nls_parameters";
                conn.Open();
                var result = await conn.QueryAsync<Parameter>(sQuery);
                return result.ToList();
            }  
        }  
  
        public IDbConnection GetConnection()  
        {  
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("Connection").Value;  
            var conn = new OracleConnection(connectionString);            
            return conn;  
        }  
    }   
}  
