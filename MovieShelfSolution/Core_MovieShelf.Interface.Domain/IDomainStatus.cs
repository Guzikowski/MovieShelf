using System;
using System.Collections.Generic;

namespace Core_MovieShelf.Interface.Domain
{

    
    public interface IDomainStatus
    {
        bool IsValid { get; }
        void ClearMessages(EMessageType msgType);
        void AddMessage(IDomainMessage message);
        void AddExceptionMessage(Exception exception);
        IList<IDomainMessage> GetMessages(EMessageType msgType);
        IList<IDomainMessage> Messages { get; }
    }
}
