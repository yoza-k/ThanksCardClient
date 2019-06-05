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
    public class TagCreateViewModel : ViewModel
    {
        #region Tag変更通知プロパティ
        private Tag _Tag;

        public Tag Tag
        {
            get
            { return _Tag; }
            set
            {
                if (_Tag == value)
                    return;
                _Tag = value;
                RaisePropertyChanged(nameof(Tag));
            }
        }
        #endregion

        public async void Initialize()
        {
            this.Tag = new Tag();
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
            Tag createdTag = await Tag.PostTagAsync(this.Tag);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Created"));
        }
        #endregion
    }
}