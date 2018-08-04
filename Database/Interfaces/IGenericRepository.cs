using System.Collections.Generic;
using CrossCutting.Utils.Interfaces;
using Model.Models;

namespace Infrastructure.Database.Interfaces
{
    public interface IGenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
    }
}
