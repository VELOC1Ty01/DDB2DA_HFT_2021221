using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Models
{
    [Table("Driver")]
    public class Driver
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(3)]
        [Required]
        public string ShortName { get; set; }

        [MaxLength(3)]
        [Required]
        public string Nationality { get; set; }

        public double  Points { get; set; }

        [NotMapped]
        public virtual Team Team { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
       

    }
}
