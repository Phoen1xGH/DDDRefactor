using CSharpFunctionalExtensions;
using DDDRefactor.Models.ValueObjects;

namespace DDDRefactor.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Patronymic { get; set; }

        public string? Email { get; set; }

        public PhoneNumber PhoneNumber { get; set; }

        public UserPermissions AccessRights { get; set; }

        public string FullName { get; }

        private User()
        {
            
        }
        private User(string username, string passwordHash, 
            string? firstName, string? lastName, 
            string? patronymic, string? email, PhoneNumber phoneNumber,
            UserPermissions accessRights)
        {
            Username = username;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Email = email;
            PhoneNumber = phoneNumber;
            AccessRights = accessRights;
            FullName = string.Join(" ", [FirstName, LastName, Patronymic]);
        }

        public static Result<User, string[]> Create(string username, string passwordHash,
            string? firstName, string? lastName,
            string? patronymic, string? email, PhoneNumber phoneNumber,
            UserPermissions accessRights)
        {
            return new User(username, passwordHash, firstName, lastName, patronymic, email, phoneNumber, accessRights);
        }
    }
}