using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class DepartmentMstViewModel : ViewModel
    {
        #region DepartmentsProperty
        private List<Department> _Departments;

        public List<Department> Departments
        {
            get
            { return _Departments; }
            set
            {
                if (_Departments == value)
                    return;
                _Departments = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public void Initialize()
        {
            this.UpdateDepartments();
        }

        private async void UpdateDepartments()
        {
            Department dept = new Department();
            this.Departments = await dept.GetDepartmentsAsync();
        }

        #region DepartmentCreateCommand
        private ViewModelCommand _DepartmentCreateCommand;

        public ViewModelCommand DepartmentCreateCommand
        {
            get
            {
                if (_DepartmentCreateCommand == null)
                {
                    _DepartmentCreateCommand = new ViewModelCommand(DepartmentCreate);
                }
                return _DepartmentCreateCommand;
            }
        }

        public void DepartmentCreate()
        {
            System.Diagnostics.Debug.WriteLine("DepartmentCreate");
            DepartmentCreateViewModel ViewModel = new DepartmentCreateViewModel();
            var message = new TransitionMessage(typeof(Views.DepartmentCreate), ViewModel, TransitionMode.Modal, "DepartmentCreate");
            Messenger.Raise(message);

            //ユーザリストを更新する
            this.UpdateDepartments();
        }
        #endregion

        #region DepartmentEditCommand
        private ListenerCommand<Department> _DepartmentEditCommand;

        public ListenerCommand<Department> DepartmentEditCommand
        {
            get
            {
                if (_DepartmentEditCommand == null)
                {
                    _DepartmentEditCommand = new ListenerCommand<Department>(DepartmentEdit);
                }
                return _DepartmentEditCommand;
            }
        }

        public void DepartmentEdit(Department Department)
        {
            System.Diagnostics.Debug.WriteLine("EditCommand" + Department.Id);
            DepartmentEditViewModel ViewModel = new DepartmentEditViewModel();
            ViewModel.Department = Department;
            var message = new TransitionMessage(typeof(Views.DepartmentEdit), ViewModel, TransitionMode.Modal, "DepartmentEdit");
            Messenger.Raise(message);
        }
        #endregion

        #region DepartmentDeleteCommand
        private ListenerCommand<Department> _DepartmentDeleteCommand;

        public ListenerCommand<Department> DepartmentDeleteCommand
        {
            get
            {
                if (_DepartmentDeleteCommand == null)
                {
                    _DepartmentDeleteCommand = new ListenerCommand<Department>(DepartmentDelete);
                }
                return _DepartmentDeleteCommand;
            }
        }

        public async void DepartmentDelete(Department Department)
        {
            System.Diagnostics.Debug.WriteLine("DeleteCommand" + Department.Id);
            Department deletedDepartment = await Department.DeleteDepartmentAsync(Department.Id);

            this.Initialize();
        }
        #endregion

    }
}
