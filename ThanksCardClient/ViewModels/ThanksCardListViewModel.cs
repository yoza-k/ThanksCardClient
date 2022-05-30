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
    public class ThanksCardListViewModel : BindableBase, INavigationAware
    {
        private IRegionManager regionManager;

        #region ThanksCardsProperty
        private List<ThanksCard> _ThanksCards;
        public List<ThanksCard> ThanksCards
        {
            get { return _ThanksCards; }
            set { SetProperty(ref _ThanksCards, value); }
        }
        #endregion

        public ThanksCardListViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #region SearchWordProperty
        private string _SearchWord;
        public string SearchWord
        {
            get { return _SearchWord; }
            set
            {
                SetProperty(ref _SearchWord, value);
                System.Diagnostics.Debug.WriteLine("SearchWord: " + this.SearchWord); //動作確認用。本来はこの行は必要ありません。
            }
        }
        #endregion

        #region SearchThanksCardProperty
        private SearchThanksCard _SearchThanksCard;
        public SearchThanksCard SearchThanksCard
        {
            get { return _SearchThanksCard; }
            set { SetProperty(ref _SearchThanksCard, value); }
        }
        #endregion

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            ThanksCard thanksCard = new ThanksCard();
            this.ThanksCards = await thanksCard.GetThanksCardsAsync();

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region SubmitSearchCommand
        private DelegateCommand<string> _SubmitSearchCommand;
        public DelegateCommand<string> SubmitSearchCommand =>
            _SubmitSearchCommand ?? (_SubmitSearchCommand = new DelegateCommand<string>(ExecuteSubmitSearchCommand));

        async void ExecuteSubmitSearchCommand(string parameter)   
        {
            ThanksCard thanksCard = new ThanksCard();
            this.SearchThanksCard = new SearchThanksCard();
            this.SearchThanksCard.SearchWord = parameter;
            ThanksCards = await thanksCard.PostSearchThanksCardsAsync(SearchThanksCard);
        }
        #endregion
    }
}