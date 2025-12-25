using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalCode.Application.Services
{
    public interface INationalCodeValidator
    {
        bool IsValid(string nationalCode);
    }
}
