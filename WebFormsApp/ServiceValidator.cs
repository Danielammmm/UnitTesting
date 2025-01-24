using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsApp.Services;

namespace WebFormsApp
{
    public class ServiceValidator
    {
        private readonly IDataService _dataService;

        public ServiceValidator(IDataService dataService)
        {
            _dataService = dataService;
        }

        public bool IsNameValid(string name)
        {
            return _dataService.ValidateName(name);
        }

        public bool IsAgeValid(int age)
        {
            return age >= _dataService.GetMinimumAge();
        }
    }

}