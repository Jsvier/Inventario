using api_inventory.Model;
using api_inventory.Models;
using api_inventory.Oracle;
using Dapper;  
using Microsoft.Extensions.Configuration;  
using Oracle.ManagedDataAccess.Client;  
using System;  
using System.Data;  
  

namespace api_inventory.Repositories  
{  
    public class Repository : IRepository  
    {  
        IConfiguration configuration;  
        public Repository(IConfiguration _configuration)  
        {  
            configuration = _configuration;  
        }  

        public object Version()  
        {  
            object result = null;  

            try  
            { 
                result = configuration.GetSection("Version").Value;  
            } 
            catch (Exception ex)  
            {  
                throw ex;  
            }  
  
            return result;             
        }  

        public object Store()  
        {  
            object result = null;  

            try  
            { 
                result = configuration.GetSection("Store").Value;  
            } 
            catch (Exception ex)  
            {  
                throw ex;  
            }  
  
            return result;             
        }  

        public object Inventory(int Id)  
        {  
            object result = null;  
            try  
            {  
                var dyParam = new OracleDynamicParameters();  
                dyParam.Add("ID_INV", OracleDbType.Int32, ParameterDirection.Input, Id);  
                dyParam.Add("INV_DETAIL_CURSOR", OracleDbType.RefCursor, ParameterDirection.Output);  
  
                var conn = this.GetConnection();  
                if (conn.State == ConnectionState.Closed)  
                {  
                    conn.Open();  
                }  
  
                if (conn.State == ConnectionState.Open)  
                {  
                    var query = "InventoryDETAILS";  
  
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);  
                }  
            }  
            catch (Exception ex)  
            {  
                throw ex;  
            }  
  
            return result;  
        }  
  
        public object Inventory()  
        {  
            object result = null; 
            try  
            {  
                var dyParam = new OracleDynamicParameters();  
  
                dyParam.Add("INVCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);  
  
                var conn = this.GetConnection();  
                if(conn.State == ConnectionState.Closed)  
                {  
                    conn.Open();  
                }  
  
                if (conn.State == ConnectionState.Open)  
                {  
                    var query = "GETINVENTORIES";  
  
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);  
                }  
            }  
            catch (Exception ex)  
            {  
                throw ex;  
            }  
  
            return result;  
        }  
  
        public NLS_Config NLS_Config()  
        {  
            NLS_Config result = new NLS_Config(); 
            try  
            {  
           // TODO:RELLENAR
           //     var dyParam = new OracleDynamicParameters();  
  
           //     dyParam.Add("INVCURSOR", OracleDbType.RefCursor, ParameterDirection.Output);  
  
            //    var conn = this.GetConnection();  
            //    if(conn.State == ConnectionState.Closed)  
             //   {  
             //       conn.Open();  
            //    }  
  
            //    if (conn.State == ConnectionState.Open)  
            //    {  
            //        var query = "GETINVENTORIES";  
  
            //        result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);  
             //   }  
            }  
            catch (Exception ex)  
            {  
                throw ex;  
            }  
            
            result.NLS_LANGUAGE ="BLABLABLA"; 
            return result;  
        }  
  
        public IDbConnection GetConnection()  
        {  
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("Connection").Value;  
            var conn = new OracleConnection(connectionString);            
            return conn;  
        }  
    }   
}  
