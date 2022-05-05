using DDB2DA_HFT_2021221.Endpoint.Services;
using DDB2DA_HFT_2021221.Logic;
using DDB2DA_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;

        public GrandPrixController(IGrandPrixLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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

        [HttpDelete("{gpId}")]
        public void Delete([FromRoute] int gpId)
        {
            var gpToDelete = this.logic.ReadOne(gpId);
            logic.Delete(gpId);
            this.hub.Clients.All.SendAsync("ActorDeleted", gpToDelete);
        }

        [HttpPost("{grandprix}")]
        public void Post([FromBody] GrandPrix grandPrix)
        {
            logic.Create(grandPrix);
            this.hub.Clients.All.SendAsync("GPCreated", grandPrix);
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
            this.hub.Clients.All.SendAsync("GPUpdated", grandPrix);
        }
    }
}
