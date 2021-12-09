using DDB2DA_HFT_2021221.Logic;
using DDB2DA_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GrandPrixController : ControllerBase
    {
        private IGrandPrixLogic logic;

        public GrandPrixController(IGrandPrixLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<GrandPrix> GetAll()
        {
            return logic.ReadAll();
        }

        [HttpPost]
        public void CreateOne([FromBody] GrandPrix gp)
        {
            logic.Create(gp);
        }

        [HttpPut]
        public void UpdateOne([FromBody] GrandPrix gp)
        {
            logic.Update(gp);
        }

        [HttpDelete("{gpId}")]
        public void Delete([FromRoute] int gpId)
        {
            logic.Delete(gpId);
        }

        [HttpPost("{grandprix}")]
        public void Post([FromBody] GrandPrix grandPrix)
        {
            logic.Create(grandPrix);
        }

        [HttpGet("{id}")]
        public GrandPrix Get(int id)
        {
            return logic.ReadOne(id);
        }

        [HttpPut]
        public void Put([FromBody] GrandPrix grandPrix)
        {
            logic.Update(grandPrix);
        }
    }
}
