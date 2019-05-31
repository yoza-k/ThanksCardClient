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
using System.Collections.ObjectModel;

namespace ThanksCardClient.ViewModels
{
    public class TagMstViewModel : ViewModel
    {
        #region TagsProperty
        private ObservableCollection<Tag> _Tags;

        public ObservableCollection<Tag> Tags
        {
            get
            { return _Tags; }
            set
            {
                if (_Tags == value)
                    return;
                _Tags = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public void Initialize()
        {
            this.UpdateTags();
        }

        private async void UpdateTags()
        {
            var tag = new Tag();
            this.Tags = await tag.GetTagsAsync();
        }

        #region TagCreateCommand
        private ViewModelCommand _TagCreateCommand;

        public ViewModelCommand TagCreateCommand
        {
            get
            {
                if (_TagCreateCommand == null)
                {
                    _TagCreateCommand = new ViewModelCommand(TagCreate);
                }
                return _TagCreateCommand;
            }
        }

        public void TagCreate()
        {
            System.Diagnostics.Debug.WriteLine("TagCreate");
            TagCreateViewModel ViewModel = new TagCreateViewModel();
            var message = new TransitionMessage(typeof(Views.TagCreate), ViewModel, TransitionMode.Modal, "TagCreate");
            Messenger.Raise(message);

            //ユーザリストを更新する
            this.UpdateTags();
        }
        #endregion

        #region TagEditCommand
        private ListenerCommand<Tag> _TagEditCommand;

        public ListenerCommand<Tag> TagEditCommand
        {
            get
            {
                if (_TagEditCommand == null)
                {
                    _TagEditCommand = new ListenerCommand<Tag>(TagEdit);
                }
                return _TagEditCommand;
            }
        }

        public void TagEdit(Tag Tag)
        {
            System.Diagnostics.Debug.WriteLine("EditCommand" + Tag.Id);
            TagEditViewModel ViewModel = new TagEditViewModel();
            ViewModel.Tag = Tag;
            var message = new TransitionMessage(typeof(Views.TagEdit), ViewModel, TransitionMode.Modal, "TagEdit");
            Messenger.Raise(message);
        }
        #endregion

        #region TagDeleteCommand
        private ListenerCommand<Tag> _TagDeleteCommand;

        public ListenerCommand<Tag> TagDeleteCommand
        {
            get
            {
                if (_TagDeleteCommand == null)
                {
                    _TagDeleteCommand = new ListenerCommand<Tag>(TagDelete);
                }
                return _TagDeleteCommand;
            }
        }

        public async void TagDelete(Tag Tag)
        {
            System.Diagnostics.Debug.WriteLine("DeleteCommand" + Tag.Id);
            Tag deletedTag = await Tag.DeleteTagAsync(Tag.Id);

            this.Initialize();
        }
        #endregion

    }
}