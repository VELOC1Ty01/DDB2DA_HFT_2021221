using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Models
{
    public class GrandPrix
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public int Name { get; set; }

        [Required]
        public string Track { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Team> Teams { get; set; }

        public GrandPrix()
        {
            Teams = new HashSet<Team>();
        }

        public DateTime Date { get; set; }

    }
}
