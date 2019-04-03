using ThanksCardClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanksCardClient.Services
{
    interface IRestService
    {
        // Logon REST API Client
        Task<User> LogonAsync(User user);

        // User REST API Client
        Task<List<User>> GetUsersAsync();
        Task<User> PostUserAsync(User user);
        Task<User> PutUserAsync(User user);
        Task<User> DeleteUserAsync(long Id);

        // Department REST API Client
        Task<List<Department>> GetDepartmentsAsync();
        Task<Department> PostDepartmentAsync(Department department);
        Task<Department> PutDepartmentAsync(Department department);
        Task<Department> DeleteDepartmentAsync(long Id);

        // TanksCard REST API Client
        Task<List<ThanksCard>> GetThanksCardsAsync();
        Task<ThanksCard> PostThanksCardAsync(ThanksCard thanksCard);

    }
}
