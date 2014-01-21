namespace TrinityCoreAdmin
{
    public enum Expansion : int
    {
        CLASSIC = 0,
        TBC = 1,
        WOTLK = 2
    }

    public enum Gender : int
    {
        MALE = 0,
        FEMALE = 1
    }

    public enum Race : int
    {
        NONE = 0,
        HUMAN = 1,
        ORC = 2,
        DWARF = 3,
        NIGHTELF = 4,
        UNDEAD = 5,
        TAUREN = 6,
        GNOME = 7,
        TROLL = 8,
        BLOODELF = 10,
        DRAENEI = 11
    }

    public enum Class : int
    {
        NONE = 0,
        WARRIOR = 1,
        PALADIN = 2,
        HUNTER = 3,
        ROGUE = 4,
        PRIEST = 5,
        DEATH_KNIGHT = 6,
        SHAMAN = 7,
        MAGE = 8
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

    public enum AccountOpResult
    {
        AOR_OK,
        AOR_NAME_TOO_LONG,
        AOR_PASS_TOO_LONG,
        AOR_EMAIL_TOO_LONG,
        AOR_NAME_ALREADY_EXIST,
        AOR_NAME_NOT_EXIST,
        AOR_INTERNAL_ERROR
    }
}