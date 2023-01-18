using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Toolbox.ASPMVC.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NeedLowerCaseAttribute : ValidationAttribute
    {
        private readonly int _minimum;

        public NeedLowerCaseAttribute(int minimum = 1)
        {
            _minimum = minimum;
        }

        public override bool IsValid(object? value)
        {
            if(value == null) return false;
            string text = (string) value;
            if(text.Length < _minimum) return false;
            return Regex.Matches(text, "[a-z]").Count >= _minimum;
        }
        public override string FormatErrorMessage(string name)
        {
            return $"\"{name}\" doit contenir au minimum {_minimum} minuscule{((_minimum > 1)?"s":"")}.";
        }
    }
}
