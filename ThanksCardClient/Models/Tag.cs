using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class Tag : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region NameProperty
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        #endregion

        #region ThanksCardTagsProperty
        private List<ThanksCardTag> _ThanksCardTags;
        public List<ThanksCardTag> ThanksCardTags
        {
            get { return _ThanksCardTags; }
            set { SetProperty(ref _ThanksCardTags, value); }
        }
        #endregion

        #region SelectedProperty
        private bool _Selected;

        // JSON シリアライズから除外する
        [JsonIgnore]
        public bool Selected
        {
            get { return _Selected; }
            set { SetProperty(ref _Selected, value); }
        }
        #endregion

        public async Task<List<Tag>> GetTagsAsync()
        {
            IRestService rest = new RestService();
            List<Tag> tags = await rest.GetTagsAsync();
            return tags;
        }

        public async Task<Tag> PostTagAsync(Tag tag)
        {
            IRestService rest = new RestService();
            Tag createdTag = await rest.PostTagAsync(tag);
            return createdTag;
        }

        public async Task<Tag> PutTagAsync(Tag tag)
        {
            IRestService rest = new RestService();
            Tag updatedTag = await rest.PutTagAsync(tag);
            return updatedTag;
        }

        public async Task<Tag> DeleteTagAsync(long Id)
        {
            IRestService rest = new RestService();
            Tag deletedTag = await rest.DeleteTagAsync(Id);
            return deletedTag;
        }


    }
}
