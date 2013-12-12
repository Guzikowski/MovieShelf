using System;
using System.Collections;
using Core_MovieShelf.Interface.Domain;
using log4net;
using log4net.Config;

namespace Core_MovieShelf.Domain
{
    public class DomainLogger : IDomainLogger
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(DomainLogger));

        public DomainLogger()
        {
            //BasicConfigurator.Configure();
            XmlConfigurator.Configure();

        }

        public void LogMessage(string message, ESeverityLevel severity = ESeverityLevel.Debug)
        {
            Log(null, message, severity);
        }

        public void LogException(Exception exception, ESeverityLevel severity = ESeverityLevel.Error)
        {
            Log(exception, null, severity);
        }

        public void Log(Exception exception, string contextMessage, ESeverityLevel level)
        {
            string message = String.Empty;

            if (!String.IsNullOrEmpty(contextMessage))
                message = contextMessage + "\r\n";

            if (exception != null)
            {
                foreach (DictionaryEntry item in exception.Data)
                {
                    message += string.Format("{0} : {1}\r\n", item.Key, item.Value);
                }

                Exception ex = exception;
                while (ex != null)
                {
                    message += String.Format("{0}\r\n{1}\r\n", ex.Message, ex.StackTrace);
                    ex = ex.InnerException;
                }
            }
            Console.WriteLine(message);
            ProcessLogMessage(message, exception, level);
        }



        
        private void ProcessLogMessage(string message, Exception exception, ESeverityLevel level)
        {

            switch (level)
            {
                case ESeverityLevel.Debug:
                    if (_logger.IsDebugEnabled)
                        _logger.Debug(message, exception);
                    break;

                case ESeverityLevel.Information:
                    if (_logger.IsInfoEnabled)
                        _logger.Info(message, exception);
                    break;

                case ESeverityLevel.Warning:
                    if (_logger.IsWarnEnabled)
                        _logger.Warn(message, exception);
                    break;

                case ESeverityLevel.Error:
                    if (_logger.IsErrorEnabled)
                        _logger.Error(message, exception);
                    break;

                case ESeverityLevel.Fatal:
                    if (_logger.IsFatalEnabled)
                        _logger.Fatal(message, exception);
                    break;

                default:
                    if (_logger.IsErrorEnabled)
                        _logger.Error(message, exception);
                    break;

            }

        }

    }
}
