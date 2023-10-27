namespace ErniTechnicalExamMonteagudoJeffrey.Requests
{
    public class CreateAccountRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string Password { get; set; }
        public float Balance { get; set; }
    }
}
