﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MEDICAL
{
    public partial class UserMst : Form
    {
        DS.DS_USER.UserMst_SelectDataTable UDT = new DS.DS_USER.UserMst_SelectDataTable();
        DS.DS_USERTableAdapters.UserMst_SelectTableAdapter UAdapter = new MEDICAL.DS.DS_USERTableAdapters.UserMst_SelectTableAdapter();
        public string username;
        public UserMst(string uname)
        {
            username = uname;
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("Error", "Medical System");
            }
            else if (txtpass.Text == "")
            {
                MessageBox.Show("Error", "Medical System");
            
            }
            else if (txtpass.Text != txtcpass.Text)
            {
                MessageBox.Show("Error", "Medical System");
            }
            else
            {
                int isrt = UAdapter.Insert(txtname.Text, txtpass.Text, "User", System.DateTime.Now.Date);
                txtpass.Text = "";
                txtname.Text = "";
                txtcpass.Text = "";
                MessageBox.Show("User Added Sucssesfully !!", "Medical System");
            
            }

        
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            { 
            
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                UDT = UAdapter.SelectUser();
                comboBox1.DataSource = UDT;
                comboBox1.DisplayMember = "U_Name";
                comboBox1.ValueMember = "U_ID";
            
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                UDT = UAdapter.SelectUser();
                dataGridView1.DataSource = UDT;
            
            }
            else if (tabControl1.SelectedIndex == 3)
            { 
            
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int del = UAdapter.Delete(Convert.ToInt32(comboBox1.SelectedValue));
            MessageBox.Show("USer Deleted !!", "Medical System");
            UDT = UAdapter.SelectUser();
            comboBox1.DataSource = UDT;
            comboBox1.DisplayMember = "U_Name";
            comboBox1.ValueMember = "U_ID";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Error", "Medical System");
            
            }
            else if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("Error", "Medical System");
            }
            else
            {
                UAdapter.UserMst_Update_password(username.ToString(), textBox1.Text);
                MessageBox.Show("Password has been changed !!", "Medical System");
            }
        }
    }
}
