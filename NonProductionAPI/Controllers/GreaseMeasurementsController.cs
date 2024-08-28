using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonProductionAPI.Data;
using NonProductionAPI.Data.Models;

namespace NonProductionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreaseMeasurementsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public GreaseMeasurementsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: OilMeasurements/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GreaseMeasurement>> GetGrease(int id)
        {
            var greaseMeasurement = await _context.Grease_Log.FindAsync(id);
            if (greaseMeasurement == null)
            {
                return NotFound();
            }

            return greaseMeasurement;
        }

        // POST api/<CoolantController>/5
        [HttpPost("{MCNum}/{GreaseType}/{GreaseSelection}/{GreaseAdded}/{Username}")]
        public async Task<ActionResult<GreaseMeasurement>> Post(
        string MCNum,
        string GreaseType,
        string GreaseSelection,
        string GreaseAdded,
        string Username,
        [FromBody] GreaseMeasurement greaseMeasurement)
        {
            greaseMeasurement = new GreaseMeasurement
            {
                MC_Num = MCNum,
                Grease_Type = GreaseType,
                Grease_Selection = GreaseSelection,
                Grease_Added = GreaseAdded,
                User_Name = Username
            };

            _context.Grease_Log.Add(greaseMeasurement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrease", new { id = greaseMeasurement.MC_Num }, greaseMeasurement);
        }
    }
}
