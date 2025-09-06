using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03LabExer
{
    public partial class frmRegistration : Form
    {

       
        public string _FullName;
        public int _Age;
        public long _ContactNo;
        public long _StudentNo;


        public frmRegistration()
        {
            InitializeComponent();
            
            cbGender.Items.AddRange(new[] { "Male", "Female", "Prefer not to say" });
        }

       
        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };

            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
        }

      
        private string FullName(string last, string first, string middleInitial)
        {
            if (string.IsNullOrWhiteSpace(last))
                throw new ArgumentNullException(nameof(last), "Last name is required.");
            if (string.IsNullOrWhiteSpace(first))
                throw new ArgumentNullException(nameof(first), "First name is required.");

            middleInitial = (middleInitial ?? string.Empty).Trim();

            if (middleInitial.Length > 1)
                throw new IndexOutOfRangeException("Middle initial must be exactly one character.");
            if (middleInitial.Length == 1 && !Regex.IsMatch(middleInitial, @"^[A-Za-z]$"))
                throw new FormatException("Middle initial must be a letter (A–Z).");

            string mi = middleInitial.Length == 1 ? $"{char.ToUpper(middleInitial[0])}." : "";
            _FullName = string.IsNullOrEmpty(mi)
                ? $"{last.Trim()}, {first.Trim()}"
                : $"{last.Trim()}, {first.Trim()} {mi}";

            return _FullName;
        }

        private int StudentNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(nameof(input), "Student number is required.");

            if (!Regex.IsMatch(input, @"^\d+$"))
                throw new FormatException("Student number must contain digits only.");

         
            if (input.Length < 4 || input.Length > 10)
                throw new IndexOutOfRangeException("Student number must be 4–10 digits.");

       
            long value = long.Parse(input);
            if (value > int.MaxValue)
                throw new OverflowException("Student number is too large.");

            _StudentNo = value;
            return (int)value;
        }

        private int ContactNo(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(nameof(input), "Contact number is required.");

            if (!Regex.IsMatch(input, @"^\d+$"))
                throw new FormatException("Contact number must contain digits only.");

           
            if (input.Length < 7 || input.Length > 11)
                throw new IndexOutOfRangeException("Contact number must be 7–11 digits.");

            long value = long.Parse(input);
            if (value > int.MaxValue)
                throw new OverflowException("Contact number is too large for int.");

            _ContactNo = value;
            return (int)value;
        }

        private int Age(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(nameof(input), "Age is required.");

            if (!Regex.IsMatch(input, @"^\d+$"))
                throw new FormatException("Age must be numeric.");

            
            int age = int.Parse(input);
            if (age < 1 || age > 120)
                throw new OverflowException("Age must be between 1 and 120.");

            _Age = age;
            return age;
        }

       
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthDay = datePickerBirthday.Value.ToString("yyyy-MM-dd");

                using (var frm = new frmConfirmation())
                {
                    frm.ShowDialog();
                }
            }
        
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Missing value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Invalid format", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message, "Overflow / out of range", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Index/length problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
                txtLastName.Focus();
            }
        }
    }
}
