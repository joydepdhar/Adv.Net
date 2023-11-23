using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZeroHungerPro.Models
{
    public class AgeAttribute : ValidationAttribute
    {
        private int _maxAge;
        public AgeAttribute(int maxAge)
        {
            _maxAge = maxAge;
        }
        public override bool IsValid(object value)
        {
            if (value == null) return true;
            var DOB = (DateTime)value;
            double age = (DateTime.Now.Subtract(DOB)).TotalDays / 365;
            if (age < _maxAge) return false;
            return true;
        }
    }
}