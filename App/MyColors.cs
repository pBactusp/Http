using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Colors
{
    public static class MyColors
    {
        public static Color McdoYellow { get; }
        public static Color McdoYellowDim { get; }
        public static Color McdoRed { get; }
        public static Color McdoRedDim { get; }

        static MyColors()
        {
            McdoYellow = new Color(255, 199, 44);
            McdoYellowDim = new Color(211, 155, 0);
            McdoRed = new Color(218, 41, 28);
            McdoRedDim = new Color(190, 13, 0);
        }
    }
}
