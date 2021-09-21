using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Query;
using LanitaeShop.DataAccess.DataContext;
using LanitaeShop.DataAccess.Functions.Interfaces;
using LanitaeShop.DataAccess.Entities;
using System.Linq;

namespace LanitaeShop.DataAccess.Functions.SP
{
    public class AllVarieties  // : IAllVarieties
    {
        public List<AllVarietiesResult> Callsp<T>(int id) where T : class
        {
            AdoNetContext dbContext = new AdoNetContext();

            using (dbContext.Connection)
            {                
                List<AllVarietiesResult> result = new List<AllVarietiesResult>();
                dbContext.Command.CommandText = "allvarieties";
                dbContext.Command.Parameters.Add(new SqlParameter("@productId", id));
                dbContext.Connection.Open();
                
                using (dbContext.Reader = dbContext.Command.ExecuteReader())
                {
                    while (dbContext.Reader.Read())
                    {
                        result.Add(MapToVarieties(dbContext.Reader));
                    }
                }
                return result;
            }
        }
        private AllVarietiesResult MapToVarieties(SqlDataReader reader)
        {
            return new AllVarietiesResult()
            {
                Garment = reader["Garment"].ToString(),
                Price = (decimal)reader["Price"],
                ProductDescription = reader["Product_Description"].ToString(),
                Color = reader["Color"].ToString(),
                Stock = (int)reader["Stock"]
            };
        }
    }

}





//    using (var db = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
//    {
//          return db.AllVarietiesResults.FromSqlRaw("allvarieties {0}", id).ToList();
//        var param = new SqlParameter("@productId", id);

//        return db.AllVarietiesResults.FromSqlRaw("exec allvarieties @productId", param).ToList();

//    }


//}