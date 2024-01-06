using EasyWorkAppXamarin.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyWorkAppXamarin.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Users>().Wait();
        }

        public Task<List<Users>> GetPeopleAsync()
        {
            return _database.Table<Users>().ToListAsync();
        }

        public Task<int> SavePersonAsync(Users user)
        {
            return _database.InsertAsync(user);
        }

        public Task<Users> GetUserByEmailAsync(string email)
        {
            return _database.Table<Users>().Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public Task<int> UpdatePersonAsync(Users updatedUser)
        {
            return _database.UpdateAsync(updatedUser);
        }

    }
}
