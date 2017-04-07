using System.Collections.Generic;

namespace _7.Entities
{
    public interface ICriminalRepository
    {
        IEnumerable<Criminal> GetAll();

        Criminal GetById(int id);

        void Update(Criminal criminal);

        void Delete(Criminal criminal);

        void Add(Criminal criminal);

        void Save();
    }
}
