using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

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
            lbPlayerTurn.Text = "Player 1";
        }
        static string CourantPlayer  = "Player 1";

        private void UpdateImage(PictureBox pictureBox) 
        {
            Result result;
            if (pictureBox.Tag == "-1")
            {
                if (CourantPlayer == "Player 1")
                {
                    pictureBox.Image = Resources.X;
                    pictureBox.Tag = "1";
                    result = CheckGameEnds();
                    if (result==Result.Win)
                    {
                        lbWinner.Text = CourantPlayer;
                        MessageBox.Show($"Game finished {CourantPlayer} Wins!", "Game Over");
                        PICBOX1.Enabled = false;
                        PICBOX2.Enabled = false;
                        PICBOX3.Enabled = false;
                        PICBOX4.Enabled = false;
                        PICBOX5.Enabled = false;
                        PICBOX6.Enabled = false;
                        PICBOX7.Enabled = false;
                        PICBOX8.Enabled = false;
                        PICBOX9.Enabled = false;
                        return;
                    }
                    else if (result == Result.Draw)
                    {
                        MessageBox.Show($"Game finished by Draw!", "Game Over");
                        lbWinner.Text = "Draw";
                        PICBOX1.Enabled = false;
                        PICBOX2.Enabled = false;
                        PICBOX3.Enabled = false;
                        PICBOX4.Enabled = false;
                        PICBOX5.Enabled = false;
                        PICBOX6.Enabled = false;
                        PICBOX7.Enabled = false;
                        PICBOX8.Enabled = false;
                        PICBOX9.Enabled = false;
                    }
                    else
                    {
                        CourantPlayer = "Player 2";
                        lbPlayerTurn.Text = CourantPlayer;
                    }

                }
                else if (CourantPlayer == "Player 2")
                {
                    pictureBox.Image = Resources.O;
                    pictureBox.Tag = "0";
                    result = CheckGameEnds();
                    if (result == Result.Win)
                    {
                        lbWinner.Text = CourantPlayer;
                        MessageBox.Show($"Game finished {CourantPlayer} Wins!", "Game Over");
                        PICBOX1.Enabled = false;
                        PICBOX2.Enabled = false;
                        PICBOX3.Enabled = false;
                        PICBOX4.Enabled = false;
                        PICBOX5.Enabled = false;
                        PICBOX7.Enabled = false;
                        PICBOX8.Enabled = false;
                        PICBOX9.Enabled = false;
                        return;
                    }
                    else if (result == Result.Draw)
                    {
                        MessageBox.Show("Game finished by Draw!", "Game Over");
                        lbWinner.Text = "Draw";
                        PICBOX1.Enabled = false;
                        PICBOX2.Enabled = false;
                        PICBOX3.Enabled = false;
                        PICBOX4.Enabled = false;
                        PICBOX5.Enabled = false;
                        PICBOX6.Enabled = false;
                        PICBOX7.Enabled = false;
                        PICBOX8.Enabled = false;
                        PICBOX9.Enabled = false;
                    }
                    else
                    {
                        CourantPlayer = "Player 1";
                        lbPlayerTurn.Text = CourantPlayer;
                    }
                }


            }
            else
            {
                MessageBox.Show("You can't chose this box!", "Error");
            }
        
        
        
        
        
        
        }
        private Result CheckGameEnds()
        {
            Result result;
            int counter= 0;
            // Check rows
            result = CheckPicBoxes(PICBOX1, PICBOX2, PICBOX3);
            if (result == Result.Win)
            {
                return Result.Win;
            } 
            else if (result == Result.Draw)
            {
                counter++;
            }

            result = CheckPicBoxes(PICBOX4, PICBOX5, PICBOX6);
            if (result == Result.Win)
            {
                return Result.Win;
            }
            else if (result == Result.Draw)
            {
                counter++;
            }

            result = CheckPicBoxes(PICBOX7, PICBOX8, PICBOX9);
            if (result == Result.Win)
            {
                return Result.Win;
            }
            else if (result == Result.Draw)
            {
                counter++;
            }

            // Check columns
            result = CheckPicBoxes(PICBOX1, PICBOX4, PICBOX7);
            if (result == Result.Win)
            {
                return Result.Win;
            }
            else if (result == Result.Draw)
            {
                counter++;
            }

            result = CheckPicBoxes(PICBOX2, PICBOX5, PICBOX8);
            if (result == Result.Win)
            {
                return Result.Win;
            }
            else if (result == Result.Draw)
            {
                counter++;
            }

            result = CheckPicBoxes(PICBOX3, PICBOX6, PICBOX9);
            if (result == Result.Win)
            {
                return Result.Win;
            }
            else if (result == Result.Draw)
            {
                counter++;
            }

            // Check diagonals
            result = CheckPicBoxes(PICBOX1, PICBOX5, PICBOX9);
            if (result == Result.Win)
            {
                return Result.Win;
            }
            else if (result == Result.Draw)
            {
                counter++;
            }

            result = CheckPicBoxes(PICBOX3, PICBOX5, PICBOX7);
            if (result == Result.Win)
            {
                return Result.Win;
            }
            else if (result == Result.Draw)
            {
                counter++;
            }


            // Check if all boxes are filled
            PictureBox[] pictureBoxes = { PICBOX1, PICBOX2, PICBOX3, PICBOX4, PICBOX5, PICBOX6, PICBOX7, PICBOX8, PICBOX9 };


            foreach (var picBox in pictureBoxes)
            {
                if (picBox.Tag == "-1")
                {

                    return Result.NotCompleted;

                }
            }



            if (counter == 8)
            {
                return Result.Draw;
            }
            return Result.NotCompleted;




        }
        public enum Result
        {
            Win, Draw, NotCompleted
        }

        private Result CheckPicBoxes(PictureBox PICBOX1, PictureBox PICBOX2, PictureBox PICBOX3)
        {
            string tag1 = PICBOX1.Tag.ToString();
            string tag2 = PICBOX2.Tag.ToString();
            string tag3 = PICBOX3.Tag.ToString();

            // Check if any box is not completed
            if (tag1 == "-1" || tag2 == "-1" || tag3 == "-1")
            {
                return Result.NotCompleted;
            }

            // Check if all tags are the same and not -1
            if (tag1 == tag2 && tag2 == tag3 && tag1 != "-1")
            {
                PICBOX1.BackColor = Color.Green;
                PICBOX2.BackColor = Color.Green;
                PICBOX3.BackColor = Color.Green;

                if (tag1 == "1")
                {
                    return Result.Win; // Player 1 (X) wins
                }
                else if (tag1 == "0")
                {
                    return Result.Win; // Player 2 (O) wins
                }
            }

            return Result.Draw; // No winner, check for draw
        }


        // one event for all the Pic Boxes

        private void PICBOX_Click(object sender, EventArgs e)
        {
            UpdateImage((PictureBox)sender);
        }





        // every PixBox Whit the same event
        /*private void PICBOX1_Click(object sender, EventArgs e)
        {
            UpdateImage(PICBOX1);
        }

        private void PICBOX2_Click(object sender, EventArgs e)
        {
            UpdateImage(PICBOX2);

        }

        private void PICBOX3_Click(object sender, EventArgs e)
        {
            UpdateImage(PICBOX3);

        }

        private void PICBOX4_Click(object sender, EventArgs e)
        {
            UpdateImage(PICBOX4);

        }

        private void PICBOX5_Click(object sender, EventArgs e)
        {
            UpdateImage(PICBOX5);

        }

        private void PICBOX6_Click(object sender, EventArgs e)
        {
            UpdateImage(PICBOX6);

        }

        private void PICBOX7_Click(object sender, EventArgs e)
        {
            UpdateImage(PICBOX7);

        }

        private void PICBOX8_Click(object sender, EventArgs e)
        {
            UpdateImage(PICBOX8);

        }

        private void PICBOX9_Click(object sender, EventArgs e)
        {
            UpdateImage(PICBOX9);

        }*/




        private void RestOneButton(PictureBox PICBOX)
        {
            PICBOX.Image = Resources.question_mark_96;
            PICBOX.Tag = "-1";
            PICBOX.BackColor = Color.Transparent;
            PICBOX.Enabled = true;

        }


        private void btnRestartTheGame_Click(object sender, EventArgs e)
        {
            lbPlayerTurn.Text = "Player 1";
            CourantPlayer = "Player 1";
            lbWinner.Text = "In Progress";




            /*
            //Change all Boxes to Question Mark
            PICBOX1.Image = Resources.question_mark_96;
            PICBOX2.Image = Resources.question_mark_96;
            PICBOX3.Image = Resources.question_mark_96;
            PICBOX4.Image = Resources.question_mark_96;
            PICBOX5.Image = Resources.question_mark_96;
            PICBOX6.Image = Resources.question_mark_96;
            PICBOX7.Image = Resources.question_mark_96;
            PICBOX8.Image = Resources.question_mark_96;
            PICBOX9.Image = Resources.question_mark_96;

            //Change all Tags to -1
            PICBOX1.Tag = "-1";
            PICBOX2.Tag = "-1";
            PICBOX3.Tag = "-1";
            PICBOX4.Tag = "-1";
            PICBOX5.Tag = "-1";
            PICBOX6.Tag = "-1";
            PICBOX7.Tag = "-1";
            PICBOX8.Tag = "-1";
            PICBOX9.Tag = "-1";

            //Change all Boxes BackGround to Transparent Color
            PICBOX1.BackColor = Color.Transparent;
            PICBOX2.BackColor = Color.Transparent;
            PICBOX3.BackColor = Color.Transparent;
            PICBOX4.BackColor = Color.Transparent;
            PICBOX5.BackColor = Color.Transparent;
            PICBOX6.BackColor = Color.Transparent;
            PICBOX7.BackColor = Color.Transparent;
            PICBOX8.BackColor = Color.Transparent;
            PICBOX9.BackColor = Color.Transparent;



            //enable all the PicBoxes
            PICBOX1.Enabled = true;
            PICBOX2.Enabled = true;
            PICBOX3.Enabled = true;
            PICBOX4.Enabled = true;
            PICBOX5.Enabled = true;
            PICBOX6.Enabled = true;
            PICBOX7.Enabled = true;
            PICBOX8.Enabled = true;
            PICBOX9.Enabled = true;
            */
            RestOneButton(PICBOX1);
            RestOneButton(PICBOX2);
            RestOneButton(PICBOX3);
            RestOneButton(PICBOX4);
            RestOneButton(PICBOX5);
            RestOneButton(PICBOX6);
            RestOneButton(PICBOX7);
            RestOneButton(PICBOX8);
            RestOneButton(PICBOX9);

        }
    }
}
