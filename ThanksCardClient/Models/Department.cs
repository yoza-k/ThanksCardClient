#nullable disable
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class Department : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region CodeProperty
        private int _Code;
        public int Code
        {
            get { return _Code; }
            set { SetProperty(ref _Code, value); }
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

        #region ParentIdProperty
        private long? _ParentId;
        public long? ParentId
        {
            get { return _ParentId; }
            set { SetProperty(ref _ParentId, value); }
        }
        #endregion

        #region ParentProperty
        private Department _Parent;
        public Department Parent
        {
            get { return _Parent; }
            set { SetProperty(ref _Parent, value); }
        }
        #endregion

        #region ChildrenProperty
        private List<Department> _Children;
        public List<Department> Children
        {
            get { return _Children; }
            set { SetProperty(ref _Children, value); }
        }
        #endregion

        #region UsersProperty
        private List<User> _Users;
        public List<User> Users
        {
            get { return _Users; }
            set { SetProperty(ref _Users, value); }
        }
        #endregion

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            IRestService rest = new RestService();
            List<Department> Departments = await rest.GetDepartmentsAsync();
            return Departments;
        }

        public async Task<Department> PostDepartmentAsync(Department Department)
        {
            IRestService rest = new RestService();
            Department createdDepartment = await rest.PostDepartmentAsync(Department);
            return createdDepartment;
        }

        public async Task<Department> PutDepartmentAsync(Department department)
        {
            IRestService rest = new RestService();
            Department updatedDepartment = await rest.PutDepartmentAsync(department);
            return updatedDepartment;
        }

        public async Task<Department> DeleteDepartmentAsync(long Id)
        {
            IRestService rest = new RestService();
            Department deletedDepartment = await rest.DeleteDepartmentAsync(Id);
            return deletedDepartment;
        }
    }
}
