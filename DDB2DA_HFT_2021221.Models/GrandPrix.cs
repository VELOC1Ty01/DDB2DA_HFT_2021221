using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Models
{
    public class GrandPrix
    {
        [Key]
        public int GpId { get; set; }

        [MaxLength(40)]
        [Required]
        public int GpName { get; set; }

        [Required]
        public string Track { get; set; }

        [NotMapped]
        public virtual ICollection<Team> Teams { get; set; }

        public GrandPrix()
        {
            Teams = new HashSet<Team>();
        }

        public DateTime GpDate { get; set; }

    }
}
