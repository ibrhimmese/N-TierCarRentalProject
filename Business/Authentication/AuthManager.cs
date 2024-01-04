using Business.Authentication.UserFluentValidation;
using Business.Repositories.UserRepository;
using Core.Aspect.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Hashing;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Authentication
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;    

        public AuthManager(IUserService userService, ITokenHandler tokenHandler)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
        }

        public IDataResult<Token> Login(LoginAuthDto loginDto)
        {
            var user = _userService.GetByEmail(loginDto.Email);
            var result = HashingHelper.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt);
            List<OperationClaim> operationClaims = _userService.GetUserOperationClaims(user.Id);
            if (result)
            {
                Token token = new Token();
                token = _tokenHandler.CreateToken(user, operationClaims);
                return new SuccessDataResult<Token> (token);
            }
            return new ErrorDataResult<Token>("Kullanıcı mail ya da şifre bilgisi yanlış");
        }
        
        [ValidationAspect(typeof(AuthValidator))] //işlemden önce
                                                  // [LogAspect] //İşlem bittikten sonra
        public IResult Register(RegisterAuthDto registerDto)
        {

            IResult result = BusinessRules.Run(
                CheckIfEmailExists(registerDto.Email),
                CheckIfImageExtensionsAllow(registerDto.Image.FileName),
                CheckIfImagesIsLessThanOneMb(registerDto.Image.Length)
               );

            if (result != null)
            {
                return result;
            }

            _userService.Add(registerDto);
            return new SuccessResult("Kullanıcı Kaydı başarıyla tamamlandı");

        }

        private IResult CheckIfEmailExists(string email)
        {
            var list = _userService.GetByEmail(email);
            if (list != null)
            {
                return new ErrorResult("Bu Mail adresi daha önce kullanılmıştır.");
            }
            return new SuccessResult();
        }

        private IResult CheckIfImagesIsLessThanOneMb(long imgSize)
        {
            decimal imgMbSize = Convert.ToDecimal(imgSize * 0.000001);
            if (imgMbSize > 1)
            {
                return new ErrorResult("Resim boyutu 1mb dan büyük olamaz");
            }
            return new SuccessResult();
        }
        private IResult CheckIfImageExtensionsAllow(string fileName)
        {
            var ext = fileName.Substring(fileName.LastIndexOf('.'));
            var extension = ext.ToLower();
            List<string> AllowFileExtensions = new List<string>() { ".jpg", ".jpeg", ".gif", ".png", ".ico" };
            if (!AllowFileExtensions.Contains(extension))
            {
                return new ErrorResult("Doğru uzantı eklememdiniz!!");
            }
            return new SuccessResult();
        }
    }
}
