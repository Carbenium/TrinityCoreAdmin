using System;
using System.Data;

namespace TrinityCoreAdmin
{
    /// <summary>
    /// EventArgs for connection change events (SQL)
    /// </summary>
    public class OnConnectionStateEventArgs : EventArgs
    {
        public OnConnectionStateEventArgs(BaseConnection conn, ConnectionState connState)
        {
            this.conn = conn;
            this.connState = connState;
        }

        public BaseConnection conn
        { get; private set; }

        public ConnectionState connState
        { get; private set; }
    }
}