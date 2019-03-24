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
    public class ThanksCardCreateViewModel : ViewModel
    {

        #region ThanksCardProperty
        private ThanksCard _ThanksCard;

        public ThanksCard ThanksCard
        {
            get
            { return _ThanksCard; }
            set
            { 
                if (_ThanksCard == value)
                    return;
                _ThanksCard = value;
                RaisePropertyChanged();
            }
        }
        #endregion

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


        public async void Initialize()
        {
            this.ThanksCard = new ThanksCard();
            if (SessionService.Instance.AuthorizedUser != null)
            {
                this.Users = await SessionService.Instance.AuthorizedUser.GetUsersAsync();
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
            ThanksCard createdThanksCard = await ThanksCard.PostThanksCardAsync(this.ThanksCard);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Created"));
        }
        #endregion
    }
}
