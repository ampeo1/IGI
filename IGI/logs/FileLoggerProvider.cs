using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.logs
{
    public class FileLoggerProvider: ILoggerProvider
    {
        private string allLogPath;
        private string errorLogPath;
        public FileLoggerProvider(string allLogPath, string errorLogPath)
        {
            this.allLogPath = allLogPath;
            this.errorLogPath = errorLogPath;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(allLogPath, errorLogPath);
        }

        public void Dispose()
        {
        }
    }
}
