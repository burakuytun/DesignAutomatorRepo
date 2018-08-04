using System.Collections.Generic;
using System.Linq;
using CrossCutting.Utils.Interfaces;
using Infrastructure.Database.Context;
using Infrastructure.Database.Interfaces;
using Infrastructure.EntityFrameworkCore;
using Model.Models;

namespace Infrastructure.Database.Repositories
{
    public class GenericRepository<TEntity> : EntityFrameworkCoreRepository<TEntity>, IGenericRepository<TEntity> where TEntity : class
    {
        public GenericRepository(DesignAutomatorContext context) : base(context)
        {

        }
    }
}