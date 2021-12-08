using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DDB2DA_HFT_2021221.Models
{
    public class TeamGP
    {
        public int TeamID { get; set; }

        public int GpId { get; set; }

        [NotMapped]
        public virtual Team Team { get; set; }

        [NotMapped]
        public virtual GrandPrix GP { get; set; }
    }
}
