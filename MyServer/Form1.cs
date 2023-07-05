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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            Server server = new Server("127.0.0.1",4499);
            //Server server = new Server("10.0.0.14", 4999);//放服务器上时使用内网IP
            server.Start();
            button_start.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MysqlManager.InsertUser(123654,"stest");

            Player player = MysqlManager.QueryPlayer("abc");
            Console.WriteLine("id:" + player.id);

        }
    }
}
