using System.ComponentModel.DataAnnotations;

namespace Mortgage_Calc.Data;

public class Mortgage
{
    [Required(ErrorMessage = "Loan amount is required.")]
    [Range(1, Int64.MaxValue, ErrorMessage = "Loan amount must be positive whole number.")]
    public int? LoanAmount { get; set; }
    [Required(ErrorMessage = "Interest rate is required.")]
    [Range(0, 100, ErrorMessage = "Interest must be decimal number between 0 and 100.")]
    public double? Rate { get; set; }
    [Required(ErrorMessage = "Term is required.")]
    [Range(1, Int64.MaxValue, ErrorMessage = "Term must be positive whole number larger than 0.")]
    public int? Term { get; set; }

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