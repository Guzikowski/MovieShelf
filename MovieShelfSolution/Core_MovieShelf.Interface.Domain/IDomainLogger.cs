using System;

namespace Core_MovieShelf.Interface.Domain
{
    public interface IDomainLogger
    {
        void Log(Exception exception, string message, ESeverityLevel severity);
        void LogMessage(string message, ESeverityLevel severity = ESeverityLevel.Debug);
        void LogException(Exception exception, ESeverityLevel severity = ESeverityLevel.Error);
    }
}
