using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRefactor.Enums
{
    public enum CurrencyType
    {
        [Description("₽")]
        RUB = 0,
        [Description("¥")]
        CNY = 1,
        [Description("$")]
        USD = 2,
        [Description("€")]
        EUR = 3,
    }
}
