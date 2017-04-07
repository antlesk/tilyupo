using System.Collections.Generic;

namespace _7.Entities
{
    public interface ICrimeRepository
    {
        IEnumerable<Crime> GetAll();

        Crime GetById(int id);

        void Update(Crime crime);
        
        void Delete(Crime crime);

        void Add(Crime crime);

        void Save();
    }
}
