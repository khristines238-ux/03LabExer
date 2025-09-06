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
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;
        public frmRegistration()
        {
            InitializeComponent();

            cbGender.Items.AddRange(new[] { "Male", "Female", "Prefer not to say" });
        }


    }
}
