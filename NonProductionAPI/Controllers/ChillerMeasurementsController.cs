using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonProductionAPI.Data;
using NonProductionAPI.Data.Models;

namespace NonProductionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChillerMeasurementsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ChillerMeasurementsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: OilMeasurements/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChillerMeasurement>> GetChiller(int id)
        {
            var chillerMeasurement = await _context.Chiller_Log.FindAsync(id);
            if (chillerMeasurement == null)
            {
                return NotFound();
            }

            return chillerMeasurement;
        }

        // POST api/<CoolantController>/5
        [HttpPost("{MCNum}/{ChillerType}/{ChillerSelection}/{ChillerAdded}/{Username}")]
        public async Task<ActionResult<ChillerMeasurement>> Post(
        string MCNum,
        string ChillerType,
        string ChillerSelection,
        string ChillerAdded,
        string Username,
        [FromBody] ChillerMeasurement chillerMeasurement)
        {
            chillerMeasurement = new ChillerMeasurement
            {
                MC_Num = MCNum,
                Chiller_Type = ChillerType,
                Chiller_Selection = ChillerSelection,
                Chiller_Added = ChillerAdded,
                User_Name = Username
            };

            _context.Chiller_Log.Add(chillerMeasurement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChiller", new { id = chillerMeasurement.MC_Num }, chillerMeasurement);
        }
    }
}
