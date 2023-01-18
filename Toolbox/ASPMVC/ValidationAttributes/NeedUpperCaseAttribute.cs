using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Toolbox.ASPMVC.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NeedUpperCaseAttribute : ValidationAttribute
    {
        private readonly int _minimum;

        public NeedUpperCaseAttribute(int minimum = 1) {
            _minimum = minimum;
        }
        public override bool IsValid(object value)
        {
            if(value == null) return false;
            return Regex.Matches((string)value, "[A-Z]").Count >= _minimum;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"\"{name}\" doit contenir au minimum {_minimum} majuscule{((_minimum >1)?"s":"")}.";
        }
    }
}
