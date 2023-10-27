namespace ErniTechnicalExamMonteagudoJeffrey.Responses
{
    public class GetAccountResponse
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public float Balance { get; set; }
    }
}
