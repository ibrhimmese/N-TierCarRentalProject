﻿using Business.Repositories.OperationClaimRepository;
using Business.Repositories.OperationClaimRepository.Constans;
using Business.Repositories.UserOperationClaimRepository.Constans;
using Business.Repositories.UserOperationClaimRepository.Validation.FluentValidation;
using Business.Repositories.UserRepository;
using Core.Aspect.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories.UserOperationClaimRepository
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserService _userService;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IOperationClaimService operationClaimService, IUserService userService)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _operationClaimService = operationClaimService;
            _userService = userService;
        }




        [ValidationAspect(typeof(UserOperationClaimValidator))]
       public IResult Add(UserOperationClaim userOperationClaim)
        {
            IResult result = BusinessRules.Run(
                IsUserExist(userOperationClaim.UserId),
                IsOperationClaimExist(userOperationClaim.OperationClaimId),
                IsOperationSetExistForAdd(userOperationClaim)
                );
            if (result != null)
            {
                return result;
            }

            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(UserOperationClaimMessages.AddedUserOperationClaim);
        }


        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(UserOperationClaimMessages.DeleteUserOperationClaim);
        }

        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(p => p.Id == id));
        }

        public IDataResult<List<UserOperationClaim>> GetList()
        {
           return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }


        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            IResult result = BusinessRules.Run(
               IsUserExist(userOperationClaim.UserId),
               IsOperationClaimExist(userOperationClaim.OperationClaimId),
               IsOperationSetExistForUpdate(userOperationClaim)
               );
            if (result != null)
            {
                return result;
            }

            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(UserOperationClaimMessages.UpdateUserOperationClaim);
        }

        public IResult IsOperationClaimExist(int operationClaimId)
        {
            var result = _operationClaimService.GetById(operationClaimId).Data;
            if (result == null)
            {
                return new ErrorResult(UserOperationClaimMessages.OperationClaimExist);
            }
            return new SuccessResult();
        }


        public IResult IsUserExist(int userId)
        {
            var result = _userService.GetById(userId).Data;
            if (result == null)
            {
                return new ErrorResult(UserOperationClaimMessages.UserNotExist);
            }
            return new SuccessResult();
        }

        public IResult IsOperationSetExistForAdd(UserOperationClaim userOperationClaim)
        {
            var result=_userOperationClaimDal.Get(p=>p.UserId == userOperationClaim.UserId && p.OperationClaimId==userOperationClaim.OperationClaimId);
            if(result !=null)
            {
                return new ErrorResult(UserOperationClaimMessages.IsOperationClaimSetExist);
            }
            return new SuccessResult();
        }

        private IResult IsOperationSetExistForUpdate(UserOperationClaim userOperationClaim)
        {
            var currentUserOperationClaim = _userOperationClaimDal.Get(p => p.Id == userOperationClaim.Id);
            if (currentUserOperationClaim.UserId != userOperationClaim.UserId || currentUserOperationClaim.OperationClaimId != userOperationClaim.OperationClaimId)
            {
                var result = _userOperationClaimDal.Get(p => p.UserId == userOperationClaim.UserId && p.OperationClaimId == userOperationClaim.OperationClaimId);
                if (result != null)
                {
                    return new ErrorResult(UserOperationClaimMessages.IsOperationClaimSetExist);
                }          
            }
            return new SuccessResult();
        }


    }
}
