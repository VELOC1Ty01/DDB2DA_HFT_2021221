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
    [Table("GrandPrix")]
    public class GrandPrix
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Track { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<TeamGPs> TeamGPs { get; set; }

        public GrandPrix()
        {
            this.TeamGPs = new HashSet<TeamGPs>();
        }

        public DateTime Date { get; set; }



    }
}
