﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.Sql;

namespace dbms_project.login

{
    public partial class WebForm2 : System.Web.UI.Page

    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Users\Archit\source\repos\dbms project\dbms project\App_Data\mydata.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("Lgn", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@user", TextBox1.Text);
            SqlParameter p2 = new SqlParameter("@password", TextBox2.Text);
            com.Parameters.Add(p1);
            com.Parameters.Add(p2);
            con.Open();
            SqlDataReader rd = com.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Read();

                string st = TextBox1.Text;
          
                Session["login"] = st;
                Response.Redirect("user.aspx");
                
            }
            else
            {
                Label1.Text = "Invalid username or password.";
                Label1.Visible = true;
            }
        }

        
    }
    }
