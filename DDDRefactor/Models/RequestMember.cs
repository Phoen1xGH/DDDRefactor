using CSharpFunctionalExtensions;

namespace DDDRefactor.Models
{
    public class RequestMember : BaseEntity
    {
        public Request Request { get; set; }

        public LegalPerson LegalPerson { get; set; }

        public ICollection<Product> Products { get; set; }

        /// <summary>
        /// Содержит в себе как входящие, так и исходящие вложения
        /// </summary>
        public ICollection<Attachment> Attachments { get; set; }

        public bool IsNotify { get; set; }

        public bool IsParticipate { get; set; }

        public DateTime? DateSend { get; set; }
        public Guid AgreementId { get; set; }

        public Agreement Agreement { get; set; }

        public Guid SpecificationId { get; set; }

        public Specification Specification { get; set; }

        private RequestMember()
        {
            
        }
        private RequestMember(Request request, LegalPerson legalPerson, 
            ICollection<Product> products,
            ICollection<Attachment> attachments, 
            bool isNotify, bool isParticipate, DateTime? dateSend, 
            Agreement agreement, Specification specification)
        {
            Request = request;
            LegalPerson = legalPerson;
            Products = products;
            Attachments = attachments;
            IsNotify = isNotify;
            IsParticipate = isParticipate;
            DateSend = dateSend;
            Agreement = agreement;
            AgreementId = Agreement.Id;
            Specification = specification;
            SpecificationId = specification.Id;
        }

        public static Result<RequestMember, string[]> Create(Request request, LegalPerson legalPerson,
            ICollection<Product> products,
            ICollection<Attachment> attachments,
            bool isNotify, bool isParticipate, DateTime? dateSend,
            Agreement agreement, Specification specification)
        {
            return new RequestMember(request, legalPerson, products, attachments, isNotify,
                isParticipate, dateSend, agreement, specification);
        }
    }
}