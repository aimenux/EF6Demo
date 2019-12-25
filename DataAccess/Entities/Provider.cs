using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5), MaxLength(30)]
        [Index(IsUnique = true)]
        public string ProviderCode { get; set; }

        [DefaultValue(0)]
        public decimal ProviderRate { get; set; }

        public ICollection<Insurance> Insurances { get; set; }
    }
}