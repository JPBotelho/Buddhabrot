using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Buddhabrot.ComplexFuncs;
using System.Numerics;
using static Buddhabrot.Complex; 

namespace Buddhabrot
{
    class Plotter
    {
        public static int width = 1920, height = 1080;
        private int[] values;
		public static int biggestHit = 0;

		public static Vector2 xRange = new Vector2(-1.75f, 1.75f)*1.25f;
		public static Vector2 yRange = new Vector2(-1, 1)*1.25f;

		public int[] BeginPlot(int width, int height, int iterations)
        {
            Plotter.width = width;
            Plotter.height = height;

            values = new int[width * height];

            PerformIterations(iterations);

            return values;
        }

        private void PerformIterations(int iters)
        {
			Random r = new Random();

			Vector2 originalRange = new Vector2(0, 1);
			

			Complex c = new Complex();
			Complex z = new Complex();

			for (int i = 0; i < iters; i++)
			{

				float x = (float)r.NextDouble();
				float y = (float)r.NextDouble();

				x = ConvertRange(originalRange, xRange, x);
				y = ConvertRange(originalRange, yRange, y);

				c.Set(x, y);

				z = c;
				

				int iteration = 0;

				for(; iteration < 15; iteration++)
				{
					if(z.real * z.real + z.imaginary * z.imaginary >= 4)
					{
						Iterate(c);
						break;
					}
					z = z.conjugate;
					z = z * z;
					z += c;
				}
				
			}
		}

		private void Iterate(Complex c)
		{
			Complex z = c;
			int iteration = 0;
			while (z.real * z.real + z.imaginary * z.imaginary < 4 && iteration < 15)
			{
				z = z.conjugate;
				z = z * z;
				z += c;

				if (iteration > 4)
					SavePoint(z);
				iteration++;
			}
		}


		private void SavePoint(Complex c)
		{
			float x = (float)c.real;
			float y = (float)c.imaginary;

			float clampedX = ConvertRange(xRange, new Vector2(0, width), x);
			float clampedY = ConvertRange(yRange, new Vector2(0, height), y);

			if (clampedX <= 0 || clampedX >= width) return;
			if (clampedY <= 0 || clampedY >= height) return;

			int index = (int)clampedY * width + (int)clampedX;

			if (index == width * height) index--;

			//if (values[index] < 255)
				values[index]++;

			if (values[index] > biggestHit) biggestHit = values[index];

        }
    }
}
