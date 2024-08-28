using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonProductionAPI.Data;
using NonProductionAPI.Data.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistilledWaterMeasurementsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public DistilledWaterMeasurementsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: OilMeasurements/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DistilledWaterMeasurement>> GetDistilledWater(int id)
        {
            var distilledWaterMeasurement = await _context.Distilled_Water_Log.FindAsync(id);
            if (distilledWaterMeasurement == null)
            {
                return NotFound();
            }

            return distilledWaterMeasurement;
        }

        // POST api/<CoolantController>/5
        [HttpPost("{MCNum}/{DistilledWaterSelection}/{DistilledWaterAdded}/{Username}")]
        public async Task<ActionResult<DistilledWaterMeasurement>> Post(
        string MCNum,
        string DistilledWaterSelection,
        string DistilledWaterAdded,
        string Username,
        [FromBody] DistilledWaterMeasurement distilledWaterMeasurement)
        {
            distilledWaterMeasurement = new DistilledWaterMeasurement
            {
                MC_Num = MCNum,
                Distilled_Water_Selection = DistilledWaterSelection,
                Distilled_Water_Added = DistilledWaterAdded,
                User_Name = Username
            };

            _context.Distilled_Water_Log.Add(distilledWaterMeasurement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistilledWater", new { id = distilledWaterMeasurement.MC_Num }, distilledWaterMeasurement);
        }
    }
}
