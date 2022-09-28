using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace CGPproject
{
    // SID:19-03-999
    // Lastly Updated: 27.04.2022
    public partial class XORDrawing : Form
    {

        public int x = 0;
        public int y = 0;

        Rectangle aRect;
        Rectangle anEllipse;
        Rectangle moving;
        Graphics g;

        //Declare MainMenu object
        private MainMenu mainMenu;

        public XORDrawing()
        {
            InitializeComponent();
            // set up the rectangle objects using client (form) coordinates
            aRect = new Rectangle(100,100,200,200);
            anEllipse = new Rectangle(150,150,200,100);
            moving = new Rectangle(x,y,10,10);

            // size and position the frame
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
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
            g = e.Graphics;
            // Create a red brush
            Brush redBrush = new SolidBrush(Color.Red);
            // Fill rectangle 
            g.FillRectangle(redBrush, aRect);
           // Create a green brush
            Brush greenBrush = new SolidBrush(Color.Green);
            // Fill ellipse 
            g.FillEllipse(greenBrush, anEllipse);

            do
            {
                moving = new Rectangle(x, y, 10, 10);
                // on each iteration redefining the current location of the 'moving' rectangle by assigning its location property
                this.PointToScreen(new Point(x, y));
                // drawing the moving square (simulating the XOR operation)
                ControlPaint.FillReversibleRectangle(moving, Color.Red);
                // pausing the loop to evidentiate the motion
                Thread.Sleep(10);
                // making the square invisible by repeating the call
                ControlPaint.FillReversibleRectangle(moving, Color.Red);

                // increment the x and y location from origin (whilst x<500)
                x++; y++;

            } while (x < 500);
        }
        // Method to close the application
        private void exitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    public class XORDemo
    {
        public static void Main()
        {
            Application.Run(new XORDrawing());
        }
    }
}
