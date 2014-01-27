namespace Koleso.Logging
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;

    using log4net;
    using log4net.Config;

    public class Logger : ILogger
    {
        private const string LoggingConfigFileNameTemplate = "{0}.dll.config";

        public Logger()
        {
            var assemblyNameWithoutExtension = this.GetType().Assembly.GetName().Name;
            var configFileName = string.Format(LoggingConfigFileNameTemplate, assemblyNameWithoutExtension);

            var folderPath = AppDomain.CurrentDomain.BaseDirectory;
            var fullConfigFileName = Path.Combine(folderPath, configFileName);

            var fileInfo = new FileInfo(fullConfigFileName);

            if (fileInfo.Exists)
            {
                XmlConfigurator.Configure(fileInfo);
            }
            else
            {
                // loads configuration from default config-file
                XmlConfigurator.Configure();
            }
        }

        public void WriteMessage(string message)
        {
            ILog logger = this.GetLogger();
            logger.Info(message);
        }

        public void WriteMessage(string messageTemplate, params object[] args)
        {
            var message = string.Format(messageTemplate, args);
            ILog logger = this.GetLogger();
            logger.Info(message);
        }

        public void WriteException(Exception exception)
        {
            ILog logger = this.GetLogger();

            var baseException = exception.GetBaseException();

            logger.Error(baseException.Message);
            logger.Error(baseException.StackTrace);
        }

        private ILog GetLogger()
        {
            var stackTrace = new StackTrace();

            Type declaringType = null;
            var index = 2;
            while (declaringType == null && index >= 0)
            {
                var stackFrame = stackTrace.GetFrame(index);
                MethodBase methodBase = stackFrame.GetMethod();

                if (methodBase != null)
                {
                    declaringType = methodBase.DeclaringType;
                }

                index--;
            }

            ILog logger = declaringType != null
                ? LogManager.GetLogger(declaringType)
                : LogManager.GetLogger("DeclaringTypeIsNotDetermined");

            return logger;
        }
    }
}
