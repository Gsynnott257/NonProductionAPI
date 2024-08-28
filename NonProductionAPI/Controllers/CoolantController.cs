using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonProductionAPI.Data;
using NonProductionAPI.Data.Models;

namespace NonProductionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoolantController : ControllerBase
    {
        private readonly AppDBContext _context;

        public CoolantController(AppDBContext context)
        {
            _context = context;
        }
        // GET: api/<CoolantController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coolant>>> GetCoolant()
        {
            return await _context.Coolant_Concentration.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Coolant>> GetCoolant(int id)
        {
            var coolant = await _context.Coolant_Concentration.FindAsync(id);
            if (coolant == null)
            {
                return NotFound();
            }

            return coolant;
        }

        [HttpGet("search/{MCNum}")]
        public async Task<ActionResult<Coolant>> Search(string MCNum)
        {
            if (!string.IsNullOrWhiteSpace(MCNum))
            {
                var coolant = await _context.Coolant_Concentration.Where(x => x.MC_Num!.Equals(MCNum)).FirstOrDefaultAsync();
                return coolant != null ? Ok(coolant) : NotFound();
            }
            return BadRequest();
        }

        [HttpPost("{MCNum}/{FluidName}/{MinConc}/{MaxConc}/{Measurement}/{TPMSelection}/{Username}/{RemeasuredValue}")]
        public async Task<ActionResult<CoolantMeasurement>> Post(
        string MCNum,
        string FluidName,
        string MinConc,
        string MaxConc,
        string Measurement,
        string TPMSelection,
        string Username,
        string RemeasuredValue,
        [FromBody] CoolantMeasurement coolantMeasurement)
        {
            coolantMeasurement = new CoolantMeasurement
            {
                MC_Num = MCNum,
                Fluid_Name = FluidName,
                Conc_Min = MinConc,
                Conc_Max = MaxConc,
                Coolant_Recorded = Measurement,
                Action_Taken = TPMSelection,
                User_Name = Username,
                Remeasured_Value = RemeasuredValue,
            };

            _context.Coolant_Log.Add(coolantMeasurement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoolant", new { id = coolantMeasurement.MC_Num }, coolantMeasurement);
        }
    }
}
