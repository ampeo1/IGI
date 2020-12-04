using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI.logs
{
    public static class FileLoggerExtensions
    {
        public static ILoggerFactory AddFile(this ILoggerFactory factory, string allLogPath, string errorLogPath)
        {
            factory.AddProvider(new FileLoggerProvider(allLogPath, errorLogPath));
            return factory;
        }
    }
}
