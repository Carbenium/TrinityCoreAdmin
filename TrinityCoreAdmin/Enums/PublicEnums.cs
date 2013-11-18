namespace TrinityCoreAdmin
{
    public enum Expansion : int
    {
        CLASSIC = 0,
        TBC = 1,
        WOTLK = 2
    }

    public enum MySQLError
    {
        MYSQLERROR_CAN_NOT_CONNECT = 0,
        MYSQLERROR_INV_USER_PASS = 1045
    }

    public enum RealmsStatus
    {
        SAVED = 0,
        CHANGED = 1,
        NEW = 2
    }
}