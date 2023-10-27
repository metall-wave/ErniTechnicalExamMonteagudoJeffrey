namespace ErniTechnicalExamMonteagudoJeffrey.Interfaces
{
    public interface IEncryptionService
    {
        string Encrypt(string text);
        string Decrypt(string text);
    }
}
