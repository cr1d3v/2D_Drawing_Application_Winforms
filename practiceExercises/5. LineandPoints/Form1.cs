using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineAndPoints
{
    // SID:19-03-999
    // Lastly Updated: 27.04.2022

    public partial class LineAndPoints : Form
    {
        //Declare MainMenu object
        private MainMenu mainMenu;

        public LineAndPoints()
        {
            // Settings inherited from DoubleBuffering in class-exercise
            InitializeComponent();
            // Position the form
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            // Size the form
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 700;
            this.Height = 500;

            // Initialise mainMenu object and declare menu items
            mainMenu = new MainMenu();
            MenuItem exitItem = new MenuItem();
            // Assign Text values to menu items
            exitItem.Text = "&Exit";
            // Add menu items to the mainMenu object
            mainMenu.MenuItems.Add(exitItem);
            // Add mouse click listeners to the menu items
            exitItem.Click += new System.EventHandler(this.exitApplication);
            // Assign menu object to this form's menu
            this.Menu = mainMenu;

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Create a black pen
            Pen blackPen = new Pen(Color.Black);

            // Declare and initialise the Points table ( 10 elements )
            Point[] ptsTable = {
                                               new Point(5, 5),
                                               new Point(5, 250),
                                               new Point(450, 250),
                                               new Point(450, 150),
                                               new Point(5, 150),
                                               new Point(225, 150),
                                               new Point(225, 5),
                                               new Point(225, 75),
                                               new Point(450, 75),
                                               new Point(450, 5)
            };
            // Declare and initialise the Lines table ( 10 elements )
            int[,] lineTable = {
                                              {0, 1},
                                              {1, 2},
                                              {2, 3},
                                              {3, 4},
                                              {5, 6},
                                              {7, 8},
                                              {8, 9},
                                              {9, 0}
            };

            for (int i = 0; i < lineTable.GetLength(0); i++)
            {
                for (int x = 0; x < lineTable.GetLength(1); x++)
                {
                    // 1x Drawline() statememnt to draw the whole drawing
                    g.DrawLine(blackPen, ptsTable[lineTable[i, x]], ptsTable[lineTable[i, x + 1]]);
                    break;
                }
            }
        }
        // Method to close the application
        private void exitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    public class LineAndPointsDemo
    {
        public static void Main()
        {
            Application.Run(new LineAndPoints());
        }
    }
}
