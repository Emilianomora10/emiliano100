using emiliano100.model;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace emiliano100
{
    public partial class frmCustomAdd : SampleAdd
    {
        public frmCustomAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MainClass.Validation(this) == false)
            {
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error;
                guna2MessageDialog1.Show("please remove errors");
                return;
            }
            else
            {
                string qry = "";
                if (id == 0)
                {
                    qry = @"Insert into Customers values (@name,@phone,@email)";
                }
                else
                {
                    qry = @"UPDATE users set cusName=@name 
                  CusEmail = @Email, 
                  cusPhone = @phone,
                  
                  where CusID = @id";

                }


                Hashtable ht = new Hashtable();
                ht.Add("@id", id);
                ht.Add("@name", txtName.Text);
                ht.Add("@phone", txtPhone.Text);
                ht.Add("@email", txtEmail.Text);

                if (MainClass.SQL(qry, ht) > 0)
                {
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Show("Data save successfully");
                    id = 0;
                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtPhone.Text = "";
                    txtName.Focus();

                }
            }
        }

        private void frmCustomAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
