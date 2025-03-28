using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TP2.Connection;
using System.Data;
using MySql.Data.MySqlClient;

namespace TP2.Abstract
{
    class Student : Person
    {
        private String refNum;
        public Student(String name, String lname, String refNum) : base(name, lname)
        {
            this.refNum = refNum;
        }

        public String Refnum
        {
            get
            {
                return this.refNum;
            }
            set
            {
                this.refNum = value;
            }
        }

        public override void Add(int choix)
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
                    String sql = "INSERT INTO students(nom,lname,refnum)VALUES('" + name + "','" + lname + "','" + refNum + "')";
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    MySqlCommand mycmd = new MySqlCommand(sql, mysqlcon);
                    if (choix == 1)
                    {

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            Console.WriteLine("Student Inserted Successfully!!\n");
                        }
                        else
                        {
                            Console.WriteLine("students Not Inserted!!\n");
                        }
                    }
                    else
                    {

                        if (mycmd.ExecuteNonQuery() == 1)
                        {
                            Console.WriteLine("students Inserted Successfully!!\n");
                        }
                        else
                        {
                            Console.WriteLine("students Not Inserted!!\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("AN ERROR WAS OCCURED WHILE TRYING TO CONNECT TO SERVER");
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

        public override void show(int id,int choix)
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

                    String sql = "select * from students where id=" + id;
                    SqlCommand cmd = new SqlCommand(sql, sqlcon);
                    MySqlCommand mycmd = new MySqlCommand(sql, mysqlcon);
                    if (choix == 1)
                    {
                        SqlDataReader dr;
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Console.WriteLine(String.Format("Name : {0}\nLasteName : {1}\nReff Number : {2}", dr.GetString(1), dr.GetString(2), dr.GetString(3)));

                        }
                        else
                        {
                            Console.WriteLine("Students Not found!!");
                        }
                    }
                    else
                    {
                        MySqlDataReader mdr;
                        mdr = mycmd.ExecuteReader();
                        if (mdr.Read())
                        {
                            Console.WriteLine(String.Format("Name : {0}\nLasteName : {1}\nReff Number : {2}", mdr.GetString(1), mdr.GetString(2), mdr.GetString(3)));

                        }
                        else
                        {
                            Console.WriteLine("Students Not found!!");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("AN ERROR WAS OCCURED WHILE TRYING TO CONNECT TO SERVER");
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
