using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyServer
{
    public partial class MyServer : Form
    {
        public MyServer()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            //Server server = new Server("127.0.0.1",4499);
            Server server = new Server("10.0.0.0/8", 4499);
            server.Start();
            button_start.Enabled = false;
        }

    }
}
