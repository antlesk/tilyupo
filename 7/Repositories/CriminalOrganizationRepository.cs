using System;
using System.Collections.Generic;
using _7.Entities;
using System.Data.Entity;
using System.Linq;

namespace _7.Repositories
{
    class CriminalOrganizationRepository : ICriminalOrganizationRepository
    {
        private readonly ApplicationDbContext Context;

        public CriminalOrganizationRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public void Delete(CriminalOrganization criminalOrg)
        {
            Context.Entry(criminalOrg).State = EntityState.Deleted;
        }

        public IEnumerable<CriminalOrganization> GetAll()
        {
            return Context.CriminalOrganizations.ToList();
        }

        public CriminalOrganization GetById(int id)
        {
            return Context.CriminalOrganizations.Find(id);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(CriminalOrganization criminalOrg)
        {
            Context.Entry(criminalOrg).State = EntityState.Modified;
        }

        public void Add(CriminalOrganization criminalOrg)
        {
            Context.CriminalOrganizations.Add(criminalOrg);
        }
    }
}
