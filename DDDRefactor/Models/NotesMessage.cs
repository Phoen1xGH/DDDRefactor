using CSharpFunctionalExtensions;

namespace DDDRefactor.Models
{
    public class NotesMessage : BaseEntity
    { 
        /// <summary>
        /// Дата отправки сообщения
        /// </summary>
        public DateTime MessageDate { get; private set; }

        /// <summary>
        /// Сообщение
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Пользователь который отправил сообщение
        /// </summary>
        public User User { get; private set; }

        private NotesMessage(User user, string message, DateTime messageDate) 
        {
            Message = message;
            MessageDate = messageDate;
            User = user;
        }

        private NotesMessage()
        {
            
        }
        public Result<NotesMessage, string[]> Create(User user, string message, DateTime messageDate)
        {
            return new NotesMessage(user, message, messageDate);
        }
    }
}