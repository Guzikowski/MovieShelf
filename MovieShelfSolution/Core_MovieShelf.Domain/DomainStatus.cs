
using System;
using System.Collections.Generic;
using System.Linq;
using Core_MovieShelf.Interface.Domain;
using Core_MovieShelf.Interface.Domain.Contracts;

namespace Core_MovieShelf.Domain
{
    public class DomainStatus : IDomainStatus
    {
        public bool IsValid
        {
            get { return GetMessages(EMessageType.Error).Count == 0; }
        }

        public void ClearMessages(EMessageType msgType)
        {
            _messages = msgType == EMessageType.All 
                ? new List<IDomainMessage>() 
                : _messages.Where(item => item.Type != msgType).ToList();
        }

        public void AddMessage(IDomainMessage message)
        {
            new DomainLogger().LogMessage(message.Message);
            if (_messages.Where(item => item.Id == message.Id).Count() == 0)
            {
                _messages.Add(message);
            }
        }
        public void AddExceptionMessage(Exception exception)
        {
            new DomainLogger().LogException(exception);
            if (exception.InnerException != null)
            {

                var message = new DomainMessage
                {
                    Id = EMessageNumber.ExceptionMessage,
                    Message = string.IsNullOrEmpty(exception.InnerException.Message) ? string.Format("Exception: {0} Inner Exception: {1}", exception.Message, exception.InnerException.Message)
                                                               : string.Format("Exception: {0}", exception.Message),
                    Type = EMessageType.Error
                };
                _messages.Add(message);
            }
            else
            {
                var message = new DomainMessage
                {
                    Id = EMessageNumber.ExceptionMessage,
                    Message = string.Format("Exception: {0}", exception.Message),
                    Type = EMessageType.Error
                };
                _messages.Add(message);
            }
        }

        public IList<IDomainMessage> GetMessages(EMessageType msgType)
        {
            return msgType == EMessageType.All 
                ? _messages 
                : _messages.Where(item => item.Type == msgType).ToList();
        }

        public  IList<IDomainMessage> Messages
        {
            get { return _messages ?? (_messages = new List<IDomainMessage>()); }
        }
        private IList<IDomainMessage> _messages = new List<IDomainMessage>();

        public static DomainStatusContract ConvertToContract(IDomainStatus domainStatus)
        {
            if (domainStatus == null)
            {
                return new DomainStatusContract();
            }
            return new DomainStatusContract
                       {
                           Messages = domainStatus.Messages.Select(DomainMessage.ConvertToContract).ToList()
                       };
        }
    }
}
