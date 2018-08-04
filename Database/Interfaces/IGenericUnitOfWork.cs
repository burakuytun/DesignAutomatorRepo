namespace Infrastructure.Database.Interfaces
{
    public interface IGenericUnitOfWork<TEntity> where TEntity : class
    {
        IGenericRepository<TEntity> GenericRepository { get; }

        void SaveChanges();
    }
}

