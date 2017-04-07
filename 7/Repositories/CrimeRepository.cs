using _7.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Repositories
{
    class CrimeRepository : ICrimeRepository
    {
        private readonly ApplicationDbContext Context;

        public CrimeRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public void Delete(Crime crime)
        {
            Context.Entry(crime).State = EntityState.Deleted;
        }

        public IEnumerable<Crime> GetAll()
        {
            return Context.Crimes.ToList();
        }

        public Crime GetById(int id)
        {
            return Context.Crimes.Find(id);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(Crime crime)
        {
            Context.Entry(crime).State = EntityState.Modified;
        }

        public void Add(Crime crime)
        {
            Context.Crimes.Add(crime);
        }
    }
}
