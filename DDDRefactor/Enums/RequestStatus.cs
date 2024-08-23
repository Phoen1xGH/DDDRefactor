using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DDDRefactor.Enums
{
    public enum RequestStatus
    {
        /// <summary>
        /// В работе
        /// </summary>
        [Description("В работе")]
        [Display(Name = "В работе")]
        InWork,
        /// <summary>
        /// Закрыто без договора
        /// </summary>
        [Description("Закрыто без договора")]
        [Display(Name = "Закрыто без договора")]
        ClosedWithContract,
        /// <summary>
        /// Закрыто с договора
        /// </summary>
        [Description("Закрыто с договором")]
        [Display(Name = "Закрыто с договором")]
        ClosedWithoutContract,
    }
}
