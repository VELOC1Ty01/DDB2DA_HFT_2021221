using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Models
{
    [Table("driver")]
    class Driver
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string SurName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
       

    }
}
