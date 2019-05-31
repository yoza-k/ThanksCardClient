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
    public class ThanksCardTag : NotificationObject
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

        #region ThanksCardIdProperty
        private long _ThanksCardId;

        public long ThanksCardId
        {
            get
            { return _ThanksCardId; }
            set
            {
                if (_ThanksCardId == value)
                    return;
                _ThanksCardId = value;
                RaisePropertyChanged();
            }
        }
        #endregion

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

        #region TagIdProperty
        private long _TagId;

        public long TagId
        {
            get
            { return _TagId; }
            set
            {
                if (_TagId == value)
                    return;
                _TagId = value;
                RaisePropertyChanged();
            }
        }
        #endregion

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
    }
}