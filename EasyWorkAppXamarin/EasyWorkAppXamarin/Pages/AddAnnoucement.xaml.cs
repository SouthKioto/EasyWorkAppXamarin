using EasyWorkAppXamarin.Classes;
using EasyWorkAppXamarin.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyWorkAppXamarin.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAnnoucement : ContentPage
    {
        public ObservableCollection<WorkPosition> WorkPositions { get; set; }
        public ObservableCollection<JobLevel> JobLevels { get; set; }
        public ObservableCollection<ContractType> ContractTypes { get; set; }
        public ObservableCollection<EmploymentDimensions> EmploymentDimensions { get; set; }
        public ObservableCollection<WorkType> WorkTypes { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        public AddAnnoucement()
        {
            InitializeComponent();
            WorkPositions = new ObservableCollection<WorkPosition>();
            JobLevels = new ObservableCollection<JobLevel>();
            ContractTypes = new ObservableCollection<ContractType>();
            EmploymentDimensions = new ObservableCollection<EmploymentDimensions>();
            WorkTypes = new ObservableCollection<WorkType>();
            Categories = new ObservableCollection<Category>();

            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            await LoadWorkPositionsAsync();
            await LoadJobLevelsAsync();
            await LoadContractTypesAsync();
            await LoadEmploymentDimensionsAsync();
            await LoadWorkTypesAsync();
            await LoadCategoriesAsync();
        }

        private async Task LoadWorkPositionsAsync()
        {
            var workPositions = await App.Database.GetWorkPositionsAsync();
            WorkPositions.Clear();
            foreach (var workPosition in workPositions)
            {
                WorkPositions.Add(workPosition);
            }
            workPosition_picker.ItemDisplayBinding = new Binding("WorkPosition_Name");
            workPosition_picker.ItemsSource = WorkPositions;
        }

        private async Task LoadJobLevelsAsync()
        {
            var jobLevels = await App.Database.GetJobLevelsAsync();
            JobLevels.Clear();
            foreach (var jobLevel in jobLevels)
            {
                JobLevels.Add(jobLevel);
            }
            jobLevel_picker.ItemDisplayBinding = new Binding("LevelName");
            jobLevel_picker.ItemsSource = JobLevels;
        }

        private async Task LoadContractTypesAsync()
        {
            var contractTypes = await App.Database.GetContractTypesAsync();
            ContractTypes.Clear();
            foreach (var contractType in contractTypes)
            {
                ContractTypes.Add(contractType);
            }
            contractType_picker.ItemDisplayBinding = new Binding("TypeName");
            contractType_picker.ItemsSource = ContractTypes;
        }

        private async Task LoadEmploymentDimensionsAsync()
        {
            var employmentDimensions = await App.Database.GetEmploymentDimensionsAsync();
            EmploymentDimensions.Clear();
            foreach (var employmentDimension in employmentDimensions)
            {
                EmploymentDimensions.Add(employmentDimension);
            }
            employmentDimensions_picker.ItemDisplayBinding = new Binding("DimensionName");
            employmentDimensions_picker.ItemsSource = EmploymentDimensions;
        }

        private async Task LoadWorkTypesAsync()
        {
            var workTypes = await App.Database.GetWorkTypesAsync();
            WorkTypes.Clear();
            foreach (var workType in workTypes)
            {
                WorkTypes.Add(workType);
            }
            workType_picker.ItemDisplayBinding = new Binding("TypeName");
            workType_picker.ItemsSource = WorkTypes;
        }

        private async Task LoadCategoriesAsync()
        {
            var categories = await App.Database.GetCategoriesAsync();
            Categories.Clear();
            foreach (var category in categories)
            {
                Categories.Add(category);
            }
            category_picker.ItemDisplayBinding = new Binding("CategoryName");
            category_picker.ItemsSource = Categories;
        }
         
        private void AddAnnoucementClick(object sender, EventArgs e)
        {
            string advertTitle = title_entry.Text;
            string advertDescription = description_entry.Text;
            int selectedWorkPositionId = GetSelectedItemId(workPosition_picker);
            int selectedJobLevelId = GetSelectedItemId(jobLevel_picker);
            int selectedContractTypeId = GetSelectedItemId(contractType_picker);
            int selectedEmploymentDimensionsId = GetSelectedItemId(employmentDimensions_picker);
            int selectedWorkTypeId = GetSelectedItemId(workType_picker);
            string workingDays = workingDays_entry.Text;
            decimal salaryStart = decimal.Parse(salaryStart_entry.Text);
            decimal salaryEnd = decimal.Parse(salaryEnd_entry.Text);
            string workingHoursStart = workingHoursStart_entry.Text;
            string workingHoursEnd = workingHoursEnd_entry.Text;
            DateTime dateOfExpiryStart = DateTime.Now; 
            DateTime dateOfExpiryEnd = DateTime.Parse(expiryEnd_entry.Date.ToString());
            string responsibilities = responsibilities_entry.Text;

            string selectedCategoryName = string.IsNullOrEmpty(category_entry.Text) ? category_picker.SelectedItem?.ToString() : category_entry.Text;
            int categoryId;

            if (!string.IsNullOrEmpty(selectedCategoryName))
            {
                Category existingCategory = Categories.FirstOrDefault(c => c.CategoryName == selectedCategoryName);

                if (existingCategory != null)
                {
                    categoryId = existingCategory.Category_Id;
                }
                else
                {
                    Category newCategory = new Category
                    {
                        CategoryName = selectedCategoryName
                    };

                    App.Database.SaveCategoryAsync(newCategory);
                    Categories.Add(newCategory);
                    categoryId = newCategory.Category_Id;
                }
            }
            else
            {
                categoryId = -1;
            }

            string selectedWorkPositionName = string.IsNullOrEmpty(workPosition_entry.Text) ? workPosition_picker.SelectedItem?.ToString() : workPosition_entry.Text;
            int workPositionId;

            if (!string.IsNullOrEmpty(selectedWorkPositionName))
            {
                WorkPosition existingWorkPosition = WorkPositions.FirstOrDefault(wp => wp.WorkPosition_Name == selectedWorkPositionName);

                if (existingWorkPosition != null)
                {
                    workPositionId = existingWorkPosition.WorkPosition_Id;
                }
                else
                {
                    WorkPosition newWorkPosition = new WorkPosition
                    {
                        WorkPosition_Name = selectedWorkPositionName
                    };

                    App.Database.SaveWorkPositionAsync(newWorkPosition);
                    WorkPositions.Add(newWorkPosition);
                    workPositionId = newWorkPosition.WorkPosition_Id;
                }
            }
            else
            {
                workPositionId = -1;
            }

            string selectedJobLevelName = string.IsNullOrEmpty(jobLevel_entry.Text) ? jobLevel_picker.SelectedItem?.ToString() : jobLevel_entry.Text;
            int jobLevelId;

            if (!string.IsNullOrEmpty(selectedJobLevelName))
            {
                JobLevel existingselectedJobLevel = JobLevels.FirstOrDefault(wp => wp.LevelName == selectedJobLevelName);

                if (existingselectedJobLevel != null)
                {
                    jobLevelId = existingselectedJobLevel.JobLevel_Id;
                }
                else
                {
                    JobLevel newJobLevel = new JobLevel
                    {
                        LevelName = selectedJobLevelName
                    };

                    App.Database.SaveJobLevelAsync(newJobLevel);
                    JobLevels.Add(newJobLevel);
                    jobLevelId = newJobLevel.JobLevel_Id;
                }
            }
            else
            {
                jobLevelId = -1;
            }

            string selectedContractTypeName = string.IsNullOrEmpty(contractType_entry.Text) ? contractType_picker.SelectedItem?.ToString() : contractType_entry.Text;
            int contractTypeId;

            if (!string.IsNullOrEmpty(selectedContractTypeName))
            {
                ContractType existingselectedContractType = ContractTypes.FirstOrDefault(wp => wp.TypeName == selectedContractTypeName);

                if (existingselectedContractType != null)
                {
                    contractTypeId = existingselectedContractType.ContractType_Id;
                }
                else
                {
                    ContractType newContractType = new ContractType
                    {
                        TypeName = selectedContractTypeName
                    };

                    App.Database.SaveContractTypeAsync(newContractType);
                    ContractTypes.Add(newContractType);
                    contractTypeId = newContractType.ContractType_Id;
                }
            }
            else
            {
                contractTypeId = -1;
            }

            string selectedEmploymentDimName = string.IsNullOrEmpty(employmentDimensions_entry.Text) ? employmentDimensions_picker.SelectedItem?.ToString() : employmentDimensions_entry.Text;
            int employmentDimensionsId;

            if (!string.IsNullOrEmpty(selectedEmploymentDimName))
            {
                EmploymentDimensions existingselectedEmploymentDim = EmploymentDimensions.FirstOrDefault(wp => wp.DimensionName == selectedEmploymentDimName);

                if (existingselectedEmploymentDim != null)
                {
                    employmentDimensionsId = existingselectedEmploymentDim.EmploymentDimensions_Id;
                }
                else
                {
                    EmploymentDimensions newEmploymentDim = new EmploymentDimensions
                    {
                        DimensionName = selectedEmploymentDimName
                    };

                    App.Database.SaveEmploymentDimensionsAsync(newEmploymentDim);
                    EmploymentDimensions.Add(newEmploymentDim);
                    employmentDimensionsId = newEmploymentDim.EmploymentDimensions_Id;
                }
            }
            else
            {
                employmentDimensionsId = -1;
            }

            string selectedWorkTypeName = string.IsNullOrEmpty(workType_entry.Text) ? workType_picker.SelectedItem?.ToString() : workType_entry.Text;
            int workTypeId;

            if (!string.IsNullOrEmpty(selectedWorkTypeName))
            {
                WorkType existingselectedWorkType = WorkTypes.FirstOrDefault(wp => wp.TypeName == selectedWorkTypeName);

                if (existingselectedWorkType != null)
                {
                    workTypeId = existingselectedWorkType.WorkType_Id;
                }
                else
                {
                    WorkType newWorkType = new WorkType
                    {
                        TypeName = selectedWorkTypeName
                    };

                    App.Database.SaveWorkTypeAsync(newWorkType);
                    WorkTypes.Add(newWorkType);
                    workTypeId = newWorkType.WorkType_Id;
                }
            }
            else
            {
                workTypeId = -1;
            }

            Annoucements newAnnoucement = new Annoucements
            {
                Notification_title = advertTitle,
                Notification_descript = advertDescription,
                Notification_work_position = selectedWorkPositionId,
                Job_level = selectedJobLevelId,
                Contract_type = selectedContractTypeId,
                Employment_dimensions = selectedEmploymentDimensionsId,
                Salary_range_start = salaryStart,
                Salary_range_end = salaryEnd,
                Working_days = workingDays,
                Working_hours_start = workingHoursStart,
                Working_hours_end = workingHoursEnd,
                Date_of_expiry_start = dateOfExpiryStart,
                Date_of_expiry_end = dateOfExpiryEnd,
                Category = categoryId,
                Responsibilities = responsibilities,
                WorkType = selectedWorkTypeId,
                User_Id = UserManager.CurrentUser.ID
            };

            App.Database.SaveAnnouncementAsync(newAnnoucement); 
            DisplayAlert("Sukces", "Ogłoszenie zostało dodane do bazy danych.", "OK");

        }

        private int GetSelectedItemId(Picker picker)
        {
            if (picker.SelectedIndex != -1 && picker.SelectedItem is WorkPosition)
            {
                return ((WorkPosition)picker.SelectedItem).WorkPosition_Id;
            }
            else
            {
                return -1;
            }
        }

        private void BackToPreviousPage(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}