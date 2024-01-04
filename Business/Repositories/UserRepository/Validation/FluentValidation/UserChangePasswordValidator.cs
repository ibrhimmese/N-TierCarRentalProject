using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.UserRepository.Validation.FluentValidation
{
    public class UserChangePasswordValidator : AbstractValidator<UserChangePasswordDto>
    {
        public UserChangePasswordValidator()
        {
            RuleFor(p => p.NewPassword).NotEmpty().WithMessage("Şifre boş bırakılamaz");
            RuleFor(p => p.NewPassword).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
            RuleFor(p => p.NewPassword).Matches("[A-Z]").WithMessage("Şifreniz en az bir büyük harf içermeli");
            RuleFor(p => p.NewPassword).Matches("[a-z]").WithMessage("Şifreniz en az bir küçük harf içermeli");
            RuleFor(p => p.NewPassword).Matches("[0-9]").WithMessage("Şifreniz en az bir sayı içermeli");
        }
    }
}
