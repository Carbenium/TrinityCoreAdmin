using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Appender;

namespace TrinityCoreAdmin
{
    class Logger
    {
        public static readonly ILog LOG_GENERAL = LogManager.GetLogger("LOG_GENERAL");
        public static readonly ILog LOG_DATABASE = LogManager.GetLogger("LOG_DATABASE");
    }
}
