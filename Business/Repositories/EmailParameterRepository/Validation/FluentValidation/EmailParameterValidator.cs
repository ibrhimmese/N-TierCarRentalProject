using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.EmailParameterRepository.Validation.FluentValidation
{
    public class EmailParameterValidator:AbstractValidator<EmailParameter>
    {
        public EmailParameterValidator()
        {
            RuleFor(p => p.Smtp).NotEmpty().WithMessage("SMTP Adresi boş olamaz");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Mail Adresi boş olamaz");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(p => p.Port).NotEmpty().WithMessage("Port boş olamaz");
        }
    }
}
