using System;

namespace CanYouUnlockTheCode.Code
{
     class CodeGenerator
     {
          int[] _Code;
          int[] Digits;
          int[,] _CodeHints;
          int _Difficulty;
          Random random;
          DiffRandsFromRange diffRands;
          public CodeGenerator()
          {
               random = new Random();
               _Difficulty = 3;
               NewQuiz();
          }
          public void NewQuiz()
          {
               GenereteTheCode();
               GenerateTheDigits();
               GenerateTheHints();
          }
          void GenereteTheCode()
          {
               DiffRandsFromRange CodeRands = new DiffRandsFromRange(new int[] 
               { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
               _Code = new int[3];
               for (int i = 0; i < _Code.Length; i++)
               {
                    _Code[i] = CodeRands.GetRandFromRange();
               }
          }
          void GenerateTheDigits()
          {
               DiffRandsFromRange tempRands = new DiffRandsFromRange(new int[] 
               { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
               tempRands.Remove(_Code);
               Digits = tempRands.GetRange();
               diffRands = new DiffRandsFromRange(Digits);
          }
          void GenerateTheHints()
          {
               _CodeHints = new int[5, 3];

               var temp = OneRightPlace();
               CompleteHint(0, temp);

               temp = OneRightWrongPlace();
               CompleteHint(1, temp);

               temp = TwoRightWrongPlace();
               CompleteHint(2, temp);

               temp = NothingRight();
               CompleteHint(3, temp);

               temp = OneRightWrongPlace();
               CompleteHint(4, temp);
          }
          int[] OneRightPlace()
          {
               int[] temp = new int[3];
               int indx = random.Next(3);
               temp[indx] = _Code[indx];

               diffRands.Reset();

               for (int i = 0; i < temp.Length; i++)
               {
                    if (i != indx)
                    {
                         temp[i] = diffRands.GetRandFromRange();
                    }
               }
               return temp;
          }
          int[] OneRightWrongPlace()
          {
               int[] temp = new int[3];
               int indx = random.Next(3);
               int tindx = random.Next(2);
               if (tindx == indx)
               {
                    switch (indx)
                    {
                         case 0:
                              tindx++;
                              break;
                         case 1:
                              int delta = random.Next(2);
                              switch (delta)
                              {
                                   case 0:
                                        tindx--;
                                        break;
                                   case 1:
                                        tindx++;
                                        break;
                                   default:break;
                              }
                              break;
                         case 2:
                              tindx--;
                              break;
                         default:break;
                    }
               }
               temp[tindx] = _Code[indx];

               diffRands.Reset();

               for (int i = 0; i < temp.Length; i++)
               {
                    if (i != tindx)
                    {
                         temp[i] = diffRands.GetRandFromRange();
                    }
               }
               return temp;
          }
          int[] TwoRightWrongPlace()
          {
               int[] temp = new int[3];
               int indx = random.Next(3);
               int[] tindx = new int[2];

               diffRands.Reset();

               switch (indx)
               {
                    case 0:
                         tindx[0] = 1;
                         tindx[1] = 2;
                         break;
                    case 1:
                         tindx[0] = 0;
                         tindx[1] = 2;
                         break;
                    case 2:
                         tindx[0] = 0;
                         tindx[1] = 1;
                         break;
                    default:
                         tindx[0] = 3;
                         tindx[1] = 3;
                         break;
               }

               for (int i = 0; i < tindx.Length; i++)
               {
                    DiffRandsFromRange diffPos = new DiffRandsFromRange(new int[] 
                    { 0, 1, 2 });
                    diffPos.Remove(tindx[i]);
                    int t = diffPos.GetRandFromRange();
                    temp[t] = _Code[tindx[i]];
                    tindx[i] = t;
               }

               DiffRandsFromRange lastDiffPos = new DiffRandsFromRange(new int[] 
               { 0, 1, 2 });
               lastDiffPos.Remove(tindx);
               temp[lastDiffPos.GetRandFromRange()] = diffRands.GetRandFromRange();


               return temp;
          }
          int[] NothingRight()
          {
               int[] temp = new int[3];
               diffRands.Reset();

               int[] toRemove = new int[6];
               for (int i = 0; i < 3; i++)
               {
                    toRemove[i] = _CodeHints[1, i];
                    toRemove[i + 3] = _CodeHints[2, i];
               }
               diffRands.Remove(toRemove);

               for (int i = 0; i < temp.Length; i++)
               {
                    temp[i] = diffRands.GetRandFromRange();
               }
               return temp;
          }
          void CompleteHint(int Indx, int[] ToAdd)
          {
               if (Indx < 0 || Indx >= _CodeHints.Length / 3)
                    return;
               for (int i = 0; i < 3; i++)
               {
                    _CodeHints[Indx, i] = ToAdd[i];
               }
          }
          public int[] Code { get { return _Code; } }
          public int[,] Hints { get { return _CodeHints; } }
          public int Difficulty
          {
               set
               {
                    if (value > 0 && value < 4)
                    {
                         _Difficulty = value;
                         GenerateTheDigits();
                         GenerateTheHints();
                    }
               }
          }
     }
}
