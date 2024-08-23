using CSharpFunctionalExtensions;
using DDDRefactor.Enums;
using DDDRefactor.Validation;
using DDDRefactor.Validation.Extensions;
using DDDRefactor.Validation.Validators;
using FileSystem = System.IO.Path;

namespace DDDRefactor.Models
{
    public class Attachment : BaseEntity
    {
        public string FileName { get; private set; }

        public Request Request { get; private set; }
        public AttachmentType Type { get; private set; }

        private Attachment(Request request, string fileName, AttachmentType type)
        {
            FileName = fileName;
            Request = request;
            Type = type;
        }

        private Attachment()
        {
            
        }
        public static Result<Attachment, string[]> Create(Request request, string fileName, AttachmentType type)
        {
            /*//if (request is null)
            //    return Result.Failure<Attachment>("Заявка должна быть указана!");

            //if (string.IsNullOrWhiteSpace(filePath))
            //    return Result.Failure<Attachment>("Путь к файлу не должен быть пустым");

            //var identifierResult = new OSIdentifier().GetRegexPatternByCurrentOS();

            //if (identifierResult.IsFailure)
            //    return Result.Failure<Attachment>(identifierResult.Error);
            //else if(!Regex.IsMatch(filePath, identifierResult.Value))
            //    return Result.Failure<Attachment>("Путь к файлу не валиден!");*/

            var attachment = new Attachment(request, fileName, type);

            var validationResult = new AttachmentValidator().Validate(attachment);

            if (!validationResult.IsValid)
                return validationResult.GetValidationErrors();

            return attachment;
        }
    }
}
