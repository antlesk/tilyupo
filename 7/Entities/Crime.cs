using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _7.Entities
{
    public class Crime
    {
        public Crime()
        {
            Members = new List<Criminal>();
        }

        [Key]
        public int CrimeId { get; set; }

        [Required]
        public string Place { get; set; }

        virtual public ICollection<Criminal> Members { get; set; }

        [Required]
        public string Effects { get; set; }
        
        [Required]
        public string Comments { get; set; }

        public override string ToString()
        {
            return ToString("");
        }

        public string ToString(string indent)
        {
            return $"{indent}Id {CrimeId}\n" +
                $"{indent}Место преступления: {Place}\n" +
                $"{indent}Последствия: {Effects}\n" +
                $"{indent}Комментарий эксперта {Comments}";
        }
    }
}
