using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Entities
{
    public interface ICriminalOrganizationRepository
    {
        IEnumerable<CriminalOrganization> GetAll();

        CriminalOrganization GetById(int id);

        void Update(CriminalOrganization criminalOrg);

        void Delete(CriminalOrganization criminalOrg);

        void Add(CriminalOrganization criminalOrg);

        void Save();
    }
}
