using System;
using System.Collections.Generic;
using System.Text;
using CrossCutting.Utils.Extensions;
using Serilog;

namespace CrossCutting.Logging
{
    public class Logger : ILogger
    {
        private const string OutputTemplate = "{CustomMessage}";

        public void Error(Exception exception)
        {
            Error(exception.GetDetail(), exception);
        }

        public void Error(string message, Exception ex)
        {
            Log.Error(ex, OutputTemplate, message);
        }

        public void Information(string message)
        {
            Log.Information(message);
        }
    }
}
