using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _7.Entities
{
    public class CriminalOrganization
    {
        public CriminalOrganization()
        {
            Members = new List<Criminal>();
        }

        [Key]
        public int CriminalOrganizationId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DangerLevel { get; set; }

        [Required]
        public string Occupation { get; set; }

        virtual public ICollection<Criminal> Members { get; set; }

        public override string ToString()
        {
            return ToString("");
        }

        public string ToString(string indent)
        {
            return $"{indent}Id {CriminalOrganizationId}\n" +
                $"{indent}Название {Name}\n" +
                $"{indent}Уровень опасности {DangerLevel}\n" +
                $"{indent}Род занятий {Occupation}";
        }
    }
}