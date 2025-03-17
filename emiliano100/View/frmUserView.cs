using emiliano100;
using emiliano100.model;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace emiliano100.View
{
    public partial class frmUserView: Form
    {
        public frmUserView()
        {
            InitializeComponent();
            LaodData();
        }

        private void frmUserView_Load(object sender, EventArgs e)
        {
            LaodData();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new frmUserAdd());
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            LaodData();
        }

        private void LaodData()
        {
            ListBox ib = new ListBox();
            ib.Items.Add(dgvid);
            ib.Items.Add(dgvname);
            ib.Items.Add(dgvuserName);
            ib.Items.Add(dgvpass);
            ib.Items.Add(dgvphon);

            string qry = @"Select userID , uName , uUsername from user 
                        Where uName like ' % " + txtSearch.Text + " % ' order by userID desc ";
            MainClass.LoadData(qry, guna2DataGridView1, ib);

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                frmUserAdd frm = new frmUserAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvname"].Value);
                frm.txtUser.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvuserName"].Value);
                frm.txtPass.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvpass"].Value);
                frm.txtPhone.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvphon"].Value);

                MainClass.BlurBackground(frm);
                LaodData();

            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                string qry = "Delete From users where userID = " + id + "";
                Hashtable ht = new Hashtable();
                if (MainClass.SQL(qry, ht) > 0)
                {
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Show("Delete successfully..");
                    LaodData();
                }
            }
        }
    }
}
