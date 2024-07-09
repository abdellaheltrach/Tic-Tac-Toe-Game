using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {


            Color color = Color.White;  //Select white color whit 
            Pen myPen = new Pen(color, 10);//use pen whit whit color and 10 in his width


            //selecting the start and the and of drawings to be a round cap
            myPen.StartCap=System.Drawing.Drawing2D.LineCap.Round;
            myPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;


            //// X points (vertical)
            e.Graphics.DrawLine(myPen, 466, 100, 466, 500);
            e.Graphics.DrawLine(myPen, 634, 100, 634, 500);


            //// y points (horizontal)
            e.Graphics.DrawLine(myPen, 300, 230, 800, 230);
            e.Graphics.DrawLine(myPen, 300, 370, 800, 370);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
