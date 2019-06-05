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
    public class TagEditViewModel : ViewModel
    {
        #region TagProperty
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
                RaisePropertyChanged();
            }
        }
        #endregion

        #region EditingTagProperty
        private Tag _EditingTag;

        public Tag EditingTag
        {
            get
            { return _EditingTag; }
            set
            {
                if (_EditingTag == value)
                    return;
                _EditingTag = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public void Initialize()
        {
            this.EditingTag = new Tag();
            if (this.Tag != null)
            {
                EditingTag.Name = this.Tag.Name;
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
            this.Tag.Name = this.EditingTag.Name;
            Tag updatedTag = await Tag.PutTagAsync(this.Tag);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Edited"));
        }
        #endregion

    }
}