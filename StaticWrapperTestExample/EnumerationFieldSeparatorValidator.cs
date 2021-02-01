using System;
using System.Linq;
using StaticWrapperTestExample.Interfaces;
using StaticWrapperTestExample.Wrappers.Interfaces;

namespace StaticWrapperTestExample
{
    public class EnumerationFieldSeparatorValidator : IEnumerationFieldSeparatorValidator
    {
        private readonly IChar _char;

        public EnumerationFieldSeparatorValidator(IChar c)
        {
            _char = c;
        }

        public string Validate(string inputSeparator)
        {
            var controlFilteredChars =
                inputSeparator
                    .Where(c => _char.IsControl(c) == false)
                    .ToArray();
            if (controlFilteredChars.Length == 0)
                throw new Exception("EnumerationFieldSeparatorValidator.ResultIsEmpty");
            return new string(controlFilteredChars);
        }
    }
}