using System;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LanitaeShop.DataAccess.DataContext;
using LanitaeShop.DataAccess.Functions.Interfaces;
using LanitaeShop.DataAccess.Entities;

namespace LanitaeShop.DataAccess.Functions.CRUD
{
    public class CRUD : ICRUD
    {
        public async Task<T> Create<T>(T dbObjet) where T : class
        {
            using (var db = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
            {
                await db.AddAsync(dbObjet);
                await db.SaveChangesAsync();
                return dbObjet;
            }
        }

        public async Task<T> Select<T>(int id) where T : class
        {
            using (var db = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
            {
                T dbOject = await db.FindAsync<T>(id);
                return dbOject;
            }
        }

        public async Task<T> Update<T>(T dbOject, int id) where T : class
        {
            using (var db = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
            {
                T dbOjectToUpdate = db.Find<T>(id);
                if (dbOjectToUpdate != null)
                {
                    db.Entry(dbOjectToUpdate).CurrentValues.SetValues(dbOject);
                    await db.SaveChangesAsync();
                }
                return dbOject;
            }
        }

        public async Task<bool> Delete<T>(int id) where T : class
        {
            using (var db = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
            {
                T dbOjectToDelete = db.Find<T>(id);
                if (dbOjectToDelete != null)
                {
                    db.Remove(dbOjectToDelete);
                    await db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
