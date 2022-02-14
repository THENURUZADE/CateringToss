using System;
using System.Collections.Generic;
using System.Text;
using TaskForToss.Models;

namespace TaskForToss.Helpers
{
    public static class EnumarationHelper
    {
        public static void Numerator(List<ChiefModel> models, int startIndex = 1)
        {
            for (int i = startIndex; i <= models.Count; i++)
            {
                models[i - 1].No = i;
            }
        }
    }
}
