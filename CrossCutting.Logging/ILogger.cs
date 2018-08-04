using System;

namespace CrossCutting.Logging
{
    public interface ILogger
    {
        void Error(string message, Exception ex);

        void Error(Exception exception);

        void Information(string message);
    }
}
