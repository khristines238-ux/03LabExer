using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03LabExer
{
    public partial class frmConfirmation : Form
    {
        public frmConfirmation()
        {
            InitializeComponent();
        }

        private void FrmConfirmation_Load(object sender, EventArgs e)
        {
            lblStudentNo1.Text = StudentInformationClass.SetStudentNo.ToString();
            lblName1.Text = StudentInformationClass.SetFullName;
            lblProgram1.Text = StudentInformationClass.SetProgram;
            lblBirthday1.Text = StudentInformationClass.SetBirthDay;
            lblGender1.Text = StudentInformationClass.SetGender;
            lblContactNo1.Text = StudentInformationClass.SetContactNo.ToString();
            lblAge1.Text = StudentInformationClass.SetAge.ToString();
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Submitted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Submitted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}

