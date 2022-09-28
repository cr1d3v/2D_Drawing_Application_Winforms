using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CGPproject
{
    // SID:19-03-999
    // Lastly Updated: 27.04.2022
    
    public partial class SquareAndCircle : Form
    {
        //Declare MainMenu object
        private MainMenu mainMenu;

        public SquareAndCircle()
        {
            // Maximises the form whilst retaining the menu bar;
            this.WindowState = FormWindowState.Maximized;

            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
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
            // Starting co-ordinates for the largest triangle
            Point[] startingCoordinates = { new Point(100, 100), new Point(500, 100), new Point(300, 446) };

            // For loop to draw up to < 3 triangles
            for (int i = 0; i < 3; i++)
            {
                g.DrawPolygon(blackPen, startingCoordinates);
                startingCoordinates = midPoints(startingCoordinates);
            }

        }
        // Calculate new co-ordinates
        public static Point[] midPoints(Point[] startingCoordinates)
        {
            Point[] pts = {
                new Point((startingCoordinates[0].X + startingCoordinates[1].X) / 2, (startingCoordinates[0].Y + startingCoordinates[1].Y) / 2),
                new Point((startingCoordinates[0].X + startingCoordinates[2].X) / 2, (startingCoordinates[0].Y + startingCoordinates[2].Y) / 2),
                new Point((startingCoordinates[1].X + startingCoordinates[2].X) / 2, (startingCoordinates[1].Y + startingCoordinates[2].Y) / 2)
            };

            return pts;
        }
        public static void Main()
        {
            Application.Run(new SquareAndCircle());
        }
        // Method to close the application
        private void exitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
