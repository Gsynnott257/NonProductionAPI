using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonProductionAPI.Data;
using NonProductionAPI.Data.Models;

namespace NonProductionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OilMeasurementsController : ControllerBase
    {
        private readonly AppDBContext _context;

        public OilMeasurementsController(AppDBContext context)
        {
            _context = context;
        }
        // GET: OilMeasurements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OilMeasurement>>> GetOil()
        {
            return await _context.Oil_Log.ToListAsync();
        }


        // GET: OilMeasurements/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OilMeasurement>> GetOil(int id)
        {
            var oilMeasurement = await _context.Oil_Log.FindAsync(id);
            if (oilMeasurement == null)
            {
                return NotFound();
            }

            return oilMeasurement;
        }

        [HttpGet("search/{MCNum}")]
        public async Task<ActionResult<IEnumerable<OilMeasurement>>> Search(string MCNum)
        {
            if (!string.IsNullOrWhiteSpace(MCNum))
            {
                var coolant = await _context.Oil_Log.Where(x => x.MC_Num!.Equals(MCNum)).ToListAsync();
                return coolant != null ? Ok(coolant) : NotFound();
            }
            return BadRequest();
        }

        // POST api/<CoolantController>/5
        [HttpPost("{MCNum}/{OilType}/{OilRecorded}/{OilAdded}/{NewOilLevel}/{Username}")]
        public async Task<ActionResult<OilMeasurement>> Post(
        string MCNum,
        string OilType,
        string OilRecorded,
        string OilAdded,
        string NewOilLevel,
        string Username,
        [FromBody] OilMeasurement oilMeasurement)
        {
            oilMeasurement = new OilMeasurement
            {
                MC_Num = MCNum,
                Oil_Type = OilType,
                Oil_Selection = OilRecorded,
                Oil_Added = OilAdded,
                New_Oil_Level = NewOilLevel,
                User_Name = Username
            };

            _context.Oil_Log.Add(oilMeasurement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOil", new { id = oilMeasurement.MC_Num }, oilMeasurement);
        }
    }
}
