using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterWatchMap.Repositories;
using WaterWatchMap.Models;

namespace WaterWatchMap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WaterConsumptionController : ControllerBase
    {
        private readonly WaterConsumptionRepositoryInterface _waterConsumptionRepository;
        public WaterConsumptionController(WaterConsumptionRepositoryInterface waterConsumptionRepository)
        {
            _waterConsumptionRepository = waterConsumptionRepository;
        }

        [HttpGet("/waterconsumption/getall")]
        public async Task<ActionResult<IEnumerable<WaterConsumption>>> GetAll()
        {
            var wcData = await _waterConsumptionRepository.GetAll();
            return Ok(wcData);
        }

        [HttpGet("/waterconsumption/topten")]
        public async Task<ActionResult<IEnumerable<WaterConsumption>>> GetTopTen()
        {
            var wcData = await _waterConsumptionRepository.GetTopTenConsumers();
            return Ok(wcData);
        }
    }
}