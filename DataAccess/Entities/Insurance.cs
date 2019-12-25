using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Insurance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5), MaxLength(30)]
        [Index(IsUnique = true)]
        public string InsuranceCode { get; set; }

        [DefaultValue(true)]
        public bool Enabled { get; set; }

        public Provider InsuranceProvider { get; set; }
    }
}
