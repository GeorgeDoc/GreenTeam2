using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.EF.Repositories
{
    public interface IEntityRepo<TEntity>
        where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity? GetById(int id);
        Task Create(TEntity entity);
        Task Update(int id,TEntity entity);
        Task Delete(int id);
    }
}
