using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ThanksCardClient.Services
{
    class RestService : IRestService
    {
        private HttpClient Client;
        private string BaseUrl;

        public RestService()
        {
            this.Client = new HttpClient();
            this.BaseUrl = "http://192.168.0.17:5000";
        }
        public async Task<User> LogonAsync(User user)
        {
            var jObject = JsonConvert.SerializeObject(user);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            User responseUser = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Logon", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                // TODO
                System.Diagnostics.Debug.WriteLine("Exception in RestService.LogonAsync: " + e);
            }
            return responseUser;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> responseUsers = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/User");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUsers = JsonConvert.DeserializeObject<List<User>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetUsersAsync: " + e);
            }
            return responseUsers;
        }

        public async Task<User> PostUserAsync(User user)
        {
            var jObject = JsonConvert.SerializeObject(user);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            User responseUser = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/User", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostUserAsync: " + e);
            }
            return responseUser;
        }

        public async Task<User> PutUserAsync(User user)
        {
            var jObject = JsonConvert.SerializeObject(user);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            User responseUser = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/User/" + user.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutUserAsync: " + e);
            }
            return responseUser;
        }

        public async Task<User> DeleteUserAsync(long Id)
        {
            User responseUser = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/User/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseUser = JsonConvert.DeserializeObject<User>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteUserAsync: " + e);
            }
            return responseUser;
        }

        public async Task<List<ThanksCard>> GetThanksCardsAsync()
        {
            List<ThanksCard> responseThanksCards = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/ThanksCard");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseThanksCards = JsonConvert.DeserializeObject<List<ThanksCard>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetThanksCardsAsync: " + e);
            }
            return responseThanksCards;
        }

        public async Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard)
        {
            var jObject = JsonConvert.SerializeObject(thanksCard);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            ThanksCard responseThanksCard = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/ThanksCard", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseThanksCard = JsonConvert.DeserializeObject<ThanksCard>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostThanksCardAsync: " + e);
            }
            return responseThanksCard;
        }

    }
}