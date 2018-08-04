using Infrastructure.Database.Context;
using Infrastructure.Database.Interfaces;

namespace Infrastructure.Database.UnitOfWork
{
    public sealed class GenericUnitOfWork<TEntity> : IGenericUnitOfWork<TEntity> where TEntity : class
    {
        public IGenericRepository<TEntity> GenericRepository { get; }

        public GenericUnitOfWork(IGenericRepository<TEntity> genericRepository,
            DesignAutomatorContext context)
        {
            Context = context;
            GenericRepository = genericRepository;
        }

        private DesignAutomatorContext Context { get; set; }


        public void DiscardChanges()
        {
            if (Context == null) return;
            Context.Dispose();
            Context = null;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
