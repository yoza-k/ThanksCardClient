#nullable disable
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class DepartmentMstViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region DepartmentsProperty
        private List<Department> _Departments;
        public List<Department> Departments
        {
            get { return _Departments; }
            set { SetProperty(ref _Departments, value); }
        }
        #endregion

        public DepartmentMstViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.UpdateDepartments();
        }

        private async void UpdateDepartments()
        {
            Department dept = new Department();
            this.Departments = await dept.GetDepartmentsAsync();
        }

        #region DepartmentCreateCommand
        private DelegateCommand _DepartmentCreateCommand;
        public DelegateCommand DepartmentCreateCommand =>
            _DepartmentCreateCommand ?? (_DepartmentCreateCommand = new DelegateCommand(ExecuteDepartmentCreateCommand));

        void ExecuteDepartmentCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentCreate));
        }
        #endregion

        #region DepartmentEditCommand
        private DelegateCommand<Department> _DepartmentEditCommand;
        public DelegateCommand<Department> DepartmentEditCommand =>
            _DepartmentEditCommand ?? (_DepartmentEditCommand = new DelegateCommand<Department>(ExecuteDepartmentEditCommand));

        void ExecuteDepartmentEditCommand(Department SelectedDepartment)
        {
            // 対象のDepartmentをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedDepartment", SelectedDepartment);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentEdit), parameters);
        }
        #endregion

        #region DepartmentDeleteCommand
        private DelegateCommand<Department> _DepartmentDeleteCommand;
        public DelegateCommand<Department> DepartmentDeleteCommand =>
            _DepartmentDeleteCommand ?? (_DepartmentDeleteCommand = new DelegateCommand<Department>(ExecuteDepartmentDeleteCommand));

        async void ExecuteDepartmentDeleteCommand(Department SelectedDepartment)
        {
            Department deletedDepartment = await SelectedDepartment.DeleteDepartmentAsync(SelectedDepartment.Id);

            // 一覧 Departments を更新する。
            this.UpdateDepartments();
        }
        #endregion
    }
}
