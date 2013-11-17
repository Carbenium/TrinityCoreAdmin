namespace TrinityCoreAdmin
{
    public abstract class BaseConnection
    {
        public abstract void Close();

        public abstract bool Open();
    }
}