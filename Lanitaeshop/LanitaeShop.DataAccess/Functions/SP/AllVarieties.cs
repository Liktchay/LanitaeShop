using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Query;
using LanitaeShop.DataAccess.DataContext;
using LanitaeShop.DataAccess.Functions.Interfaces;
using LanitaeShop.DataAccess.Entities;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace LanitaeShop.DataAccess.Functions.SP
{
    public class AllVarieties  // : IAllVarieties
    {
        public List<AllVarietiesResult> Callsp<T>(int id) where T : class
        {
            using (var db = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
            {

                //  return db.AllVarietiesResults.FromSqlRaw("allvarieties {0}", id).ToList();
                var param = new SqlParameter("@productId", id);

                return db.AllVarietiesResults.FromSqlRaw("exec allvarieties @productId", param).ToList();

            }


        }

    }
}
