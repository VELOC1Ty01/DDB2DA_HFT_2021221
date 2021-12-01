using DDB2DA_HFT_2021221.Data;
using DDB2DA_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Repository
{
    public class GrandPrixRepository : IGrandPrixRepository
    {
        F1DbContext context;

        public GrandPrixRepository(F1DbContext context)
        {
            this.context = context;
        }

        public void Create(GrandPrix gp)
        {
            context.GrandPrix.Add(gp);
            context.SaveChanges();
        }

        public GrandPrix ReadOne(int gpId)
        {
            return context
                .GrandPrix
                .FirstOrDefault(x => x.Id.Equals(gpId));
        }

        public IQueryable<GrandPrix> ReadAll()
        {
            return context.GrandPrix;
        }

        public void Update(GrandPrix gp)
        {
            GrandPrix old = ReadOne(gp.Id);

            old.Name = gp.Name;
            old.Date = gp.Date;
            old.TeamGPs = gp.TeamGPs;
            old.Track = gp.Track;

            context.SaveChanges();
        }

        public void Delete(int gpId)
        {
            context.GrandPrix.Remove(ReadOne(gpId));
            context.SaveChanges();
        }
    }
}
