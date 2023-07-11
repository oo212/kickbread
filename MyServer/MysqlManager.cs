using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static bool QueryAccount(string account)
        {

            MySqlConnection msc = new MySqlConnection(connectString);

            try
            {
                msc.Open();

                string commandText = "select account from kickbread.username where (account = '"+account+"');";
                MySqlCommand command = new MySqlCommand(commandText, msc);

                object o = command.ExecuteScalar();
                if (o != null)
                { return true; }
             
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



            try
            {
                msc.Open();

                string commandText = "select username, password, BurgerBun, Bagel, Toast, Baguette, Breadstick from kickbread.username where (account = '" +account+"');";
                MySqlCommand command = new MySqlCommand(commandText, msc);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                { 
                    string username = reader.GetString(0);
                    string password = reader.GetString(1);
                    int bread_1 = reader.GetInt32(2);
                    int bread_2 = reader.GetInt32(3);
                    int bread_3 = reader.GetInt32(4);
                    int bread_4 = reader.GetInt32(5);
                    int bread_5 = reader.GetInt32(6);

                    player.account = account;
                    player.username = username;
                    player.BurgerBun = bread_1;
                    player.Bagel = bread_2;
                    player.Toast = bread_3;
                    player.Baguette = bread_4;
                    player.Breadstick = bread_5;

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

        public static int UpdateUsername(string newusername, string account) 
        {
            MySqlConnection msc = new MySqlConnection(connectString);
            int num = 0;
            try
            {
                msc.Open();

                string commandText = "update kickbread.username set username='"+newusername+"' where(account= '"+account+"');";
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

        public static bool InsertUser(string account, string password)
        {
            MySqlConnection msc = new MySqlConnection(connectString);
            int num = 0;
            try
            {
                msc.Open();

                string comandText = "INSERT INTO `kickbread`.`username` (`account`, `password`) VALUES ('" + account + "', '" + password + "');";
                MySqlCommand command = new MySqlCommand(comandText, msc);

                num = command.ExecuteNonQuery();
                if (num > 0)
                {
                    return true;
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
            return false;
        }

        public static bool QueryIsExistUsername(string username)
        {
            MySqlConnection msc = new MySqlConnection(connectString);

            try
            {
                msc.Open();

                string comandText = "select username from kickbread.username where (username = '" + username + "');";
                MySqlCommand command = new MySqlCommand(comandText, msc);

                object o = command.ExecuteScalar();
                if (o != null)
                {
                    return true;
                }
                else return false;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                msc.Close();
                msc.Dispose();//释放
            }
            return false;
        }

        public static List<RankingData> QueryRanking()
        {

            MySqlConnection msc = new MySqlConnection(connectString);

            List<RankingData> list = new List<RankingData>();

            try
            {
                msc.Open();
                Console.WriteLine("Query Ranking");

                string commandStr = "select username,BurgerBun,Bagel,Toast,Baguette,Breadstick from kickbread.username order by BurgerBun+Bagel+Toast+Baguette+Breadstick desc limit 5";
                MySqlCommand mySqlCommand = new MySqlCommand(commandStr, msc);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                bool a = false;
                for (int i = 0; i < 5; i++)
                {
                    a = reader.Read();
                    if (a)
                    {
                        RankingData ranking = new RankingData();

                        ranking.username = reader.GetString(0);

                        ranking.BurgerBun = reader.GetInt32(1);
                        ranking.Bagel = reader.GetInt32(2);
                        ranking.Toast = reader.GetInt32(3);
                        ranking.Baguette = reader.GetInt32(4);
                        ranking.Breadstick = reader.GetInt32(5);

                        list.Add(ranking);
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }

            finally
            {
                msc.Close();
                msc.Dispose();
            }
            return list;
        }

        public static int QueryMyRanking(string account)
        {
            MySqlConnection msc = new MySqlConnection(connectString);
            int myranking = 0;

            try
            {
                msc.Open();
                string commandStr = "select count(1) AS myranking_num from username where BurgerBun+Bagel+Toast+Baguette+Breadstick >= (SELECT BurgerBun+Bagel+Toast+Baguette+Breadstick FROM username where account = '" + account + "' )";
                MySqlCommand mySqlCommand = new MySqlCommand(commandStr, msc);

                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                bool b = reader.Read();
                if (b)
                {
                    myranking = reader.GetInt32(0);
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }

            finally
            {
                msc.Close();
                msc.Dispose();
            }
            return myranking;
        }

        public static int UpdateBreadNumber(string username, int burgerBun, int bagel, int toast, int baguette, int breadstick)
        {
            MySqlConnection msc = new MySqlConnection(connectString);
            int num = 0;
            try
            {
                msc.Open();

                string commandText = "UPDATE `kickbread`.`username` SET `BurgerBun` = '" + burgerBun + "', `Bagel` = '" + bagel + "', `Toast` = '" + toast + "', `Baguette` = '" + baguette + "', `Breadstick` = '" + breadstick + "' WHERE (`username` =  '" + username + "' )";
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

        public static bool SendBread(string username, string sendusername, string breadtype)
        {

            MySqlConnection msc = new MySqlConnection(connectString);
            int num = 0;
            try
            {
                msc.Open();

                string commandText = "update kickbread.username set " + breadtype + " = " + breadtype + " + 1 where (`username` =  '" + sendusername + "' )";
                MySqlCommand command = new MySqlCommand(commandText, msc);
                num = command.ExecuteNonQuery();

                string command_Text = "update kickbread.username set " + breadtype + " = " + breadtype + " - 1 where (`username` =  '" + username + "' )";
                MySqlCommand command_new = new MySqlCommand(command_Text, msc);
                num = command_new.ExecuteNonQuery();

                return true;
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

    }
}

