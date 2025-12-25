using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NationalCode.Application.Services
{

    public class NationalCodeValidator : INationalCodeValidator
    {
        private static readonly string[] InvalidCodes =
        {
            "0000000000", "1111111111", "2222222222",
            "3333333333", "4444444444", "5555555555",
            "6666666666", "7777777777", "8888888888", "9999999999"
        };

        public bool IsValid(string nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode))
                return false;

            if (!Regex.IsMatch(nationalCode, @"^\d{10}$"))
                return false;

            if (InvalidCodes.Contains(nationalCode))
                return false;

            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += (nationalCode[i] - '0') * (10 - i);
            }

            int remainder = sum % 11;
            int controlDigit = nationalCode[9] - '0';

            return remainder < 2
                ? controlDigit == remainder
                : controlDigit == (11 - remainder);
        }
    }
}
