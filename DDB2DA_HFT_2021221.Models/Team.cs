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
    [Table("Teams")]
    public class Team
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(60)]
        [Required]
        public string Name { get; set; }

        public double Points { get; set; }

        [NotMapped]
        public virtual ICollection<Driver> Drivers { get; set; }


        [NotMapped]
        public virtual ICollection<TeamGP> TeamGPs { get; set; }

        public Team()
        {
            this.Drivers = new HashSet<Driver>();
            this.TeamGPs = new HashSet<TeamGP>();
        }

        public override string ToString()
        {
            return $"{Id} - {Name} - Points: {Points}";
        }

    }
}
