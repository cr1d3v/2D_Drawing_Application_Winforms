using System;
using System.Drawing;
using System.Windows.Forms;

namespace CGP
{
      // SID:19-03-999
      // Lastly Updated: 27.04.2022

    public partial class SimpleDrawing : Form
    {
        //Declare MainMenu object
        private MainMenu mainMenu;

        public SimpleDrawing()
        {

            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 500;
            this.Height = 500;
            this.BackColor = Color.White;

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
            // Create a pen object
            Pen blackPen = new Pen(Color.Black);

            // Draws a triangle 
            g.DrawLine(blackPen, 50, 50, 100, 100);
            g.DrawLine(blackPen, 100, 100, 200, 100);
            g.DrawLine(blackPen, 50, 50, 100, 100);
            g.DrawLine(blackPen, 200, 100, 50, 50);

            // Draw a rectangle
            g.DrawRectangle(blackPen, 200, 200, 150, 150);

            // Draw a circle within a square
            g.DrawEllipse(blackPen, new Rectangle(200, 200, 150, 150));

            // Draw an ellipse
            g.DrawEllipse(blackPen, new Rectangle(250, 50, 150, 100));

            // Define points of a polygon
            Point[] pts = {
                            new Point(50, 300),
                            new Point(150, 300),
                            new Point(150, 400),
                            new Point(100, 350),
                            new Point(50, 400)
                          };

            // Define a colour for filling the polygon
            Color myColour = Color.FromArgb(0, 255, 0); // etc
            SolidBrush brush = new SolidBrush(myColour);

            // Draw filled polygon
            g.FillPolygon(brush, pts);
        }
        // Removed the 'Program.cs' file for ease of use ( method Main() was embedded inside the class )
        public static void Main()
        {
            Application.Run(new SimpleDrawing());
        }
        // Method to close the application
        private void exitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}



