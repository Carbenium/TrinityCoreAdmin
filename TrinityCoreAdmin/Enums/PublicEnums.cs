namespace TrinityCoreAdmin
{
    public enum Expansion : int
    {
        EXPANSION_CLASSIC = 0,
        EXPANSION_TBC = 1,
        EXPANSION_WOTLK = 2
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