using System;
using System.Collections.Generic;
using Core_MovieShelf.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;

namespace Wcf_MovieShelf
{
    public abstract class BaseService
    {
        private readonly DomainLogger _logger = new DomainLogger();
       
        protected TEntityContract HandleExceptionResponse<TEntity, TEntityContract>(Exception exception)
            where TEntity : BaseDomain, new()
            where TEntityContract : BaseDomainContract, new()
        {
            Console.WriteLine(exception.Message);
            if (exception.InnerException != null)
            {
                Console.WriteLine(exception.InnerException.Message);
            }
            var errResult = new TEntity();
            errResult.DomainStatus.AddExceptionMessage(exception);
            var returnErrResult = errResult.ConvertToContract(errResult, new TEntityContract());
            _logger.LogException(exception);
            return returnErrResult;
        }
        protected DomainStatusContract HandleExceptionResponse(Exception exception)
        {
            Console.WriteLine(exception.Message);
            if (exception.InnerException != null)
            {
                Console.WriteLine(exception.InnerException.Message);
            }
            var errResult = new DomainStatus();
            errResult.AddExceptionMessage(exception);
            var returnErrResult = DomainStatus.ConvertToContract(errResult);
            _logger.LogException(exception);
            return returnErrResult;
        }
        protected DomainListContract<TEntityContract> HandleExceptionResponse<TEntityContract>(Exception exception)
            where TEntityContract : BaseDomainContract
        {
            _logger.LogException(exception);
            return new DomainListContract<TEntityContract>
            {
                DomainStatus = HandleExceptionResponse(exception),
                IsValid = false
                //TODO: Send back empty collection not null
            };
        }

    }
}