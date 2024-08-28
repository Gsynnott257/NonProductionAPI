namespace NonProductionAPI.Data.Models;

public class CoolantMeasurement
{
    public int Id { get; set; }
    public string? MC_Num { get; set; }
    public string? Fluid_Name { get; set; }
    public string? Conc_Min { get; set; }
    public string? Conc_Max { get; set; }
    public string? Coolant_Recorded { get; set; }
    public string? Action_Taken { get; set; }
    public string? Remeasured_Value { get; set; }
    public string? User_Name { get; set; }
}
