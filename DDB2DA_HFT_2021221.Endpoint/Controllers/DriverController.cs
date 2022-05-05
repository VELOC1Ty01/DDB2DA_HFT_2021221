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
    [Route("[controller]")] // driver
    [ApiController]
    public class DriverController : ControllerBase
    {
        private IDriverLogic logic;
        IHubContext<SignalRHub> hub;

        public DriverController(IDriverLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Driver> GetAll()
        {
            return logic.ReadAll();
        }

        [HttpPost]
        public void CreateOne([FromBody] Driver driver)
        {
            logic.Create(driver);
            this.hub.Clients.All.SendAsync("DriverCreated", driver);
        }

        [HttpPut]
        public void Put([FromBody] Driver driver)
        {
            logic.Update(driver);
            this.hub.Clients.All.SendAsync("DriverUpdated", driver);
        }

        [HttpDelete("{driverId}")]
        public void Delete([FromRoute] int driverId)
        {
            var driverToDelete = this.logic.ReadOne(driverId);
            logic.Delete(driverId);
            this.hub.Clients.All.SendAsync("DriverDeleted", driverToDelete);
        }

        [HttpPost("{driver}")]
        public void Post([FromBody] Driver driver)
        {
            logic.Create(driver);
        }
        
        [HttpGet("{id}")]
        public Driver Get(int id)
        {
            Driver driver = logic.ReadOne(id);
            return driver;
        }

    }
}
