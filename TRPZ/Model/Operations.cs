using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace TRPZ
{
    class Operations
    {
        private SqlConnection connection;

        public Operations()
        {
            connection = ConnectionClass.Connection;
        }

        public string DeleteUser(int id)
        {
            string sqlExpression = string.Format("DELETE FROM Actions WHERE User_Id={0}\n"
                + "DELETE FROM Users WHERE User_Id={0}", id);


            string checkSqlString = string.Format("SELECT * FROM Users WHERE User_Id={0}", id);
            SqlCommand check = new SqlCommand(checkSqlString, connection);
            SqlDataReader reader = check.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return "There is no user with this id";
            }
            reader.Close();

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
            reader.Close();
            return "User deleted";

        }

        public ObservableCollection<User> GetUsers()
        {
            ObservableCollection<User> listOfItems = new ObservableCollection<User>();

            string getItemsSql = string.Format("SELECT * FROM Users");
            SqlCommand getItems = new SqlCommand(getItemsSql, connection);
            SqlDataReader reader = getItems.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();

                return listOfItems;
            }


            while (reader.Read())
            {
                object id = reader.GetValue(0);
                object fname = reader.GetValue(1);
                object lname = reader.GetValue(2);
                object accessLevel = reader.GetValue(3);
                object password = reader.GetValue(4);
                object login = reader.GetValue(5);
                listOfItems.Add(new User((int)id, (string)fname, (string)lname, (int)accessLevel, (string)login, (string)password));
            }

            string res = "";

            foreach (User i in listOfItems)
            {
                res += i;
            }
            reader.Close();
            return listOfItems;
        }

        public string UpdateUser(User user)
        {
            string sqlExpression = string.Format("UPDATE Users SET FName='{0}', LName='{1}', Access_level={2}, Login='{3}', Password='{4}' WHERE User_Id = {5}", user.FName, user.LName, user.AccessLevel, user.Login, user.Password, user.ID);

            string checkSqlString = string.Format("SELECT * FROM Users WHERE User_Id={0}", user.ID);
            SqlCommand check = new SqlCommand(checkSqlString, connection);
            SqlDataReader reader = check.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return "There is no user with this id";
            }
            reader.Close();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
            return "User updated";
        }


        public void AddNewItem(string name, double price, string producer)
        {
            string sqlExpression = string.Format("INSERT INTO Items (Name, Price, Producer) VALUES('{0}', {1}, '{2}')", name, price, producer);

            string checkSqlString = string.Format("SELECT * FROM Items WHERE Name='{0}'", name);
            SqlCommand check = new SqlCommand(checkSqlString, connection);
            SqlDataReader reader = check.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                Console.WriteLine("There is a such item already");
                return;
            }
            reader.Close();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();

        }

        public void DellItem(int id)
        {
            string sqlExpression = string.Format("DELETE FROM Actions WHERE Item_Id={0}\n"
                + "DELETE FROM Items WHERE Item_Id={0}", id);


            string checkSqlString = string.Format("SELECT * FROM Items WHERE Item_Id={0}", id);
            SqlCommand check = new SqlCommand(checkSqlString, connection);
            SqlDataReader reader = check.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                Console.WriteLine("There is no such item");
                return;
            }
            reader.Close();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
            reader.Close();
            Console.WriteLine("Item deleted");
            return;
        }

        public void UpdateItem(Item item)
        {
            string sqlExpression = string.Format("UPDATE Items SET Name='{0}', Price={1}, Producer='{2}', Number={3} WHERE Item_Id={4}", item.Name, item.Price, item.Producer, item.NumberInStock, item.ID);


            string checkSqlString = string.Format("SELECT * FROM Items WHERE Item_Id={0}", item.ID);
            SqlCommand check = new SqlCommand(checkSqlString, connection);
            SqlDataReader reader = check.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                Console.WriteLine("There is no item with this id");
                return;
            }
            reader.Close();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Item updated");
            return;
        }

        public void Deliver(int id, int number)
        {


            string checkSqlString = string.Format("SELECT * FROM Items WHERE Item_Id={0}", id);
            SqlCommand check = new SqlCommand(checkSqlString, connection);
            SqlDataReader reader = check.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                Console.WriteLine("There is no item with this id");
                return;
            }

            reader.Read();
            object currNumber = reader.GetValue(4);
            reader.Close();

            string sqlExpression = "";

            sqlExpression = string.Format("UPDATE Items SET Number={0} WHERE Item_Id={1}", ((int)currNumber) + number, id);
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();

            Console.WriteLine("Items delivered");

        }

        public void Sell(int id, int number)
        {

            string checkSqlString = string.Format("SELECT * FROM Items WHERE Item_Id={0}", id);
            SqlCommand check = new SqlCommand(checkSqlString, connection);
            SqlDataReader reader = check.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                Console.WriteLine("There is no item with this id");
                return;
            }

            reader.Read();
            object currNumber = reader.GetValue(4);
            reader.Close();
            if ((int)currNumber - number < 0)
            {
                Console.WriteLine("There is not enough items in the stock");
                return;
            }

            string commandString = string.Format("UPDATE Items SET Number={0} WHERE Item_Id={1}", (int)currNumber - number, id);
            SqlCommand sellCommand = new SqlCommand(commandString, connection);
            sellCommand.ExecuteNonQuery();

            Console.WriteLine("{0} items were sold", number);

        }

        public ObservableCollection<Item> GetItems()
        {
            ObservableCollection<Item> listOfItems = new ObservableCollection<Item>();

            string getItemsSql = string.Format("SELECT * FROM Items");
            SqlCommand getItems = new SqlCommand(getItemsSql, connection);
            SqlDataReader reader = getItems.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();

                return listOfItems;
            }


            while (reader.Read())
            {
                object id = reader.GetValue(0);
                object name = reader.GetValue(1);
                object price = reader.GetValue(2);
                object producer = reader.GetValue(3);
                object number = reader.GetValue(4);
                listOfItems.Add(new Item((int)id, (string)name, (double)price, (string)producer, (int)number));
            }

            string res = "";

            foreach (Item i in listOfItems)
            {
                res += i;
            }
            reader.Close();
            return listOfItems;
        }

        public string AddNewUser(string fName, string lName, int accessLevel, string login, string password)
        {
            string sqlExpression = string.Format("INSERT INTO Users (FName, LName, Access_level, Login, Password) VALUES('{0}', '{1}', {2}, '{3}', '{4}')", fName, lName, accessLevel, login, password );

            string checkSqlString = string.Format("SELECT * FROM Users WHERE login='{0}'", login);
            SqlCommand check = new SqlCommand(checkSqlString, connection);
            SqlDataReader reader = check.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return "There is a user with this name";
            }
            reader.Close();

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
            return "User was added";        
        }

        public bool Login(string login, string password)
        {
            string sqlExpression = $"SELECT * FROM Users WHERE Login='{login}'";
            SqlCommand command = new SqlCommand(sqlExpression, ConnectionClass.Connection);
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return false;
            }
            else
            {
                reader.Close();
                sqlExpression = $"SELECT Password FROM Users WHERE Login='{login}'";
                command = new SqlCommand(sqlExpression, ConnectionClass.Connection);
                reader = command.ExecuteReader();
                reader.Read();
                string passwordFromDB = ((string)reader.GetValue(0)).Trim(' ');
                reader.Close();
                if(password.Equals(passwordFromDB))
                {
                    sqlExpression = $"SELECT * FROM Users WHERE Login='{login}'";
                    command = new SqlCommand(sqlExpression, ConnectionClass.Connection);
                    reader = command.ExecuteReader();
                    reader.Read();

                    int id = (int)reader.GetValue(0);
                    string fname = ((string)reader.GetValue(1)).Trim(' ');
                    string lname = ((string)reader.GetValue(2)).Trim(' ');
                    int accessLevel = (int)reader.GetValue(3);
                    User currUser = new User(id, fname, lname, accessLevel, login, password);
                    ConnectionClass.CurrUser = currUser;

                    reader.Close();

                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

    }
}
