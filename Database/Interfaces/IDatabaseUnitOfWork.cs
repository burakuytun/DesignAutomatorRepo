namespace Infrastructure.Database.Interfaces
{
    public interface IDatabaseUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IDnaRepository DnaRepository { get; }

        IDnaClientRepository DnaClientRepository { get; }
        ISectionRepository SectionRepository { get; }
        

        void SaveChanges();
    }
}
