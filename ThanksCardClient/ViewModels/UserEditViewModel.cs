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

namespace ThanksCardClient.ViewModels
{
    public class UserEditViewModel : ViewModel
    {
        #region UserProperty
        private User _User;

        public User User
        {
            get
            { return _User; }
            set
            { 
                if (_User == value)
                    return;
                _User = value;
                RaisePropertyChanged();
            }
        }
        #endregion

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

        #region EditingUserProperty
        private User _EditingUser;

        public User EditingUser
        {
            get
            { return _EditingUser; }
            set
            { 
                if (_EditingUser == value)
                    return;
                _EditingUser = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public async void Initialize()
        {
            Department dept = new Department();
            this.Departments = await dept.GetDepartmentsAsync();

            this.EditingUser = new User();
            if(this.User != null)
            {
                EditingUser.Name = this.User.Name;
                EditingUser.Password = this.User.Password;
                EditingUser.IsAdmin = this.User.IsAdmin;
                foreach(Department department in Departments)
                {
                    if(this.User.Department != null && department.Id == this.User.Department.Id)
                    {
                        EditingUser.Department = department;
                    }
                }
            }
        }

        #region SubmitCommand
        private ViewModelCommand _SubmitCommand;

        public ViewModelCommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new ViewModelCommand(Submit);
                }
                return _SubmitCommand;
            }
        }

        public async void Submit()
        {
            this.User.Name = this.EditingUser.Name;
            this.User.Password = this.EditingUser.Password;
            this.User.IsAdmin = this.EditingUser.IsAdmin;
            this.User.Department = this.EditingUser.Department;
            User updatedUser = await User.PutUserAsync(this.User);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Edited"));
        }
        #endregion

    }
}
