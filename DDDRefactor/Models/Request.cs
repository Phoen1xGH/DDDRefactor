using CSharpFunctionalExtensions;
using DDDRefactor.Enums;
using DDDRefactor.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRefactor.Models
{
    public class Request : BaseEntity
    {
        public int RequestNumber { get; private set; }

        public RequestStatus Status { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        public RequestType RequestType { get; private set; }

        public ICollection<RequestMember> RequestMembers { get; private set; }

        public string? Info { get; private set; }

        /// <summary>
        /// Для сообщений в примечении
        /// </summary>
        public ICollection<NotesMessage> NotesMessage { get; private set; }

        public ICollection<Attachment> Attachments { get; private set; }

        public bool IsArchived { get; private set; }

        public DateTime DateReceiving { get; private set; }

        public DateTime DateMailing { get; private set; }

        public DateTime DateAnswering { get; private set; }

        public DateTime DateSending { get; private set; }

        private Request()
        {
            
        }
        private Request(
            int requestNumber, RequestStatus status, RequestType requestType, 
            ICollection<RequestMember> requestMembers,
            string? info, ICollection<NotesMessage> notesMessage, 
            ICollection<Attachment> attachments, 
            DateTime dateReceiving, DateTime dateMailing,
            DateTime dateAnswering, DateTime dateSending)
        {
            RequestNumber = requestNumber;
            Status = status;
            RequestType = requestType;
            RequestMembers = requestMembers;
            Info = info;
            NotesMessage = notesMessage;
            Attachments = attachments;
            IsArchived = false;
            DateReceiving = dateReceiving;
            DateMailing = dateMailing;
            DateAnswering = dateAnswering;
            DateSending = dateSending;
        }

        public static Result<Request, string[]> Create(
            int requestNumber, RequestStatus status, RequestType requestType,
            ICollection<RequestMember> requestMembers,
            string? info, ICollection<NotesMessage> notesMessage,
            ICollection<Attachment> attachments, bool isArchived,
            DateTime dateReceiving, DateTime dateMailing,
            DateTime dateAnswering, DateTime dateSending)
        {
            return new Request(requestNumber, status, requestType, 
                requestMembers, info, notesMessage, attachments,
                dateReceiving, dateMailing, dateAnswering, dateSending);
        }

        public void MoveToArchive()
        {
            IsArchived = true;
        }

        public void Restore()
        {
            IsArchived = false;
        }
    }
}
