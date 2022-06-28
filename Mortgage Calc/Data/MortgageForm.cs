using System.ComponentModel.DataAnnotations;

namespace Mortgage_Calc.Data;

public class MortgageFormModel
{
    [Required] public int? LoanAmount { get; set; }
    [Required] public double? Rate { get; set; }
    [Required] public int? Term { get; set; }
}