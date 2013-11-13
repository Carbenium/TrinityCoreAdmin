using log4net;

namespace TrinityCoreAdmin
{
    internal class Logger
    {
        public static readonly ILog LOG_GENERAL = LogManager.GetLogger("LOG_GENERAL");
        public static readonly ILog LOG_DATABASE = LogManager.GetLogger("LOG_DATABASE");
    }
}