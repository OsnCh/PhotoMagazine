using Dapper;
using Dapper.Contrib.Extensions;
using PhotoMagazine.DataAccess.Repositories.Interfaces;
using PhotoMagazine.Entitys.Entitys;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMagazine.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public string ConnectionString { get; private set; }
        public SqlConnection Connection { get; private set; }

        public BaseRepository(DataConfiguration dataConfiguration)
        {
            ConnectionString = dataConfiguration.ConnectionString;
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }

        public Task<TEntity> Get(int id)
        {
            return Connection.GetAsync<TEntity>(id);
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            return Connection.GetAllAsync<TEntity>();
        }

        public Task Insert(TEntity entity)
        {
            return Connection.InsertAsync(entity);
        }

        public Task Update(TEntity entity)
        {
            return Connection.UpdateAsync(entity);
        }

        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();
        }
    }
}
