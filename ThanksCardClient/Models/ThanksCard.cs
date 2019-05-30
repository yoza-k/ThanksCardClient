using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;
using ThanksCardClient.Services;
using Newtonsoft.Json;

namespace ThanksCardClient.Models
{
    public class ThanksCard : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */


        #region IdProperty
        private long _Id;

        public long Id
        {
            get
            { return _Id; }
            set
            { 
                if (_Id == value)
                    return;
                _Id = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region TitleProperty
        private string _Title;
        [JsonProperty("Title")]
        public string Title
        {
            get
            { return _Title; }
            set
            { 
                if (_Title == value)
                    return;
                _Title = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region BodyProperty
        private string _Body;
        [JsonProperty("Body")]
        public string Body
        {
            get
            { return _Body; }
            set
            { 
                if (_Body == value)
                    return;
                _Body = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region FromIdProperty
        private long _FromId;

        public long FromId
        {
            get
            { return _FromId; }
            set
            { 
                if (_FromId == value)
                    return;
                _FromId = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region FromProperty
        private User _From;

        public User From
        {
            get
            { return _From; }
            set
            { 
                if (_From == value)
                    return;
                _From = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ToIdProperty
        private long _ToId;

        public long ToId
        {
            get
            { return _ToId; }
            set
            { 
                if (_ToId == value)
                    return;
                _ToId = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ToProperty
        private User _To;

        public User To
        {
            get
            { return _To; }
            set
            { 
                if (_To == value)
                    return;
                _To = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CreatedDateTimeProperty
        private DateTime _CreatedDateTime;

        public DateTime CreatedDateTime
        {
            get
            { return _CreatedDateTime; }
            set
            { 
                if (_CreatedDateTime == value)
                    return;
                _CreatedDateTime = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public ThanksCard()
        {
            this.CreatedDateTime = DateTime.Now;
        }

        public async Task<List<ThanksCard>> GetThanksCardsAsync()
        {
            IRestService rest = new RestService();
            List<ThanksCard> thanksCards = await rest.GetThanksCardsAsync();
            return thanksCards;
        }

        public async Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard)
        {
            IRestService rest = new RestService();
            ThanksCard createdThanksCard = await rest.PostThanksCardAsync(thanksCard);
            return createdThanksCard;
        }

    }
}
