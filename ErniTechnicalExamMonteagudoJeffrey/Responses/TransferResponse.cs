namespace ErniTechnicalExamMonteagudoJeffrey.Responses
{
    public class TransferResponse
    {
        public int AccountNumber { get; set; }
        public float AmountTransferred { get; set; }
        public float Balance { get; set; }

        public int RecieverAccountNumber { get; set; }
    }
}
