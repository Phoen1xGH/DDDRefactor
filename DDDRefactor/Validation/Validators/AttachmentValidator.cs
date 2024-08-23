using DDDRefactor.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DDDRefactor.Validation.Validators
{
    public class AttachmentValidator : AbstractValidator<Attachment>
    {
        public AttachmentValidator()
        {
            RuleFor(x => x.Request)
                .NotNull().WithMessage("Заявка должна быть указана!");

            RuleFor(x => x.FileName)
                .NotEmpty().WithMessage("Путь к файлу не должен быть пустым");
        }       
    }
}

