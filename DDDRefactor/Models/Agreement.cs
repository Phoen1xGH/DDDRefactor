using CSharpFunctionalExtensions;

namespace DDDRefactor.Models
{
    public class Agreement : BaseEntity
    {
        public string AgreementNumber { get; private set; }

        /// <summary>
        /// Дата договра
        /// </summary>
        public DateTime AgreementDate { get; private set;  }

        public Guid RequestMemberId { get; private set; }

        /// <summary>
        /// Участник заказа
        /// </summary>
        public RequestMember RequestMember { get; private set; }

        private Agreement()
        {
            
        }

        private Agreement(RequestMember member, DateTime date, string number)
        {
            RequestMember = member;
            AgreementDate = date;
            AgreementNumber = number;
            RequestMemberId = member.Id;
        }

        public static Result<Agreement, string[]> Create(RequestMember member, DateTime date, string number)
        {
            return new Agreement(member, date, number);
        }
    }
}