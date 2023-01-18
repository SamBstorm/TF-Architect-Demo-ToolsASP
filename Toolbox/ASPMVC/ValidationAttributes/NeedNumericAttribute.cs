using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Toolbox.ASPMVC.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NeedNumericAttribute : ValidationAttribute
    {
        private readonly int _minimum;

        public NeedNumericAttribute(int minimum = 1)
        {
            _minimum = minimum;
        }

        public override bool IsValid(object value)
        {
            if(value == null) return false;
            return Regex.Matches((string)value, "[0-9]").Count >= _minimum ;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"\"{name}\" doit contenir au minimum {_minimum} chiffre{((_minimum > 1) ? "s" : "")}.";
        }
    }
}
