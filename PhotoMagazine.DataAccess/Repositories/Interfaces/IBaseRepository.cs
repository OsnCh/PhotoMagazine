using PhotoMagazine.Entitys.Entitys;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMagazine.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>: IDisposable where TEntity: BaseEntity
    {
        Task Insert(TEntity entity);

        Task Update(TEntity entity);

        Task<TEntity> Get(int id);

        Task<IEnumerable<TEntity>> GetAll();
    }
}
