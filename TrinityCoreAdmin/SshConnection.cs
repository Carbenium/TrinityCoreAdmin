using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;

namespace TrinityCoreAdmin
{
    internal class SshConnection : BaseConnection, IDisposable
    {
        private SshClient conn;

        /// <summary>
        /// List of open MySQL connections.
        /// </summary>
        protected static List<SshConnection> m_conn = new List<SshConnection>();

        /// <summary>
        /// Creates a new SSH connection.
        /// </summary>
        /// <param name="host">Hostname / IP</param>
        /// <param name="port">SSH port</param>
        /// <param name="user">SSH username</param>
        /// <param name="password">SSH password</param>
        public SshConnection(string host, int port, string user, string password)
        {
            this.conn = new SshClient(host, port, user, password);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.conn != null)
                {
                    this.conn.Disconnect();
                    this.conn.Dispose();
                    this.conn = null;
                }
            }
        }

        public delegate void ToggleConnectionStateHandler(object sender, OnConnectionStateEventArgs e);

        public event ToggleConnectionStateHandler OnToggleConnectionStateHandler;

        public void OnToggleConnectionState(OnConnectionStateEventArgs e)
        {
            if (OnToggleConnectionStateHandler != null)
                OnToggleConnectionStateHandler(this, e);
        }

        /// <summary>
        /// Closes a SSH connection.
        /// </summary>
        public override void Close()
        {
            conn.Disconnect();

            OnConnectionStateEventArgs e = new OnConnectionStateEventArgs(this, ConnectionState.Closed);
            OnToggleConnectionState(e);

            m_conn.Remove(this);
        }

        /// <summary>
        /// Opens a SSH connection.
        /// </summary>
        /// <returns>True if connection successfull</returns>
        public override bool Open()
        {
            if (!conn.IsConnected)
            {
                conn.Connect();

                OnConnectionStateEventArgs e = new OnConnectionStateEventArgs(this, ConnectionState.Open);
                OnToggleConnectionState(e);
            }
            if (conn.IsConnected)
            {
                m_conn.Add(this);
                return true;
            }
            return false;
        }

        public void AddForwardedPort(uint localPort, string host, uint port)
        {
            try
            {
                var dPort = new ForwardedPortLocal("127.0.0.1", localPort, host, 3306);
                conn.AddForwardedPort(dPort);
                dPort.Start();
            }
            catch (SocketException e)
            {
                Logger.LOG_SSH.Error(e.Message);
            }
            Logger.LOG_SSH.Debug(conn.ForwardedPorts.ToString());
        }

        /// <summary>
        /// Closes all open SSH connections.
        /// </summary>
        public static void CloseConnections()
        {
            for (int i = m_conn.Count - 1; i >= 0; i--)
            {
                m_conn[i].Close();
            }
        }
    }
}