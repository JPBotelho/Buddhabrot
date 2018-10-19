using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Buddhabrot
{
    class ComplexFuncs
    {
        public static float CalcPercent(float min, float max, float input)
        {
            return ((input - min) * 100) / (max - min);
        }

        public static float ValueFromPercent(float min, float max, float percent)
        {
            return (percent * (max - min) / 100) + min;
        }

        public static float ConvertRange(Vector2 originalRange, Vector2 targetRange, float value)
        {
            float originalPercentage = CalcPercent(originalRange.X, originalRange.Y, value);
            return ValueFromPercent(targetRange.X, targetRange.Y, originalPercentage);
        }

        public static float ClampScaleX(float x)
        {
            return ConvertRange(new Vector2(0, 1), Plotter.xRange, x);
        }

        public static float ClampScaleY(float y)
        {
            return ConvertRange(new Vector2(0, 1), Plotter.yRange, y);
        }
    }
}
