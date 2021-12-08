using DDB2DA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Logic
{
    public interface IGrandPrixLogic
    {
        void Create(GrandPrix gp);
        GrandPrix ReadOne(int gpId);
        IQueryable<GrandPrix> ReadAll();
        void Update(GrandPrix gp);
        void Delete(int gpId);

        void ChangeDate(int gpId, DateTime newDate);
    }
}
