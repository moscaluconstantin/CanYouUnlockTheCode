using System;
using System.Collections.Generic;

namespace CanYouUnlockTheCode.Code
{
     class DiffRandsFromRange
     {
          int[] Rands;
          List<int> RandsList;
          Random random;
          public DiffRandsFromRange(int[] Range)
          {
               Rands = Range;
               Reset();
               random = new Random();
          }
          public void Reset()
          {
               RandsList = new List<int>();
               RandsList.AddRange(Rands);
          }
          public int GetRandFromRange()
          {
               int ToReturnIndx = random.Next(RandsList.Count);
               int ToReturn = RandsList[ToReturnIndx];
               RandsList.Remove(ToReturn);
               return ToReturn;
          }
          public int[] GetRange()
          {
               return RandsList.ToArray();
          }
          public void Remove(int Item)
          {
               RandsList.Remove(Item);
          }
          public void Remove(int[] Items)
          {
               foreach(int Item in Items)
               {
                    RandsList.Remove(Item);
               }
          }
     }
}
