using Microsoft.EntityFrameworkCore;
using NonProductionAPI.Data.Models;

namespace NonProductionAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
            
        }

        //These are the table names
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Coolant> Coolant_Concentration { get; set; } = default!;
        public DbSet<CoolantMeasurement> Coolant_Log {  get; set; } = default!; 
        public DbSet<OilMeasurement> Oil_Log { get; set; } = default!;
        public DbSet<ChillerMeasurement> Chiller_Log { get; set; } = default!;
        public DbSet<GreaseMeasurement> Grease_Log { get; set; } = default!;
        public DbSet<DistilledWaterMeasurement> Distilled_Water_Log { get; set; } = default!;

        // Coolant = Model
        // Coolant_Concentation = Table Name
    }
}
