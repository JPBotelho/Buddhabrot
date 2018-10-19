using System.Collections.Generic;
using System;
namespace Buddhabrot
{
	public struct Complex
	{
		public double real;
		public double imaginary;

		public Complex(double real, double imaginary)
		{
			this.real = real;
			this.imaginary = imaginary;
		}
		public void Set(double real, double imaginary)
		{
			this.real = real;
			this.imaginary = imaginary;
		}

		public Complex conjugate { get { return Conjugate(this); } }
		public Complex inverse { get { return Inverse(this); } }
		public Complex sqrt { get { return Sqrt(this); } }
		public double squaredAbs { get { return SquaredAbs(this); } }
		public double abs { get { return Abs(this); } }
		public bool isReal { get { return (Conjugate(this) == this); } }

		public Complex Multiply(Complex c) { return Multiply(this, c); }
		public Complex Divide(Complex c) { return Divide(this, c); }
		public Complex Add(Complex c) { return Add(this, c); }
		public Complex Subtract(Complex c) { return Subtract(this, c); }

		public override string ToString()
		{
			return string.Format("Re{0}), Im({1})", this.real, this.imaginary);
		}

		public override bool Equals(object obj)
		{
			if (obj is Complex == false)
				return false;

			return (Complex)obj == this;
		}

		public static bool operator ==(Complex c1, Complex c2) { return (c1.real == c2.real && c1.imaginary == c2.imaginary); }
		public static bool operator !=(Complex c1, Complex c2) { return (c1.real != c2.real || c1.imaginary != c2.imaginary); }
		public static bool operator >(Complex c1, Complex c2) { return c1.squaredAbs > c2.squaredAbs; }
		public static bool operator <(Complex c1, Complex c2) { return c1.squaredAbs < c2.squaredAbs; }

		public static Complex operator +(Complex c1, Complex c2) { return c1.Add(c2); }
		public static Complex operator -(Complex c1, Complex c2) { return c1.Subtract(c2); }
		public static Complex operator *(Complex c1, Complex c2) { return c1.Multiply(c2); }
		public static Complex operator /(Complex c1, Complex c2) { return c1.Divide(c2); }

		public static Complex Conjugate(Complex c)
		{
			return new Complex(c.real, -c.imaginary);
		}

		public static Complex Inverse(Complex c)
		{
			double real = c.real / Abs(c);
			double imaginary = c.imaginary / Abs(c);

			return new Complex(real, -imaginary);
		}

		public static double SquaredAbs(Complex c)
		{
			return c.real * c.real + c.imaginary * c.imaginary;
		}
		public static double Abs(Complex c)
		{
			return Math.Sqrt(c.real * c.real + c.imaginary * c.imaginary);
		}

		public static Complex Divide(Complex c1, Complex c2)
		{
			double a = c1.real;
			double b = c1.imaginary;
			double c = c2.real;
			double d = c2.imaginary;

			double real = ((a * c) + (b * d)) / (c * c + d * d);
			double imaginary = ((b * c) - (a * d)) / (c * c + d * d);

			return new Complex(real, imaginary);
		}

		public static Complex Multiply(Complex c1, Complex c2)
		{
			double a = c1.real;
			double b = c1.imaginary;
			double c = c2.real;
			double d = c2.imaginary;

			return new Complex(a * c - b * d, b * c + a * d);
		}

		Complex Sqrt(Complex complex)
		{
			if (complex.imaginary == 0)
				return new Complex(Math.Sqrt(complex.real), 0);

			double real = Math.Sqrt((complex.real + Abs(complex)) / 2);
			double imaginary = Math.Sign(complex.imaginary) * Math.Sqrt((-complex.real + Abs(complex)) / 2);

			return new Complex(real, imaginary);
		}

		public static Complex Add(Complex c1, Complex c2)
		{
			return new Complex(c1.real + c2.real, c1.imaginary + c2.imaginary);
		}
		public static Complex Subtract(Complex c1, Complex c2)
		{
			return new Complex(c1.real - c2.real, c1.imaginary - c2.imaginary);
		}
	}
}