using EasyWorkAppXamarin.Classes;
using SQLite;
using System;
using System.Collections.Generic;
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
            _database.CreateTableAsync<Annoucements>().Wait();
            _database.CreateTableAsync<Category>().Wait();
            _database.CreateTableAsync<ContractType>().Wait();
            _database.CreateTableAsync<EmploymentDimensions>().Wait();
            _database.CreateTableAsync<JobLevel>().Wait();
            _database.CreateTableAsync<LanguageSkill>().Wait();
            _database.CreateTableAsync<WorkPosition>().Wait();
            _database.CreateTableAsync<WorkType>().Wait();
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

        public Task<int> DeleteUserAsync(int userId)
        {
            return _database.DeleteAsync<Users>(userId);
        }

        public Task<int> UpdateAdminPermitAsync(Users updatedUser)
        {
            return _database.ExecuteAsync("UPDATE Users SET IsAdmin = ? WHERE ID = ?", updatedUser.IsAdmin, updatedUser.ID);
        }

        public Task<int> SaveAnnouncementAsync(Annoucements announcement)
        {
            return _database.InsertAsync(announcement);
        }

        public Task<List<Category>> GetCategoriesAsync()
        {
            return _database.Table<Category>().ToListAsync();
        }

        public Task<List<ContractType>> GetContractTypesAsync()
        {
            return _database.Table<ContractType>().ToListAsync();
        }

        public Task<List<EmploymentDimensions>> GetEmploymentDimensionsAsync()
        {
            return _database.Table<EmploymentDimensions>().ToListAsync();
        }

        public Task<List<JobLevel>> GetJobLevelsAsync()
        {
            return _database.Table<JobLevel>().ToListAsync();
        }

        public Task<List<LanguageSkill>> GetLanguageSkillsAsync()
        {
            return _database.Table<LanguageSkill>().ToListAsync();
        }

        public Task<List<WorkPosition>> GetWorkPositionsAsync()
        {
            return _database.Table<WorkPosition>().ToListAsync();
        }

        public Task<List<WorkType>> GetWorkTypesAsync()
        {
            return _database.Table<WorkType>().ToListAsync();
        }

        public Task<int> SaveCategoryAsync(Category category)
        {
            if (category.Category_Id != 0)
            {
                return _database.UpdateAsync(category);
            }
            else
            {
                return _database.InsertAsync(category);
            }
        }

        public Task<int> SaveWorkPositionAsync(WorkPosition workPosition)
        {
            if (workPosition.WorkPosition_Id != 0)
            {
                return _database.UpdateAsync(workPosition);
            }
            else
            {
                return _database.InsertAsync(workPosition);
            }
        }

        public Task<int> SaveJobLevelAsync(JobLevel joblevel)
        {
            if (joblevel.JobLevel_Id != 0)
            {
                return _database.UpdateAsync(joblevel);
            }
            else
            {
                return _database.InsertAsync(joblevel);
            }
        }

        public Task<int> SaveContractTypeAsync(ContractType contract)
        {
            if (contract.ContractType_Id != 0)
            {
                return _database.UpdateAsync(contract);
            }
            else
            {
                return _database.InsertAsync(contract);
            }
        }

        public Task<int> SaveEmploymentDimensionsAsync(EmploymentDimensions employment)
        {
            if (employment.EmploymentDimensions_Id != 0)
            {
                return _database.UpdateAsync(employment);
            }
            else
            {
                return _database.InsertAsync(employment);
            }
        }

        public Task<int> SaveWorkTypeAsync(WorkType worktype)
        {
            if (worktype.WorkType_Id != 0)
            {
                return _database.UpdateAsync(worktype);
            }
            else
            {
                return _database.InsertAsync(worktype);
            }
        }

        public Task<List<Annoucements>> GetAnnoucementsAsync()
        {
            return _database.Table<Annoucements>().ToListAsync();
        }

        public string GetWorkTypeName(int workTypeId)
        {
            var workType = _database.Table<WorkType>().FirstOrDefaultAsync(w => w.WorkType_Id == workTypeId).Result;
            return workType?.TypeName ?? "Unknown";
        }

        public string GetJobLevelName(int jobLevelId)
        {
            var jobLevel = _database.Table<JobLevel>().FirstOrDefaultAsync(j => j.JobLevel_Id == jobLevelId).Result;
            return jobLevel?.LevelName ?? "Unknown";
        }

        public string GetContractTypeName(int contractTypeId)
        {
            var contractType = _database.Table<ContractType>().FirstOrDefaultAsync(c => c.ContractType_Id == contractTypeId).Result;
            return contractType?.TypeName ?? "Unknown";
        }

        public string GetEmploymentDimensionsName(int employmentId)
        {
            var employment = _database.Table<EmploymentDimensions>().FirstOrDefaultAsync(e => e.EmploymentDimensions_Id == employmentId).Result;
            return employment?.DimensionName ?? "Unknown";
        }

    }
}
