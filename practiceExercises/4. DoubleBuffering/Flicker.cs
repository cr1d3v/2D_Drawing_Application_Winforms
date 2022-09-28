using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace CGPproject
{

    // SID:19-03-999
    // Lastly Updated: 27.04.2022

    public partial class Flicker : Form
    {
        Rectangle rect;
        int x = 0;
        int y = 200;

        // declare and assign value to 2x new local variables
        int xMove = 2;
        int yMove = 2;

        public Flicker()
        {
            InitializeComponent();
            // Position the form
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            // Size the form
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 400;
            this.Height = 400;
            // Create the small rectangle objects using client (form) coordinates
 
            rect = new Rectangle(x, y, 50, 50);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Initiate a back buffer
            Bitmap backBuffer = new Bitmap(this.Width, this.Height);
            // Initiate 2 graphics objects
            Graphics g = e.Graphics;
            Graphics g2 = Graphics.FromImage(backBuffer);
            // Create a black pen and white and a red brush
            Pen blackPen = new Pen(Color.Black);
            Brush redBrush = new SolidBrush(Color.Red);
            Brush whiteBrush = new SolidBrush(Color.White);
            // Define a font for writing
            Font myFont = new System.Drawing.Font("Helvetica", 9);

            do
            {
                // Define and fill large rectangle background 
                g.FillRectangle(whiteBrush, 0, 0, 400, 400);
                // Redefine the position of the small rectangle
                rect.Location = new Point(x, y);
                // Draw small rectangle in new position 
                g.DrawRectangle(blackPen, rect);
                // Display message always in same position
                g.DrawString("Moving rectangle", myFont, redBrush, 150, 150);


                if (x > 333 || x < 0)
                {
                    // -1 * -2
                    xMove = -1 * xMove;
                }

                if (y > 313 || y < 0)
                {
                    // -1 * -2
                    yMove = -1 * yMove;
                }

                x += xMove;
                y += yMove;

                // pausing the loop to evidentiate the motion
                Thread.Sleep(10);
                // Itteration are drawn to the front buffer screen
                g.DrawImage(backBuffer, 0, 0);

            } while (true);
        }
    }
    public class FlickerDemo
    {
        public static void Main()
        {
            Application.Run(new Flicker());
        }
    }
}





