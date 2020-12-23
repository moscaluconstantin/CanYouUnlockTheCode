using System.Windows.Forms;

namespace CanYouUnlockTheCode.Code
{
     class GameInterfaceForAlg1 : GameInterface
     {
          CodeGenerator CodGen;
          TextBox[,] Hints;
          TextBox[] Code;
          int Tries;
          public int TriesRemain()
          {
               return Tries;
          }
          public GameInterfaceForAlg1()
          {
               CodGen = new CodeGenerator();
               Tries = 3;
          }
          public void SetHintTextBoxes(TextBox[,] textBoxes)
          {
               Hints = textBoxes;
               RefreshTextBoxes();
          }
          public void SetCodeTextBoxes(TextBox[] textBoxes)
          {
               Code = textBoxes;
          }
          public bool QuizSolved()
          {
               for (int i = 0; i < Code.Length; i++)
               {
                    if (Code[i].Text != CodGen.Code[i].ToString())
                    {
                         Tries--;
                         return false;
                    }
               }
               return true;
          }
          public void NextQuiz()
          {
               CodGen.NewQuiz();
               RefreshTextBoxes();
               Tries = 3;
          }
          void RefreshTextBoxes()
          {
               for (int i = 0; i < Code.Length; i++)
               {
                    Code[i].Text = "0";
               }
               for (int i = 0; i < 5; i++)
               {
                    for (int j = 0; j < 3; j++)
                    {
                         Hints[i, j].Text = CodGen.Hints[i, j].ToString();
                    }
               }
          }
          public void SetDifficulty(int newDifficulty)
          {
               CodGen.Difficulty = newDifficulty;
          }
     }
}
