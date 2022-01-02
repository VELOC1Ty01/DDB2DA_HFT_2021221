﻿using DDB2DA_HFT_2021221.Logic;
using DDB2DA_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
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

        public DriverController(IDriverLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Put([FromBody] Driver driver)
        {
            logic.Update(driver);
        }

        [HttpDelete("{driverId}")]
        public void Delete([FromRoute] int driverId)
        {
            logic.Delete(driverId);
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
