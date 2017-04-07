using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Entities
{
    public class Criminal
    {
        public Criminal()
        {
            Organizations = new List<CriminalOrganization>();
            Crimes = new List<Crime>();
        }

        [Key]
        public int CriminalId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Nickaname { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public string HeirColor { get; set; }

        [Required]
        public string SpecialSigns { get; set; }

        [Required]
        public string Cirezenship { get; set; }

        [Required]
        public string Languages { get; set; }

        [Required]
        public string CrimeTypes { get; set; }
        
        virtual public ICollection<CriminalOrganization> Organizations { get; set; }

        virtual public ICollection<Crime> Crimes { get; set; }

        public override string ToString()
        {
            return ToString("");
        }

        public string ToString(string indent)
        {
            return $"{indent}Id {CriminalId}\n" +
                $"{indent}ФИО: {FullName}\n" +
                $"{indent}Кличка: {Nickaname}\n" +
                $"{indent}Рост: {Height}\n" +
                $"{indent}Цвет волос {HeirColor}\n" +
                $"{indent}Особые приметы: {SpecialSigns}\n" +
                $"{indent}Грожданство {Cirezenship}\n" +
                $"{indent}Языки {Languages}\n" +
                $"{indent}Типы преступлений {CrimeTypes}";
        }
    }
}
