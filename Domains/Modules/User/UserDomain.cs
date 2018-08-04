using CrossCutting.Mapping;
using CrossCutting.Utils.PagedList;
using Domain.Domains.Modules.Base;
using Infrastructure.Database.Interfaces;
using Model.ViewModels;

namespace Domain.Domains.Modules.User
{
    public sealed class UserDomain : BaseDomain, IUserDomain
    {
        public UserDomain(IDatabaseUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        private IDatabaseUnitOfWork UnitOfWork { get; }

        public PagedList<Model.Models.User> List(PagedListParameters parameters)
        {
            return UnitOfWork.UserRepository.List(parameters);
        }

        public Model.Models.User Select(long id) => UnitOfWork.UserRepository.Select(id);

        public UserViewModel SelectViewModel(long id)
        {
            var user = UnitOfWork.UserRepository.Select(id);
            return new Mapper().Map<UserViewModel>(user);
        }

        public UserViewModel SaveViewModel(UserViewModel userViewModel)
        {
            var user = new Mapper().Map<Model.Models.User>(userViewModel);
            UnitOfWork.UserRepository.Add(user);
            UnitOfWork.SaveChanges();
            return new Mapper().Map<UserViewModel>(user);
        }
    }
}
