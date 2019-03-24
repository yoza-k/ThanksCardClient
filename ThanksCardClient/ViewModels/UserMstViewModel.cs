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
    public class UserMstViewModel : ViewModel
    {
        #region UsersProperty
        private List<User> _Users;

        public List<User> Users
        {
            get
            { return _Users; }
            set
            {
                if (_Users == value)
                    return;
                _Users = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public void Initialize()
        {
            this.UpdateUsers();
        }

        private async void UpdateUsers()
        {
            if (SessionService.Instance.AuthorizedUser != null)
            {
                this.Users = await SessionService.Instance.AuthorizedUser.GetUsersAsync();
            }
        }

        #region UserCreateCommand
        private ViewModelCommand _UserCreateCommand;

        public ViewModelCommand UserCreateCommand
        {
            get
            {
                if (_UserCreateCommand == null)
                {
                    _UserCreateCommand = new ViewModelCommand(UserCreate);
                }
                return _UserCreateCommand;
            }
        }

        public void UserCreate()
        {
            System.Diagnostics.Debug.WriteLine("UserCreate");
            UserCreateViewModel ViewModel = new UserCreateViewModel();
            var message = new TransitionMessage(typeof(Views.UserCreate), ViewModel, TransitionMode.Modal, "UserCreate");
            Messenger.Raise(message);

            //ユーザリストを更新する
            this.UpdateUsers();
        }
        #endregion

        #region UserEditCommand
        private ListenerCommand<User> _UserEditCommand;

        public ListenerCommand<User> UserEditCommand
        {
            get
            {
                if (_UserEditCommand == null)
                {
                    _UserEditCommand = new ListenerCommand<User>(UserEdit);
                }
                return _UserEditCommand;
            }
        }

        public void UserEdit(User User)
        {
            System.Diagnostics.Debug.WriteLine("EditCommand" + User.Id);
            UserEditViewModel ViewModel = new UserEditViewModel();
            ViewModel.User = User;
            var message = new TransitionMessage(typeof(Views.UserEdit), ViewModel, TransitionMode.Modal, "UserEdit");
            Messenger.Raise(message);
        }
        #endregion

        #region UserDeleteCommand
        private ListenerCommand<User> _UserDeleteCommand;

        public ListenerCommand<User> UserDeleteCommand
        {
            get
            {
                if (_UserDeleteCommand == null)
                {
                    _UserDeleteCommand = new ListenerCommand<User>(UserDelete);
                }
                return _UserDeleteCommand;
            }
        }

        public async void UserDelete(User User)
        {
            System.Diagnostics.Debug.WriteLine("DeleteCommand" + User.Id);
            User deletedUser = await User.DeleteUserAsync(User.Id);

            this.Initialize();
        }
        #endregion

    }
}
