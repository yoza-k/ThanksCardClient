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
    public class Department : NotificationObject
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

        #region CodeProperty
        private int _Code;

        public int Code
        {
            get
            { return _Code; }
            set
            { 
                if (_Code == value)
                    return;
                _Code = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region NameProperty
        private string _Name;
        [JsonProperty("Name")]
        public string Name
        {
            get
            { return _Name; }
            set
            { 
                if (_Name == value)
                    return;
                _Name = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region UsersProperty
        private List<User> _Users;

        public List<User> Users
        {
            get
            { return _Users; }
            set
            { 
                if (_Users == value)
                    return;
                _Users = value;
                RaisePropertyChanged();
            }
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
