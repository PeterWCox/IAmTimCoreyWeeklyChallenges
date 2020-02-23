using HelperLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HelperLibrary.BusinessLogic;

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

            var records = GetAllUsers();

            ReplaceRecordsInUser(records);
        }

        private void createUserButton_Click(object sender, EventArgs e)
        {
            CreateUser(firstNameText.Text, lastNameText.Text);

            firstNameText.Text = "";
            lastNameText.Text = "";
            firstNameText.Focus();

            var records = GetAllUsers();

            ReplaceRecordsInUser(records);
        }

        private void applyFilterButton_Click(object sender, EventArgs e)
        {
            var records = GetUsers_Filtered(filterUsersText.Text);
            ReplaceRecordsInUser(records);
        }

        private void ReplaceRecordsInUser(List<SystemUserModel> newList)
        {
            users.Clear();
            newList.ForEach(x => users.Add(x));
        }
    }
}
