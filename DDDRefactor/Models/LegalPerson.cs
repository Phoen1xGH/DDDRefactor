using CSharpFunctionalExtensions;

namespace DDDRefactor.Models
{
    public class LegalPerson : BaseEntity
    {
        public string Name { get; private set; }

        /// <summary>
        /// Tax identification number - Идентификационный номер налогоплательщика
        /// </summary>
        public string? TIN { get; private set; }

        public string? City { get; private set; }

        public string? MailingAddress { get; private set; }

        public ICollection<Contact>? Contacts { get; private set; }

        private LegalPerson()
        {
            
        }
        private LegalPerson(string name, string? tIN, string? city, 
            string? mailingAddress, ICollection<Contact>? contacts)
        {
            Name = name;
            TIN = tIN;
            City = city;
            MailingAddress = mailingAddress;
            Contacts = contacts;
        }

        public static Result<LegalPerson, string[]> Create(
            string name, string? tIN, string? city,
            string? mailingAddress, ICollection<Contact>? contacts)
        {
            return new LegalPerson(name, tIN, city, mailingAddress, contacts);
        }
    } 
}