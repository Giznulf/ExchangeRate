namespace ExchangeRate.Models
{
    public class Currencies
    {
        public string Date { get; set; }

        public string PreviousDate { get; set; }

        public string PreviousURL { get; set; }

        public string? Timestamp { get; set; }

        public Dictionary<string, Valute> Valute { get; set; }
    }
}
