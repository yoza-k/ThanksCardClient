#nullable disable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Models;
using System.Net.Http.Json;

namespace ThanksCardClient.Services
{
    class RestService : IRestService
    {
        private HttpClient Client;
        private string BaseUrl;

        public RestService()
        {
            // Setting: "Do not use proxy"
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseProxy = false;

            this.Client = new HttpClient(handler);
            this.BaseUrl = "https://localhost:5000";
        }
        public async Task<User> LogonAsync(User user)
        {
            User responseUser = null;
            try
            {
                var response = await Client.PostAsJsonAsync(this.BaseUrl + "/api/Logon", user);
                if (response.IsSuccessStatusCode)
                {
                    responseUser = await response.Content.ReadFromJsonAsync<User>();
                }
            }
            catch (Exception e)
            {
                // TODO
                System.Diagnostics.Debug.WriteLine("Exception in RestService.LogonAsync: " + e);
            }
            return responseUser;
        }

        public async Task<List<User>> GetDepartmentUsersAsync(long? DepartmentId)
        {
            List<User> responseUsers = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/DepartmentUsers/" + DepartmentId);
                if (response.IsSuccessStatusCode)
                {
                    responseUsers = await response.Content.ReadFromJsonAsync<List<User>>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetUsersAsync: " + e);
            }
            return responseUsers;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            List<User> responseUsers = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Users");
                if (response.IsSuccessStatusCode)
                {
                    responseUsers = await response.Content.ReadFromJsonAsync<List<User>>();
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
            User responseUser = null;
            try
            {
                var response = await Client.PostAsJsonAsync(this.BaseUrl + "/api/Users", user);
                if (response.IsSuccessStatusCode)
                {
                    responseUser = await response.Content.ReadFromJsonAsync<User>();
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
            User responseUser = null;
            try
            {
                var response = await Client.PutAsJsonAsync(this.BaseUrl + "/api/Users/" + user.Id, user);
                if (response.IsSuccessStatusCode)
                {
                    responseUser = await response.Content.ReadFromJsonAsync<User>();
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
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Users/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    responseUser = await response.Content.ReadFromJsonAsync<User>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteUserAsync: " + e);
            }
            return responseUser;
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            List<Department> responseDepartments = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Departments");
                if (response.IsSuccessStatusCode)
                {
                    responseDepartments = await response.Content.ReadFromJsonAsync<List<Department>>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetDepartmentsAsync: " + e);
            }
            return responseDepartments;
        }

        public async Task<Department> PostDepartmentAsync(Department department)
        {
            Department responseDepartment = null;
            try
            {
                var response = await Client.PostAsJsonAsync(this.BaseUrl + "/api/Departments", department);

                if (response.IsSuccessStatusCode)
                {
                    responseDepartment = await response.Content.ReadFromJsonAsync<Department>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostDepartmentAsync: " + e);
            }
            return responseDepartment;
        }

        public async Task<Department> PutDepartmentAsync(Department department)
        {
            Department responseDepartment = null;
            try
            {
                var response = await Client.PutAsJsonAsync(this.BaseUrl + "/api/Departments/" + department.Id, department);
                if (response.IsSuccessStatusCode)
                {
                    responseDepartment = await response.Content.ReadFromJsonAsync<Department>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutDepartmentAsync: " + e);
            }
            return responseDepartment;
        }

        public async Task<Department> DeleteDepartmentAsync(long Id)
        {
            Department responseDepartment = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Departments/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    responseDepartment = await response.Content.ReadFromJsonAsync<Department>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteDepartmentAsync: " + e);
            }
            return responseDepartment;
        }

        public async Task<List<ThanksCard>> GetThanksCardsAsync()
        {
            List<ThanksCard> responseThanksCards = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/ThanksCards");
                if (response.IsSuccessStatusCode)
                {
                    responseThanksCards = await response.Content.ReadFromJsonAsync<List<ThanksCard>>();
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
            ThanksCard responseThanksCard = null;
            try
            {
                var response = await Client.PostAsJsonAsync(this.BaseUrl + "/api/ThanksCards", thanksCard);
                if (response.IsSuccessStatusCode)
                {
                    responseThanksCard = await response.Content.ReadFromJsonAsync<ThanksCard>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostThanksCardAsync: " + e);
            }
            return responseThanksCard;
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            List<Tag> responseTags = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Tags");
                if (response.IsSuccessStatusCode)
                {
                    responseTags = await response.Content.ReadFromJsonAsync<List<Tag>>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetTagsAsync: " + e);
            }
            return responseTags;
        }

        public async Task<Tag> PostTagAsync(Tag tag)
        {
            Tag responseTag = null;
            try
            {
                var response = await Client.PostAsJsonAsync(this.BaseUrl + "/api/Tags", tag);
                if (response.IsSuccessStatusCode)
                {
                    responseTag = await response.Content.ReadFromJsonAsync<Tag>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostTagAsync: " + e);
            }
            return responseTag;
        }

        public async Task<Tag> PutTagAsync(Tag tag)
        {
            Tag responseTag = null;
            try
            {
                var response = await Client.PutAsJsonAsync(this.BaseUrl + "/api/Tags/" + tag.Id, tag);
                if (response.IsSuccessStatusCode)
                {
                    responseTag = await response.Content.ReadFromJsonAsync<Tag>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutTagAsync: " + e);
            }
            return responseTag;
        }

        public async Task<Tag> DeleteTagAsync(long Id)
        {
            Tag responseTag = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Tags/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    responseTag = await response.Content.ReadFromJsonAsync<Tag>();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteTagAsync: " + e);
            }
            return responseTag;
        }
    }
}
