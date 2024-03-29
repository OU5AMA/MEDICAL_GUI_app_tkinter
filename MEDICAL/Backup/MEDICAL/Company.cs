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
    public partial class Company : Form
    {
        DS.DS_COMPANY.CompanyMst_SelectDataTable CDT = new MEDICAL.DS.DS_COMPANY.CompanyMst_SelectDataTable();
        DS.DS_COMPANYTableAdapters.CompanyMst_SelectTableAdapter CAdapter = new MEDICAL.DS.DS_COMPANYTableAdapters.CompanyMst_SelectTableAdapter();
        public Company()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ist = CAdapter.Insert(txtname.Text, txtpersn.Text, txtadd.Text, txtmobile.Text);
            MessageBox.Show("Company Detail Addedd !!", "Medical System");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            { 
            
            }
            else if (tabControl1.SelectedIndex == 1)
            {

                CDT = CAdapter.SelectComapny();
                comboBox1.DataSource = CDT;
                comboBox1.DisplayMember = "Cname";
                comboBox1.ValueMember = "CID";
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                CDT = CAdapter.SelectComapny();
                dataGridView1.DataSource = CDT;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int del = CAdapter.Delete(Convert.ToInt32(comboBox1.SelectedValue));
            CDT = CAdapter.SelectComapny();
            comboBox1.DataSource = CDT;
            comboBox1.DisplayMember = "Cname";
            comboBox1.ValueMember = "CID";
            MessageBox.Show("Delete Company !!", "Medical System");
        }
    }
}
