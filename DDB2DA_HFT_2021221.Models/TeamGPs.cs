using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Models
{
    public class TeamGPs
    {
        public int TeamID { get; set; }

        public int GpId { get; set; }

        public Team team { get; set; }

        public GrandPrix gp { get; set; }
    }
}
