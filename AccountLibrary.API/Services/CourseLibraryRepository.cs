using AccountLibrary.API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Dapper;
using System.Data;

using AccountLibrary.API.Models;
using Microsoft.Data.SqlClient;

namespace AccountLibrary.API.Services
{
    public class AccountLibraryRepository : IAccountLibraryRepository, IDisposable
    {

        private readonly string connstring;
        private IDbConnection Connection => new SqlConnection(connstring);
        public AccountLibraryRepository()
        {

            //  connstring = "Server=192.168.0.164;Database=maecbsdb;user=SA;Password=TCSuser1123;Trusted_Connection=True;";
            connstring = "Server=192.168.0.164;Database=maecbsdb;user=SA;Password=TCSuser1123;";
        }



        public IEnumerable<Account> GetAccounts(string customerId)
        {
            using (var c = Connection)
            {
                c.Open();
                var p = new DynamicParameters();
                p.Add("custid", customerId, DbType.String, ParameterDirection.Input);
                var x = c.Query<Account>("select * from vw_customer where cust_id = @custid", p);

                // var test = c.Execute("sp_mae_get_customer_details", p, commandType: CommandType.StoredProcedure);
                c.Close();
                return x;
            }
            return null;
        }


        public Account GetAccountDetailsByID(string accountNumber)
        {
            using (var c = Connection)
            {
                c.Open();
                var p = new DynamicParameters();
                p.Add("accountNumber", accountNumber, DbType.String, ParameterDirection.Input);

                string query = "select * from vw_customer where account_identifier= @accountNumber";
                var x = c.Query<Account>(query,p);
                
                //var test = c.Execute("sp_mae_get_customer_details", p, commandType: CommandType.StoredProcedure);
                c.Close();
                return x.FirstOrDefault();
            }
            return null;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
