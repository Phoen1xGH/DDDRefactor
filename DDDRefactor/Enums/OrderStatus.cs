using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRefactor.Enums
{
    public enum OrderStatus
    {
        [Description("Не в работе")]
        [Display(Name = "Не в работе")]
        Invalid,
        [Description("В работе")]
        [Display(Name = "В работе")]
        InWork,
        [Description("Отгружено")]
        [Display(Name = "Отгружено")]
        Shipped
    }
}
