namespace Koleso.Logging
{
    using System;

    public interface ILogger
    {
        void WriteMessage(string message);

        void WriteMessage(string messageTemplate, params object[] args);

        void WriteException(Exception exception);
    }
}
