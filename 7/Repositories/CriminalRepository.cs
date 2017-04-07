using _7.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Repositories
{
    class CriminalRepository : ICriminalRepository
    {
        private readonly ApplicationDbContext Context;

        public CriminalRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public void Delete(Criminal criminal)
        {
            Context.Entry(criminal).State = EntityState.Deleted;
        }

        public IEnumerable<Criminal> GetAll()
        {
            return Context.Criminals.ToList();
        }

        public Criminal GetById(int id)
        {
            return Context.Criminals.Find(id);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(Criminal criminal)
        {
            Context.Entry(criminal).State = EntityState.Modified;
        }

        public void Add(Criminal criminal)
        {
            Context.Criminals.Add(criminal);
        }
    }
}
