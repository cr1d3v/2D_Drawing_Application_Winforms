using CGP_SID1903999;
using System;
using System.Windows.Forms;

namespace Grafpack
{
    public partial class Utilities : Form
    {
        // Declare Var
        private string selectedShapeItem;
        private float userInputVal;
        private float lowestVal;
        private float highestVal;

        public Utilities(string itemToDraw, float highest, float lowest)
        {
            loadUtilities();

            selectedShapeItem = itemToDraw;
            highestVal = highest;
            lowestVal = lowest;
            label1.Text = "";
            label1.Text = (String.Format("{0}, {1} and {2}", selectedShapeItem, lowestVal, highestVal));
        }
        private void loadUtilities() { InitializeComponent(); }
        private void Utilities_Load(object sender, EventArgs e) { }
        private void Label1_Click(object sender, EventArgs e) { }
        private void Cancel_Click(object sender, EventArgs e)
        {
            userInputVal = 2147483647; // cancelled op
            this.Close();
        }
        public float inputVal() { return userInputVal; }
        private void Enter_Button(object sender, EventArgs e)
        {

            int nothing = 0;
            userInputVal = float.Parse(textBox1.Text); // Parse userInputVal to text

            if (userInputVal == nothing)
            {
                MessageBox.Show("Cannot Scale by 0");
                this.Close();
            }
            else if (userInputVal >= lowestVal) { this.Close(); }
            else if (userInputVal <= highestVal) { this.Close(); }
            else
            {
                // if scale value is beyond reach   
                MessageBox.Show(String.Format("Please input a number between {0} and {1}", lowestVal, highestVal));
                this.Close();
                // new form
                Utilities getSet = new Utilities(selectedShapeItem, lowestVal, highestVal);
            }
        }
    }
}
