using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRefactor.Models
{
    /// <summary>
    /// Модель настраиваемого уведомления
    /// </summary>
    public class CustomNotification : BaseEntity
    {
        /// <summary>
        /// Дата начала отправки
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата конца отправки
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Периодичность
        /// </summary>
        public int Periodicity { get; set; }

        /// <summary>
        /// Время отправки
        /// </summary>
        public TimeOnly SendingTime { get; set; }

        /// <summary>
        /// Список email-адресов
        /// </summary>
        public List<Contact> Emails { get; set; }

        /// <summary>
        /// Участники заявки
        /// </summary>
        public RequestMember RequestMember { get; set; }

        private CustomNotification()
        {
            
        }
        private CustomNotification(
            DateTime startDate, DateTime endDate, 
            int periodicity, TimeOnly sendingTime,
            List<Contact> emails, RequestMember requestMember)
        {
            StartDate = startDate;
            EndDate = endDate;
            Periodicity = periodicity;
            SendingTime = sendingTime;
            Emails = emails;
            RequestMember = requestMember;
        }

        public static Result<CustomNotification, string[]> Create(
            DateTime startDate, DateTime endDate,
            int periodicity, TimeOnly sendingTime,
            List<Contact> emails, RequestMember requestMember)
        {
            return new CustomNotification(startDate, endDate, 
                periodicity, sendingTime, emails, requestMember);
        }
    }
}
