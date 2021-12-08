using DDB2DA_HFT_2021221.Models;
using DDB2DA_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Logic
{
    public class GrandPrixLogic : IGrandPrixLogic
    {
        IGrandPrixRepository repo;

        public GrandPrixLogic(IGrandPrixRepository repo)
        {
            this.repo = repo;
        }

        public void ChangeDate(int gpId, DateTime newDate)
        {
            repo.ChangeDate(gpId, newDate);
        }

        public void Create(GrandPrix gp)
        {
            if (ReadOne(gp.Id) != null)
            {
                throw new InvalidOperationException
                    ("Creating new item with Id: (" + gp.Id + ") is not possible: This item already exists.");
            }

            repo.Create(gp);
        }

        public void Delete(int gpId)
        {
            if (ReadOne(gpId) == null)
            {
                throw new NullReferenceException("GP with the Id: (" + gpId + ") cannot be found.");
            }

            repo.Delete(gpId);
        }

        public IQueryable<GrandPrix> ReadAll()
        {
            return repo.ReadAll();
        }

        public GrandPrix ReadOne(int gpId)
        {
            return repo.ReadOne(gpId);
        }

        public void Update(GrandPrix gp)
        {
            repo.Update(gp);
        }
    }
}
