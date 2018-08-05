using Infrastructure.Database.Context;
using Infrastructure.Database.Interfaces;

namespace Infrastructure.Database.UnitOfWork
{
    public sealed class DatabaseUnitOfWork : IDatabaseUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IDnaRepository DnaRepository { get; }
        public IDnaClientRepository DnaClientRepository { get; }
        public ISectionRepository SectionRepository { get; }

        public DatabaseUnitOfWork(IUserRepository userRepository,
                                  IDnaRepository dnaRepository,
                                  IDnaClientRepository dnaClientRepository,
                                  ISectionRepository sectionRepository,
                                  DesignAutomatorContext context)
        {
            Context = context;
            UserRepository = userRepository;
            DnaRepository = dnaRepository;
            DnaClientRepository = dnaClientRepository;
            SectionRepository = sectionRepository;
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
