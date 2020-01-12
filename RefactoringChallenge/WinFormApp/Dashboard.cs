using HelperLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HelperLibrary.DataAccess;

namespace WinFormApp
{
    public partial class Dashboard : Form
    {
        BindingList<SystemUserModel> users = new BindingList<SystemUserModel>();

        public Dashboard()
        {
            InitializeComponent();

            userDisplayList.DataSource = users;
            userDisplayList.DisplayMember = "FullName";

            string connectionString = GetConnectionString();
            var records = GetRecords();
            users.Clear();
            records.ForEach(x => users.Add(x));

            //SOME TEST DATA WANT TO REVERSE
        }

        private void createUserButton_Click(object sender, EventArgs e)
        {
            string connectionString = GetConnectionString();

            DataAccess.CreateUser(firstNameText.Text, lastNameText.Text);
            firstNameText.Text = "";
            lastNameText.Text = "";
            firstNameText.Focus();

            var records = DataAccess.GetRecords();
            users.Clear();
            records.ForEach(x => users.Add(x));           
        }

        private void applyFilterButton_Click(object sender, EventArgs e)
        {
            string connectionString = GetConnectionString();
            var records = ApplyFilter(filterUsersText.Text);
            users.Clear();
            records.ForEach(x => users.Add(x));
        }
    }
}
