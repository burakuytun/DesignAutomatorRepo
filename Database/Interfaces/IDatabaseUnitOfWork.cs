namespace Infrastructure.Database.Interfaces
{
    public interface IDatabaseUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IDnaRepository DnaRepository { get; }

        IDnaClientRepository DnaClientRepository { get; }

        void SaveChanges();
    }
}
