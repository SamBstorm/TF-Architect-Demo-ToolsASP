using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Toolbox.ASPMVC.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NeedSpecialCharacterAttribute : ValidationAttribute
    {
        private readonly string _characters;
        private readonly int _minimum;

        public NeedSpecialCharacterAttribute(int minimum ,params char[] characters)
        {
            _characters = "[";
            foreach(char c in characters)
            {
                _characters+= (c == '-' || c == '\\' || c == '.')?$@"\{c}":c.ToString();
            }
            _characters += "]";
            _minimum = minimum;
        }

        public override bool IsValid(object value)
        {
            if (value is null) return false;
            return Regex.Matches((string)value,_characters).Count >= _minimum;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"\"{name}\" doit contenir au minimum {_minimum} caractère{((_minimum >1)?"s":"")} spéci{((_minimum > 1) ? "aux" : "al")}.";
        }
    }
}
