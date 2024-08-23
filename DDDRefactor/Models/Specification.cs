using CSharpFunctionalExtensions;

namespace DDDRefactor.Models
{
    public class Specification : BaseEntity
    {
        /// <summary>
        /// Номер спецификации
        /// </summary>
        public string SpecificationNumber { get; set; }

        /// <summary>
        /// Дата спецификации
        /// </summary>
        public DateTime SpecificationDate { get; set; }

        public Guid RequestMemberId { get; set; }

        /// <summary>
        /// Участник заказа
        /// </summary>
        public RequestMember RequestMember { get; set; }

        private Specification()
        {
            
        }
        private Specification(string specificationNumber, DateTime specificationDate, RequestMember requestMember)
        {
            SpecificationNumber = specificationNumber;
            SpecificationDate = specificationDate;
            RequestMemberId = requestMember.Id;
            RequestMember = requestMember;
        }

        public static Result<Specification, string[]> Create(
            string specificationNumber, DateTime specificationDate, 
            Guid requestMemberId, RequestMember requestMember)
        {
            return new Specification(specificationNumber, specificationDate, requestMember);
        }
    }
}