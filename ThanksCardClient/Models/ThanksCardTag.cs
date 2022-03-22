#nullable disable
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanksCardClient.Models
{
    public class ThanksCardTag : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region ThanksCardIdProperty
        private long _ThanksCardId;
        public long ThanksCardId
        {
            get { return _ThanksCardId; }
            set { SetProperty(ref _ThanksCardId, value); }
        }
        #endregion

        #region ThanksCardProperty
        private ThanksCard _ThanksCard;
        public ThanksCard ThanksCard
        {
            get { return _ThanksCard; }
            set { SetProperty(ref _ThanksCard, value); }
        }
        #endregion

        #region TagIdProperty
        private long _TagId;
        public long TagId
        {
            get { return _TagId; }
            set { SetProperty(ref _TagId, value); }
        }
        #endregion

        #region TagProperty
        private Tag _Tag;
        public Tag Tag
        {
            get { return _Tag; }
            set { SetProperty(ref _Tag, value); }
        }
        #endregion
    }
}
