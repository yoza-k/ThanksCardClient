using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class TagCreateViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        #region TagProperty
        private Tag _Tag;
        public Tag Tag
        {
            get { return _Tag; }
            set { SetProperty(ref _Tag, value); }
        }
        #endregion

        #region ErrorMessageProperty
        private string _ErrorMessage;
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { SetProperty(ref _ErrorMessage, value); }
        }
        #endregion

        public TagCreateViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            this.Tag = new Tag();
        }

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            Tag createdTag = await Tag.PostTagAsync(this.Tag);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.TagMst));
        }
        #endregion
    }
}
