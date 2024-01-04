using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Authentication.UserFluentValidation
{
    public class AuthValidator : AbstractValidator<RegisterAuthDto>
    {
        public AuthValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Mail Adresi boş olamaz");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz");
            RuleFor(p => p.Image.FileName).NotEmpty().WithMessage("Kullanıcı resmi boş olamaz");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz");
            RuleFor(p => p.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifreniz en az bir büyük harf içermeli");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifreniz en az bir küçük harf içermeli");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifreniz en az bir sayı içermeli");
            // RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az bir özel karakter içermeli");


        }
    }
}
