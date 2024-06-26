namespace Kubona.Data.Models
{
    public class VerifyDTO
    {
       public VerifyDTO() { }
        public int OrderId { get; set; }
        public decimal OrderAmt { get; set; }
        public decimal AmountEntered { get; set; }
        public bool Correct { get;set; }
        public int PaymentOption { get;set; }
    }
}


