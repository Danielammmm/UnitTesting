using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsApp
{
    public class FormValidator
    {
        public bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        public bool IsValidAge(int age)
        {
            return age >= 18;
        }

        public bool IsValidPerson(string name, int age)
        {
            return IsValidName(name) && IsValidAge(age);
        }
    }
}
