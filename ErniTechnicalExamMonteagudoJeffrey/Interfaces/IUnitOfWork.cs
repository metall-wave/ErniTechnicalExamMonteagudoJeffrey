namespace ErniTechnicalExamMonteagudoJeffrey.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IAccountRepository Accounts { get; }
        int Save();
    }
}
