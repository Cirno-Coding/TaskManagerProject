using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppClinet
{
    public partial class MainForm : Form
    {
        private SessionUser _currentUser;
        public MainForm(SessionUser user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnStatusReq.Visible = _currentUser.SecurityLevel >= 1;
            btnEditReq.Visible = _currentUser.SecurityLevel >= 2;
            btnEditUsers.Visible = _currentUser.SecurityLevel >= 3;
        }
    }
}
