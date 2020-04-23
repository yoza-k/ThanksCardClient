using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class TagMstViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region TagsProperty
        private List<Tag> _Tags;
        public List<Tag> Tags
        {
            get { return _Tags; }
            set { SetProperty(ref _Tags, value); }
        }
        #endregion

        public TagMstViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.UpdateTags();
        }

        private async void UpdateTags()
        {
            var tag = new Tag();
            this.Tags = await tag.GetTagsAsync();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region TagCreateCommand
        private DelegateCommand _TagCreateCommand;
        public DelegateCommand TagCreateCommand =>
            _TagCreateCommand ?? (_TagCreateCommand = new DelegateCommand(ExecuteTagCreateCommand));

        void ExecuteTagCreateCommand()
        {
            System.Diagnostics.Debug.WriteLine("TagCreate");
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.TagCreate));
        }
        #endregion

        #region TagEditCommand
        private DelegateCommand<Tag> _TagEditCommand;
        public DelegateCommand<Tag> TagEditCommand =>
            _TagEditCommand ?? (_TagEditCommand = new DelegateCommand<Tag>(ExecuteTagEditCommand));

        void ExecuteTagEditCommand(Tag SelectedTag)
        {
            // 対象のTagをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedTag", SelectedTag);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.TagEdit), parameters);
        }
        #endregion

        #region TagDeleteCommand
        private DelegateCommand<Tag> _TagDeleteCommand;
        public DelegateCommand<Tag> TagDeleteCommand =>
            _TagDeleteCommand ?? (_TagDeleteCommand = new DelegateCommand<Tag>(ExecuteTagDeleteCommand));

        async void ExecuteTagDeleteCommand(Tag SelectedTag)
        {
            Tag deletedTag = await SelectedTag.DeleteTagAsync(SelectedTag.Id);

            // ユーザ一覧 Users を更新する。
            this.UpdateTags();
        }
        #endregion
    }
}
