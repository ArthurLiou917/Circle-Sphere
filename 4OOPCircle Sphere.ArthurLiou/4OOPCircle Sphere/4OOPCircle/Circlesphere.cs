using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4OOPCircle
{
    public partial class Circlespheres : Form
    {
        //declaring global circles and spheres
        circle circle1, circle2;
        sphere sphere1, sphere2;
        
        public class circle//class circle
        {
            //protected variables used for child class
            protected int X;
            protected int Y;
            protected int radius;
            public Color col;

            public static bool operator ==(circle circle1,circle circle2)//overloading operators used for compare
            {
                if (circle1.radius == circle2.radius)
                {
                    return true;
                }
                else
                    return false;
            }
            public static bool operator !=(circle circle1, circle circle2)
            {
                if (circle1.radius == circle2.radius)
                {
                    return false;
                }
                else
                    return true;
            }
            public static bool operator >(circle circle1, circle circle2)
            {
                if (circle1.radius > circle2.radius)
                {
                    return true;
                }
                else
                    return false;
            }
            public static bool operator <(circle circle1, circle circle2)
            {
                if (circle1.radius < circle2.radius)
                {
                    return true;
                }
                else
                    return false;
            }
            public circle()//default constructor
            {
                X = 0;
                Y = 0;
                radius = 0;
                col = Color.Black;
            }
            public circle(Point pnt, int rad,Color clr)//paramater consructor
            {
                setX(pnt.X);
                setY(pnt.Y);
                setRadius(rad);
                col = clr;
            }
            public circle(circle other)//clone constructor
            {
                this.X = other.X;
                this.Y = other.Y;
                this.radius = other.radius;
                this.col = other.col;
            }

            public int GetX()//getters
            {
                return X;
            }
            public int GetY()
            {
                return Y;
            }
            public int GetRadius()
            {
                return radius;
            }
            public void setX(int x)//setters
            {
                X = x;
            }
            public void setY(int y)
            {
                Y = y;
            }
            public void setRadius(int Radius)
            {
                radius = Radius;
            }
            public int Compare(circle other)//compare method
            {
                if (this.radius == other.radius)
                    return 0;
                else if (this.radius  > other.radius)
                    return 1;
                else
                    return -1;
            }
            public int InsideCircle(Point pnt)//point inside method
            {
                double Length;
                Length = Math.Sqrt(Math.Pow(this.X - pnt.X, 2) + Math.Pow(this.Y - pnt.Y, 2));
                if (Length == radius)
                {
                    return 1;
                }
                else if (Length < radius)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            public int InsideCircle(int X2, int Y2)//point inside method overload
            {
                double Length;
                Length = Math.Sqrt(Math.Pow(this.X - X2, 2) + Math.Pow(this.Y - Y2, 2));
                if (Length == radius)
                {
                    return 1;
                }
                else if (Length < radius)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }

            }
            public double Area()//area method
            {
                double area = Math.PI * (this.radius * this.radius);
                return area;
            }
            public double Perimeter()//perimeter method
            {
                double perim = 2*Math.PI*this.radius;
                return perim;
            }
            public void Draw(Graphics g)//draw method
            {
                Pen myPen = new Pen (col,3);
                g.DrawEllipse(myPen, X - radius, Y - radius, 2 * radius, 2 * radius);
                Brush myBrush = new SolidBrush(col);
                g.FillEllipse(myBrush, X - radius, Y - radius, 2 * radius, 2 * radius);
            }
        }
        //inheritance class sphere 
        //parent class is circle
        public class sphere : circle
        {
            public sphere():base()//follows default of circle constructor
            {

            }
            public sphere(Point pnt, int rad, Color clr)//paramter constructor
            {
                setX(pnt.X);
                setY(pnt.Y);
                setRadius(rad);
                col = clr;
            }
            public sphere(sphere other)//clone constructor
            {
                this.X= other.X;
                this.Y = other.Y;
                this.radius = other.radius;
                this.col = other.col;
            }
            public double Area()//area method for sphere
            {
                double area = 4*Math.PI * (this.radius * this.radius);
                return area;
            }
            public double Volume()//volume method for sphere
            {
                double dVolume = Math.Round(4 * Math.PI * Math.Pow((this.radius), 3) / 3);
                return dVolume;
            }

            public double Perimeter()//perimeter method, throws exception as you cannot find perimeter of 3d shape
            {
                throw new InvalidOperationException();
            }

            public void Draw(Graphics g)//draw method
            {
                Pen myPen = new Pen(col, 3);

                Color clr = Color.FromArgb(255, 255 - col.R, 255 - col.G, 255 - col.B);
                Pen myPen2 = new Pen(clr, 3);

                Pen dotPen = new Pen(clr, 3);
                dotPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

                Brush myBrush = new SolidBrush(col);

                g.DrawEllipse(myPen, X - radius, Y - radius, 2 * radius, 2 * radius);
                g.FillEllipse(myBrush, X - radius, Y - radius, 2 * radius, 2 * radius);
                g.DrawEllipse(myPen2, X - radius, Y - radius/2, 2 * radius, radius);
                g.DrawLine(dotPen, new Point(X, Y), new Point(X + radius, Y));
            }
        }

        public Circlespheres()
        {
            InitializeComponent();
             circle1 = new circle();//initializes circles with default parameters
             circle2 = new circle();//
             sphere1 = new sphere();//initializes sphere with default parameters
            sphere2 = new sphere();//
        }

        private void btnInitalize4_Click(object sender, EventArgs e)//initalize buttons for sphere
        {
            try
            {
                sphere2.setX(Convert.ToInt32(nUDX4.Value));
                sphere2.setY(Convert.ToInt32(nUDY4.Value));
                sphere2.setRadius(Convert.ToInt32(nUDR4.Value));
                //circle2.col = Color.Red;
                pictureBox4.Invalidate();
            }
            catch
            {
                MessageBox.Show("Input Error!");
            }
        }

        private void btnInitalize3_Click(object sender, EventArgs e)//initalize buttons for sphere
        {
            try
            {
                sphere1.setX(Convert.ToInt32(nUDX3.Value));
                sphere1.setY(Convert.ToInt32(nUDY3.Value));
                sphere1.setRadius(Convert.ToInt32(nUDR3.Value));
                //circle2.col = Color.Red;
                pictureBox3.Invalidate();
            }
            catch
            {
                MessageBox.Show("Input Error!");
            }
        }

        private void btnInitalize2_Click(object sender, EventArgs e)//initalize buttons for circle
        {
            try
            {
                circle2.setX(Convert.ToInt32(nUDX2.Value)); 
                circle2.setY(Convert.ToInt32(nUDY2.Value));
                circle2.setRadius(Convert.ToInt32(nUDR2.Value));
                pictureBox2.Invalidate();
            }
            catch
            {
                MessageBox.Show("Input Error!");
            }
        }

        private void btnInitialize1_Click(object sender, EventArgs e)//initalize buttons for circle
        {
            try
            {
                circle1.setX(Convert.ToInt32(nUDX1.Value));
                circle1.setY(Convert.ToInt32(nUDY1.Value));
                circle1.setRadius(Convert.ToInt32(nUDR1.Value));
                pictureBox1.Invalidate();
            }
            catch
            {
                MessageBox.Show("Input Error!");
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)//compare button for circle
        {
            if (circle1>circle2)
            {
                MessageBox.Show("Circle 1 is bigger than Circle 2");
            }
            else if (circle1 < circle2)
            {
                MessageBox.Show("Circle 1 is smaller than Circle 2");
            }
            else
            {
                MessageBox.Show("Circle 1 is equal to Circle 2");
            }
        }

        private void btnCompare2_Click(object sender, EventArgs e)//compare button for sphere
        {
            if (sphere1 > sphere2)
            {
                MessageBox.Show("Sphere 1 is bigger than Sphere 2");
            }
            else if (sphere1 < sphere2)
            {
                MessageBox.Show("Sphere 1 is smaller than Sphere 2");
            }
            else
            {
                MessageBox.Show("Sphere 1 is equal to Sphere 2");
            }
        }

        private void btnArea1_Click(object sender, EventArgs e)//area button for circle
        {
            double area = Math.Round(circle1.Area(), 2);
            MessageBox.Show("The area is " + area.ToString() + " units squared");         
        }

        private void btnArea2_Click(object sender, EventArgs e)//area button for circle
        {
            double area = Math.Round(circle2.Area(), 2);
            MessageBox.Show("The area is " + area.ToString() + " units squared");
        }

        private void btnArea3_Click(object sender, EventArgs e)//area button for sphere
        {
            double area = Math.Round(sphere1.Area(), 2);
            MessageBox.Show("The surface area is " + area.ToString() + " units squared");
        }

        private void btnArea4_Click(object sender, EventArgs e)//area button for sphere
        {
            double area = Math.Round(sphere2.Area(), 2);
            MessageBox.Show("The surface area is " + area.ToString() + " units squared");
        }

        private void btnPerim1_Click(object sender, EventArgs e)//perimeter button for circle
        {
            double perim = Math.Round(circle1.Perimeter(), 2);
            MessageBox.Show("The perimeter is " + perim.ToString() + " units");
        }

        private void btnPerim2_Click(object sender, EventArgs e)//perimeter button for circle
        {
            double perim = Math.Round(circle2.Perimeter(), 2);
            MessageBox.Show("The perimeter is " + perim.ToString() + " units");
        }

        private void btnVolume_Click(object sender, EventArgs e)//volume button for sphere
        {
            double vol = Math.Round(sphere1.Volume(), 2);
            MessageBox.Show("The volume is " + vol.ToString() + " units cubed");
        }

        private void btnVolume2_Click(object sender, EventArgs e)//volume button for sphere
        {
            double vol = Math.Round(sphere2.Volume(), 2);
            MessageBox.Show("The volume is " + vol.ToString() + " units cubed");
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)//drawing for four different picture boxes
        {
            circle1.Draw(e.Graphics);
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            circle2.Draw(e.Graphics);
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            sphere1.Draw(e.Graphics);
        }

        private void pictureBox4_Paint(object sender, PaintEventArgs e)
        {
            sphere2.Draw(e.Graphics);
        }

        private void btnColour1_Click(object sender, EventArgs e)//colour change button for circle
        {
            ColorDialog colDlg = new ColorDialog();
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                circle1.col = colDlg.Color;
                pictureBox1.Invalidate();
            }
        }

        private void btnColour2_Click_1(object sender, EventArgs e)//colour change button for circle
        {
            ColorDialog colDlg = new ColorDialog();
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                circle2.col = colDlg.Color;
                pictureBox2.Invalidate();
            }
        }

        private void btnColour3_Click(object sender, EventArgs e)//colour change button for sphere
        {
            ColorDialog colDlg = new ColorDialog();
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                sphere1.col = colDlg.Color;
                pictureBox3.Invalidate();
            }
        }

        private void btnColour4_Click(object sender, EventArgs e)//colour change button for sphere
        {
            ColorDialog colDlg = new ColorDialog();
            if (colDlg.ShowDialog() == DialogResult.OK)
            {
                sphere2.col = colDlg.Color;
                pictureBox4.Invalidate();
            }
        }

        private void btnCheck1_Click(object sender, EventArgs e)//check if point is inside circle button
        {
            int iResult;
           
            int X2 = Convert.ToInt32(nUDPointX1.Value);
            int Y2 = Convert.ToInt32(nUDPointY1.Value);
            iResult = circle1.InsideCircle(X2,Y2);
            if (iResult == 1)
            {
                MessageBox.Show("Inside Circle");
            }
            else
            {
                MessageBox.Show("Not inside Circle");
            }
        }

        private void btnCheck2_Click(object sender, EventArgs e)//check if point is inside circle button
        {
            int iResult;
            int X2 = Convert.ToInt32(nUDPointX2.Value);
            int Y2 = Convert.ToInt32(nUDPointY2.Value);
            iResult = circle2.InsideCircle(X2, Y2);
            if (iResult == 1)
            {
                MessageBox.Show("Inside Circle");
            }
            else
            {
                MessageBox.Show("Not inside Circle");
            }
        }
    }
}
