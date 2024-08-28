namespace NonProductionAPI.Data.Models;

public class Coolant
{
    //Column Names in the table
    public int Id { get; set; }
    public string? MC_Num { get; set; }
    public string? Fluid_Name { get; set; }
    public string? Conc_Min { get; set; }
    public string? Conc_Max { get; set; }
    public string? TPM1 { get; set; }
    public string? TPM2 { get; set; }
    public string? TPM3 { get; set; }
    public string? TPM4 { get; set; }
    public string? TPM5 { get; set; }
    public string? TPM6 { get; set; }
    public string? Oil1 { get; set; }
    public string? Oil2 { get; set; }
    public string? Oil3 { get; set; }
    public string? Oil4 { get; set; }
    public string? Oil5 { get; set; }
    public string? Oil6 { get; set; }
    public string? Grease { get; set; }
    public string? Chiller { get; set; }
    public string? Distilled_Water { get; set; }

}
