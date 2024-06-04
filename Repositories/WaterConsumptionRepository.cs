using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterWatchMap.Models;
using WaterWatchMap.Contexts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace WaterWatchMap.Repositories
{
    public class WaterConsumptionRepository : WaterConsumptionRepositoryInterface
    {
        private readonly DataContextInterface _context;
        public WaterConsumptionRepository(DataContextInterface context)
        {
            _context = context;
        }
        public async Task<IEnumerable<WaterConsumption>> GetAll()
        {
            SaveData();
            return await _context.Consumptions.ToListAsync();
        }
        public async Task<IEnumerable<WaterConsumption>> GetTopTenConsumers()
        {
            // SaveData();
            var q = _context.Consumptions
                .OrderByDescending(avgKL => avgKL.AvarageMonthlyKL)
                .Take(10)
                .ToArrayAsync();

            return await q;
        }
        public void SaveData()
        {
            var resDataset = _context.Consumptions.ToList();

            if(resDataset.Count() == 0)
            {
                Console.WriteLine("No Data");

                var geoJSON = File.ReadAllText("C:\\Users\\ketlin\\Downloads\\water_consumption.geojson");
                dynamic jsonObj = JsonConvert.DeserializeObject(geoJSON);

                foreach (var feature in jsonObj["features"])
                {
                    string strNeighbourhood = feature["properties"]["neighbourhood"];
                    string strSuburbGroup = feature["properties"]["suburb_group"];
                    string strAvgMonthlyKL = feature["properties"]["averageMonthlyKL"];
                    string strGeometry = feature["geometry"]["coordinates"].ToString(Newtonsoft.Json.Formatting.None);

                    // Removing ".0" after integer numbers and convertint to integer
                    string convAvgMonthlyKL = strAvgMonthlyKL.Replace(".", "");
                    int avgMonthlyKL = Convert.ToInt32(convAvgMonthlyKL);

                    WaterConsumption wc = new()
                    {
                        Neighbourhood = strNeighbourhood,
                        SuburbGroup = strSuburbGroup,
                        AvarageMonthlyKL = avgMonthlyKL,
                        Coordinates = strGeometry
                    };
                    _context.Consumptions.Add(wc);
                    _context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Data Loaded");
            }
        }
    }
}