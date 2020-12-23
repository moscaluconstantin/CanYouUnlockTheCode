using CanYouUnlockTheCode.Code;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CanYouUnlockTheCode
{
     public partial class Form1 : Form
     {
          string ImagePath;
          string UnlockedImagePath;
          string LockedImagePath;
          GameInterface gameInterface;
          public Form1()
          {
               InitializeComponent();
               var temp = System.IO.Directory.GetCurrentDirectory();
               UnlockedImagePath = temp + @"\unlocked.png";
               LockedImagePath = temp + @"\locked.png";
               ImagePath = LockedImagePath;
               var Hints = new TextBox[,] { { textBox1, textBox2, textBox3 }, { textBox4, textBox5, textBox6 }, { textBox7, textBox8, textBox9 }, { textBox10, textBox11, textBox12 }, { textBox13, textBox14, textBox15 } };
               var Digits = new TextBox[] { Digit1textBox, Digit2textBox, Digit3textBox };
               gameInterface = new GameInterfaceForAlg1();
               gameInterface.SetCodeTextBoxes(Digits);
               gameInterface.SetHintTextBoxes(Hints);
               gameInterface.SetDifficulty(1);
          }

          private void UnlockButton_Click(object sender, EventArgs e)
          {
               if (gameInterface.QuizSolved())
               {
                    ImagePath = UnlockedImagePath;
                    MessageBox.Show("Congratulations!!!");
                    this.Invalidate();
               }
               else
               {
                    if (gameInterface.TriesRemain() <= 0)
                    {
                         MessageBox.Show("Next time!!!");
                         gameInterface.NextQuiz();
                    }
               }
          }

          private void Form1_Paint(object sender, PaintEventArgs e)
          {
               Image image = Image.FromFile(ImagePath);
               pictureBox1.Image = image;
          }

          private void DigitInc(TextBox textBox)
          {
               int Value = Convert.ToInt16(textBox.Text);
               Value++;
               if (Value > 9)
                    Value -= 10;
               textBox.Text = Value.ToString();
          }

          private void DigitDec(TextBox textBox)
          {
               int Value = Convert.ToInt16(textBox.Text);
               Value--;
               if (Value < 0)
                    Value += 10;
               textBox.Text = Value.ToString();     
          }

          private void Digit1IncButton_Click(object sender, EventArgs e)
          {
               this.DigitInc(Digit1textBox);
          }

          private void Digit2IncButton_Click(object sender, EventArgs e)
          {
               this.DigitInc(Digit2textBox);
          }

          private void Digit3IncButton_Click(object sender, EventArgs e)
          {
               this.DigitInc(Digit3textBox);
          }

          private void Digit1DecButton_Click(object sender, EventArgs e)
          {
               this.DigitDec(Digit1textBox);
          }

          private void Digit2DecButton_Click(object sender, EventArgs e)
          {
               this.DigitDec(Digit2textBox);
          }

          private void Digit3DecButton_Click(object sender, EventArgs e)
          {
               this.DigitDec(Digit3textBox);
          }

          private void Form1_Click(object sender, EventArgs e)
          {
               if (gameInterface.QuizSolved())
               {
                    gameInterface.NextQuiz();
                    ImagePath = LockedImagePath;
                    this.Invalidate();
               }
                    
          }
     }
}
