using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TP2.Connection;
using System.Data;
using MySql.Data.MySqlClient;

namespace TP2.Interfaces
{
    class Teacher : IPerson
    {
        private String rollNum;
        protected String name, lname;
        public Teacher(String name, String lname, String rollNum)
        {
            this.name = name;
            this.lname = lname;
            this.rollNum = rollNum;
        }

        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public String Lname
        {
            get
            {
                return this.lname;
            }
            set
            {
                this.lname = value;
            }
        }
        public String RollNum
        {
            get
            {
                return this.rollNum;
            }
            set
            {
                this.rollNum = value;
            }
        }



        public void show(int id,int choix)
        {
            dbConnection db = new dbConnection();
            SqlConnection sqlcon = db.GetSqlConnection();
            MySqlConnection mysqlcon = db.GetMySqlConnection();

            try
            {
                sqlcon.Open();
                mysqlcon.Open();
                if (sqlcon.State == ConnectionState.Open && mysqlcon.State == ConnectionState.Open)
                {

                    String sql = "select * from teacher where id=" + id;
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    MySqlCommand mycmd = new MySqlCommand(sql, mysqlcon);
                    if (choix == 1)
                    {
                        SqlDataReader dr;
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Console.WriteLine(String.Format("Name : {0}\nLasteName : {1}\nRoll Number : {2}", dr.GetString(1), dr.GetString(2), dr.GetString(3)));

                        }
                        else
                        {
                            Console.WriteLine("Teacher Not found!!");
                        }
                    }
                    else
                    {
                        MySqlDataReader mdr;
                        mdr = mycmd.ExecuteReader();
                        if (mdr.Read())
                        {
                            Console.WriteLine(String.Format("Name : {0}\nLasteName : {1}\nRoll Number : {2}", mdr.GetString(1), mdr.GetString(2), mdr.GetString(3)));

                        }
                        else
                        {
                            Console.WriteLine("Teacher Not found!!");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("AN ERROR WAS OCCURED WHILE TRYING TO CONNECT TO SQL SERVER");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open && mysqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                    mysqlcon.Close();   
                }
            }

        }

        public void Add(int choix)
        {
            dbConnection db = new dbConnection();
            SqlConnection sqlcon = db.GetSqlConnection();
            MySqlConnection mysqlcon = db.GetMySqlConnection();

            try
            {
                sqlcon.Open();
                mysqlcon.Open();
                if (sqlcon.State == ConnectionState.Open)
                {
                    String sql = "INSERT INTO teacher(nom,lname,rollnum)VALUES('" + name + "','" + lname + "','" + rollNum + "')";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    MySqlCommand mycmd = new MySqlCommand(sql, mysqlcon);
                    if(choix == 1)
                    {

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            Console.WriteLine("teacher Inserted Successfully!!\n");
                        }
                        else
                        {
                            Console.WriteLine("teacher Not Inserted!!\n");
                        }
                    }
                    else
                    {

                        if (mycmd.ExecuteNonQuery() == 1)
                        {
                            Console.WriteLine("teacher Inserted Successfully!!\n");
                        }
                        else
                        {
                            Console.WriteLine("teacher Not Inserted!!\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("AN ERROR WAS OCCURED WHILE TRYING TO CONNECT TO SQL SERVER");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sqlcon.State == ConnectionState.Open && mysqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                    mysqlcon.Close();
                }
            }
        }
    }
}
