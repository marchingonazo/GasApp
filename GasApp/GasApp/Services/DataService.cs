using System.Collections.Generic;
using System.Text;
using GasApp.Interfaces;
using SQLite;
using Xamarin.Forms;
using GasApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace GasApp.Services
{
    public class DataService
    {
        private SQLiteAsyncConnection conn;

        public DataService()
        {
            this.OpenOrCreateDataBase();
        }

        private async Task OpenOrCreateDataBase()
        {
            var databasepath = DependencyService.Get<IPathService>().GetDataBasePath();
            conn = new SQLiteAsyncConnection(databasepath);
            await conn.CreateTableAsync<Users>().ConfigureAwait(false);
        }

        public async Task Insert<T>(T model)
        {
            await conn.InsertAsync(model);
        }
        public async Task Insert<T>(List<T> models)
        {
            await conn.InsertAllAsync(models);
        }

        public async Task Update<T>(T model)
        {
            await conn.UpdateAsync(model);
        }

        public async Task Update<T>(List<T> models)
        {
            await conn.UpdateAllAsync(models);
        }

        public async Task Delete<T>(T model)
        {
            await conn.DeleteAsync(model);
        }

        public async Task DeleteAllProduct()
        {
            var query = await conn.QueryAsync<Users>("DELETE FROM [Users]");
        }
        
        public async Task<List<Users>> GetAllUsers()
        {
            var query = await conn.QueryAsync<Users>("SELECT * FROM [Users]");
            var array = query.ToArray();
            var list = array.Select(u => new Users
            {
                _Image     = u._Image,
                IdUser     = u.IdUser,
                Date       = u.Date,
                Name       = u.Name,
                Email      = u.Email,
                Remembered = u.Remembered,
            }).ToList();
            return list;
        }
    }
}
