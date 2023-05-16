using employeewithdeletupdatesearch.MODEL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeewithdeletupdatesearch.DAL
{
    public class emplayer
    {
        private String _connectionstring;

        public SqlDataReader SqlDataReader { get; private set; }

        public emplayer(IConfiguration iconfiguration)
        { 
            _connectionstring= iconfiguration.GetConnectionString("Default");
        }
        public SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = _connectionstring;
            return conn;
        }
        public emp search(int id)
        {
            SqlConnection sqlcon = null;
            emp e1 = null;
            try
            {
                sqlcon = GetConnection();
                
                sqlcon.Open();
                //SqlCommand cmd = new SqlCommand("select * from emp where Id=@id", sqlcon);
                SqlCommand cmd=new SqlCommand("searchprocedure",sqlcon);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.Add("@Pid",SqlDbType.Int).Value=id;
                //cmd.Parameters.AddWithValue("id", id);
                SqlDataReader r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        e1 = new emp();
                        e1.Name = (String)r["Name"];
                        e1.salary =Convert.ToSingle( r["Salary"]);
                        Console.WriteLine(e1);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return e1;


        }
        public int Delete(int id)
        {
            SqlConnection sqlcon=GetConnection();   
            sqlcon.Open();
            int row = 0;
            SqlCommand cmd=new SqlCommand();
            cmd.CommandText="empdelete";
            cmd.Connection = sqlcon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Pid",SqlDbType.Int).Value=id;
            row=cmd.ExecuteNonQuery();
            return row;

        }
        public int update(int id)
        {
            int row=0;
            SqlConnection sqlcon=GetConnection();
            sqlcon.Open();
            SqlCommand cmd=new SqlCommand();
            cmd.CommandText="empupdate";
            cmd.Connection = sqlcon;
            cmd.CommandType=CommandType.StoredProcedure;    
            cmd.Parameters.Add("@Pid",SqlDbType.Int).Value = id;
            row=cmd.ExecuteNonQuery();
            return row;
        }
        public int insert(emp demo)
        {
            int row=0;
            SqlConnection sqlcon = GetConnection();
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "empinsert";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection= sqlcon;
            cmd.Parameters.Add("@Pname",SqlDbType.NVarChar).Value = demo.Name;
            cmd.Parameters.Add("@Psalary", SqlDbType.Float).Value = demo.salary;
            row=cmd.ExecuteNonQuery();
            return row;
        }
        public emp nsearch(string s)
        {
            SqlConnection sqlcon = null;
            emp e5 = null;
            try
            {
                sqlcon = GetConnection();
                sqlcon.Open();
                //SqlCommand cmd = new SqlCommand("select * from emp where Id=@id", sqlcon);
                SqlCommand cmd = new SqlCommand("nsearchprocedure", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Pname", SqlDbType.NVarChar).Value = s;
                //cmd.Parameters.AddWithValue("id", id);
                SqlDataReader r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        e5 = new emp();
                        e5.Id = r.GetInt32("Id");
                        e5.Name = (String)r["Name"];
                        e5.salary = Convert.ToSingle(r["Salary"]);
                        Console.WriteLine(e5);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return e5;


        }
    }

}