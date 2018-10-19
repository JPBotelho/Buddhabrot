using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;

namespace Buddhabrot
{
    class Program
    {
        private static int width = 1920, height = 1080;
		private static int redIters = 100000, greenIters = 20000, blueIters = 7500;
        static void Main(string[] args)
        {
			try
			{
				DateTime t = DateTime.Now;

				int[] redValues = new Plotter().BeginPlot(width, height, redIters);
				Console.WriteLine("Finished plotting R channel in " + DateTime.Now.Subtract(t).TotalSeconds + " s");
				t = DateTime.Now;

				int[] greenValues = new Plotter().BeginPlot(width, height, greenIters);
				Console.WriteLine("Finished plotting G channel in " + DateTime.Now.Subtract(t).TotalSeconds + " s");
				t = DateTime.Now;

				int[] blueValues = new Plotter().BeginPlot(width, height, blueIters);
				Console.WriteLine("Finished plotting B channel in " + DateTime.Now.Subtract(t).TotalSeconds + " s");
				t = DateTime.Now;


				Bitmap b = new Bitmap(width, height);

				Console.WriteLine(Plotter.biggestHit);

				for (int w = 0; w < width; w++)
				{
					for (int h = 0; h < height; h++)
					{
						int red = redValues[h * width + w];
						float redCol = (float)Math.Truncate(255 * Math.Sqrt(red) / Math.Sqrt(Plotter.biggestHit));

						int green = greenValues[h * width + w];
						float greenCol = (float)Math.Truncate(255 * Math.Sqrt(green) / Math.Sqrt(Plotter.biggestHit));

						int blue = blueValues[h * width + w];
						float blueCol = (float)Math.Truncate(255 * Math.Sqrt(blue) / Math.Sqrt(Plotter.biggestHit));



						Color c = Color.FromArgb((int)redCol, (int)greenCol, (int)blueCol);
						b.SetPixel(w, h, c);
					}
				}
				Console.WriteLine("Completed in: " + DateTime.Now.Subtract(t).TotalSeconds);

				b.Save("image.PNG");
				Console.WriteLine("Bitmap Saved");
				Console.ReadKey();
				System.Diagnostics.Process.Start("image.PNG");
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
        }





        
    }


}