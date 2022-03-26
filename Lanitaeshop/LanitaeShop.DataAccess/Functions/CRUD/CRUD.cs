using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LanitaeShop.DataAccess.DataContext;
using LanitaeShop.DataAccess.Functions.Interfaces;
using System.Linq;
using LanitaeShop.DomainModel;

namespace LanitaeShop.DataAccess.Functions.CRUD
{
    public class CRUD<T> : ICRUD<T> where T : BaseEntity
    {
        public async Task<T> Create(T dbObjet)
        {
            using (var db = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
            {
                await db.AddAsync(dbObjet);
                await db.SaveChangesAsync();
                return dbObjet;
            }
        }

        public async Task<T> Select(int id) 
        {
            using (var db = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
            {

                return db.Set<T>().SingleOrDefault(x => x.ID == id);
                //return dbOject;
            }
        }

        public async Task<IEnumerable<T>> Select(Func<T, bool> predicate = null)
        {
            using (var db = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
            {
                IEnumerable<T> dbOject = null;

                if (predicate != null)
                {
                    dbOject = await db.Set<T>().Where(predicate).AsQueryable().ToListAsync();
                    return dbOject;
                }

                dbOject = await db.Set<T>().ToListAsync();
                return dbOject;

            }
        }

        public async Task<T> Update(T dbOject, int id)
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

        public async Task<bool> Delete(int id)
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
