using System.Windows.Forms;

namespace CanYouUnlockTheCode.Code
{
     interface GameInterface
     {
          void SetHintTextBoxes(TextBox[,] textBoxes);
          void SetCodeTextBoxes(TextBox[] textBoxes);
          bool QuizSolved();
          void NextQuiz();
          void SetDifficulty(int newDifficulty);
          int TriesRemain();
     }
}
