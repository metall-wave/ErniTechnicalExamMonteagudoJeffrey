namespace ErniTechnicalExamMonteagudoJeffrey.Requests
{
    public class TransferRequest
    {
        public int AccountNumber { get; set; }
        public string Password { get; set; }
        public float Amount { get; set; }

        public int RecieverAccountNumber { get; set; }
    }
}
