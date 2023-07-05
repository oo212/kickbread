using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MyServer
{
    internal class MysqlManager
    {

        static string connectString = "server = 127.0.0.1;port = 3306;database = KickBread;user = root;password = 1206;";
        public static void InsertUser(int id,string account) 
        { 
            
            MySqlConnection msc = new MySqlConnection(connectString);

            try 
            { 
                msc.Open();

                string commandText = "INSERT INTO `kickbread`.`username` (`account`, `id`) VALUES ('"+account+"', '"+id+"');";
                MySqlCommand command = new MySqlCommand(commandText,msc);

                int num = command.ExecuteNonQuery();
                Console.WriteLine("num:"+ num);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            finally
            { 
                msc.Close(); 
                msc.Dispose();
            }
            
        }

        public static bool QueryAccount(string account)
        {

            MySqlConnection msc = new MySqlConnection(connectString);

            try
            {
                msc.Open();

                string commandText = "select account from kickbread.username where (account = '"+account+"');";
                MySqlCommand command = new MySqlCommand(commandText, msc);

                object o = command.ExecuteScalar();
                string str = "";
                str = (string)o;

                if (str != "")
                { return true; }
                else 
                { return false; }
             
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                msc.Close();
                msc.Dispose();
            }

            return false;
        }

        public static string QueryPassword(string account)
        {

            MySqlConnection msc = new MySqlConnection(connectString);
            string str = "";

            try
            {
                msc.Open();

                string commandText = "select password from kickbread.username where (account = '" + account + "');";
                MySqlCommand command = new MySqlCommand(commandText, msc);

                object o = command.ExecuteScalar();
                if (o != null)
                {
                    str = (string)o;
                    return str; 
                }
                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                msc.Close();
                msc.Dispose();
            }

            return str;
        }

        public static Player QueryPlayer(string account)
        {

            MySqlConnection msc = new MySqlConnection(connectString);
            
            Player player = new Player();
            player.id = -1;


            try
            {
                msc.Open();

                string commandText = "select id, username, bread_1, bread_2, bread_3, bread_4, bread_5 from kickbread.username where (account = '"+account+"');";
                MySqlCommand command = new MySqlCommand(commandText, msc);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                { 
                    int id = reader.GetInt32(0);
                    string username = reader.GetString(1);
                    int bread_1 = reader.GetInt32(2);
                    int bread_2 = reader.GetInt32(3);
                    int bread_3 = reader.GetInt32(4);
                    int bread_4 = reader.GetInt32(5);
                    int bread_5 = reader.GetInt32(6);

                    player.id = id;
                    player.username = username;
                    player.bread_1 = bread_1;
                    player.bread_2 = bread_2;
                    player.bread_3 = bread_3;
                    player.bread_4 = bread_4;
                    player.bread_5 = bread_5;

                    return player;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                msc.Close();
                msc.Dispose();
            }

            return player;
        }

        public static int UpdateUsername(string newusername, int id) 
        {
            MySqlConnection msc = new MySqlConnection(connectString);
            int num = 0;
            try
            {
                msc.Open();

                string commandText = "update kickbread.username set username='"+newusername+"' where(id= '"+id+"');";
                MySqlCommand command = new MySqlCommand(commandText, msc);

                num = command.ExecuteNonQuery();
                return num;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                msc.Close();
                msc.Dispose();
            }
            return num;
        }
    }
}

