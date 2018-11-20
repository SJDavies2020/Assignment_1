using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2
{
    // Assignment #1 
    // Steven Davies - 200411361
    // Grade Caculator

    public partial class frmCalcGrades : Form
    {
        // Initalize Variables and set defaults

        Label[] MyLabelArray = new Label[7];
        TextBox[] MytxtBoxArray = new TextBox [6];
        decimal TotalMarks =0;

        public frmCalcGrades()
        {
            InitializeComponent();
        }
        #region // Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize Label text property to be blank on load of form.
            lblGrade1.Text = "";
            lblGrade2.Text = "";
            lblGrade3.Text = "";
            lblGrade4.Text = "";
            lblGrade5.Text = "";
            lblGrade6.Text = "";
            lblAverage.Text = "";
            lblOAGradeAvg.Text = "";

            // assign form control to the Label Control Array
            MyLabelArray[0] = lblGrade1;
            MyLabelArray[1] = lblGrade2;
            MyLabelArray[2] = lblGrade3;
            MyLabelArray[3] = lblGrade4;
            MyLabelArray[4] = lblGrade5;
            MyLabelArray[5] = lblGrade6;
            MyLabelArray[6] = lblOAGradeAvg;

            // assign form control to the Text Box Control Array
            MytxtBoxArray[0] = txtGrade1;
            MytxtBoxArray[1] = txtGrade2;
            MytxtBoxArray[2] = txtGrade3;
            MytxtBoxArray[3] = txtGrade4;
            MytxtBoxArray[4] = txtGrade5;
            MytxtBoxArray[5] = txtGrade6;
        }
        #endregion
        #region // Grade Function
        // Method to assign Grade Letter to Grade
        public void RetGradeLeter(decimal num1, Label myLabel)
        {
            if (num1 > 80 && num1 < 101)
            {
                myLabel.Text = "A"; //Change label text to A
                lblOAGradeAvg.Text = "A"; //Change label text to A
            }
            else if (num1 >70  && num1 < 79)
            {
                myLabel.Text = "B"; //Change label text to B
                lblOAGradeAvg.Text = "B"; //Change label text to B
            }
            else if (num1 > 60 && num1 < 69) 
            {
                myLabel.Text = "C"; //Change label text to C
                lblOAGradeAvg.Text = "C"; //Change label text to B
            }
            else if (num1 > 49 && num1 < 59)
            {
                myLabel.Text = "D"; //Change label text to D
                lblOAGradeAvg.Text = "D"; //Change label text to B
            }
            
            else
            {
                myLabel.Text = "FAIL";
            }
            TotalMarks = TotalMarks + num1;
        }
        #endregion
        #region // Button Code 
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Loop through the control array and check textbox is not empty.
            for (int a = 0; a <= 5; a++)
            {
               if (MytxtBoxArray[a].Text == "")
                {
                    MessageBox.Show("Some of your Values are Empty. Please Correct");
                    return;
                }
            }
            // Loop through the control array and check textbox is a number only.
            TotalMarks = 0;
            int txtCheck = 0;
            for (int a = 0; a <= 5; a++) // Loop Settings
            {
                bool ValidateTxt; // True/False for test on next line
                ValidateTxt = MytxtBoxArray[a].Text.All(char.IsDigit); // Check to see if the text is numeric
                    if (ValidateTxt == false) // If not numeric then increment Number.
                    {
                        txtCheck = txtCheck +1;
                    }
             }
            if (txtCheck > 0) // If checkvalue is not zero then show message
            {
                MessageBox.Show("Some of your input are not Numbers. Please Correct");
                return;
            }
            // Loop through the control array and check textbox value is within range.
            int ValCheck = 0;
            for (int a = 0; a <= 5; a++) 
            {
                decimal CheckVal = System.Convert.ToDecimal(MytxtBoxArray[a].Text);
                if (CheckVal < 0 | CheckVal > 100) // If checkvalue is not in range then increment counter.
                {
                    ValCheck = ValCheck +1;
                }
             }
            if (ValCheck > 0) // If checkvalue is not zero then show message
            {
                MessageBox.Show("Some of your input is out of the Acceptable Range. Please Correct");
                return;
            }
                // Loop through the control array, convert to decimal and cacl the average grade.
                for (int a = 0; a <= 5; a++)
                {
                    RetGradeLeter(System.Convert.ToDecimal(MytxtBoxArray[a].Text), MyLabelArray[a]); // Loop and call Method to set grade letter.
                }
                lblAverage.Text = System.Convert.ToString(Math.Round((TotalMarks / 6),1)) + " %"; // Set Label TXT to set Grade Letter
                RetGradeLeter(System.Convert.ToDecimal(Math.Round((TotalMarks / 6), 1)), MyLabelArray[6]); // Set final grade letter.
        }
        #endregion
    }
}
