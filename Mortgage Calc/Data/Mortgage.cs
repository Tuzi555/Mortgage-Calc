using System.ComponentModel.DataAnnotations;

namespace Mortgage_Calc.Data;

public class Mortgage
{
    [Required] public int? LoanAmount { get; set; }
    [Required] public double? Rate { get; set; }
    [Required] public int? Term { get; set; }

    public double MonthlyPayment { get; set; }
    public double TotalPaid { get; set; }
    public double TotalInterest { get; set; }
    public void CalculateMortgage()
    {
        var monthlyRate = ((Rate ?? 0) / 100) / 12;
        var months = (Term ?? 0) * 12;
        var loan = LoanAmount ?? 0;
        MonthlyPayment = loan * ((monthlyRate * Math.Pow((1 + monthlyRate), months)) / (Math.Pow((1 + monthlyRate), months) - 1));
        TotalPaid = months * MonthlyPayment;
        TotalInterest = TotalPaid - loan;
    }

}