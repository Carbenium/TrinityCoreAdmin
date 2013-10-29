using System.Reflection;
using System.Windows.Forms;

namespace TrinityCoreAdmin
{
    public class AccountListView : ListView
    {
        private readonly PropertyInfo[] _pinfo;

        public AccountListView()
        {
            _pinfo = typeof(Account).GetProperties();

            Init();
        }

        public void Init()
        {
            Items.Clear();
            Columns.Clear();

            foreach (PropertyInfo pInfo in _pinfo)
            {
                Columns.Add(pInfo.Name);
            }

            foreach (ColumnHeader header in Columns)
            {
                header.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
    }
}