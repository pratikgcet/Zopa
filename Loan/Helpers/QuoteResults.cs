namespace Quote.Helpers
{

    //This class shuold be immutable, no one shuold be able to modify the quotes after it has been generated
    public class QuoteResults
    {
        private int loanAmount { get; set; }

        private decimal quoteRate { get; set; }

        private decimal monthlyRepayment { get; set; }

        private decimal totalRepayment { get; set; }

        public QuoteResults(int loanAmount, decimal quoteRate, decimal monthlyRepayment, decimal totalRepayment)
        {
            this.loanAmount = loanAmount;
            this.quoteRate = quoteRate;
            this.monthlyRepayment = monthlyRepayment;
            this.totalRepayment = totalRepayment;
        }

        public int LoanAmount
        {
            get { return loanAmount; }
            
        }
        public decimal QuoteRate
        {
            get { return quoteRate; }

        }
        public decimal MonthlyRepayment
        {
            get { return monthlyRepayment; }

        }
        public decimal TotalRepayment
        {
            get { return totalRepayment; }

        }
    }
}
