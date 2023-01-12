using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Polynomial
{
    public class Polynomial : IEquatable<Polynomial>
    {
        public const int NumbersOfFreeDegreeMember = 1;

        private readonly double[] _ratios;

        private int _degree;

        public Polynomial(params double[] ratios)
        {
            if (ratios == null || ratios.Length == 0 || CheckRatiosOnZero(ratios))
            {
                _ratios = new double[1] { 0 };
            }

            _ratios = ratios;

            InitializeDegree();
        }

        public double this[int index] => _ratios[index];

        public int Length => _ratios.Length;
        public int Degree => _degree;

        public double[] Ratios => _ratios;

        private bool CheckRatiosOnZero(double[] ratios)
        {
            return ratios.All(ratio => ratio == 0);
        }

        private void InitializeDegree()
        {
            for (int i = _ratios.Length - 1; i >= 0; i--)
            {
                if (_ratios[i] != 0)
                {
                    _degree = i;
                    break;
                }
            }
        }

        public override string ToString()
        {
            return GetStringResultOfCreatePolynomial();
        }

        private string GetStringResultOfCreatePolynomial()
        {
            if (CheckRatiosOnZero(_ratios))
            {
                return "0";
            }

            StringBuilder result = new StringBuilder();

            for (var degree = Degree; degree >= 0; --degree)
            {
                var coefficient = _ratios[degree];
                var format = (degree, Math.Abs(coefficient)) switch
                {
                    (_, 0) => string.Empty,
                    (0, _) => "{0:+0;-0}",
                    (1, 1) => "{0:+x;-x}",
                    (1, _) => "{0:+0;-0}x",
                    (_, _) => "{0:+0;-0}x^{1}"
                };

                result.AppendFormat(format, coefficient, degree);
            }

            return result.ToString().TrimStart('+');
        }

        private static void CheckPolynomialOnNull(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (firstPolynomial is null)
            {
                throw new ArgumentNullException(nameof(firstPolynomial));
            }
            if (secondPolynomial is null)
            {
                throw new ArgumentNullException(nameof(secondPolynomial));
            }
        }


        public bool Equals(Polynomial polynomial)
        {
            if (ReferenceEquals(null, polynomial)) return false;
            if (ReferenceEquals(this, polynomial)) return true;

            return this._ratios.SequenceEqual(polynomial._ratios);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Polynomial)) return false;

            return Equals(obj as Polynomial);
        }
        public override int GetHashCode() => HashCode.Combine(_ratios);

        public static bool operator ==(Polynomial firstPolynomial, Polynomial secondPolynomial) => Equals(firstPolynomial, secondPolynomial);
        public static bool operator !=(Polynomial firstPolynomial, Polynomial secondPolynomial) => !Equals(firstPolynomial, secondPolynomial);

        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            CheckPolynomialOnNull(firstPolynomial, secondPolynomial);

            double[] ratios = (firstPolynomial.Length > secondPolynomial.Length) ? new double[firstPolynomial.Length] :
                 new double[secondPolynomial.Length];

            for (var i = 0; i < ratios.Length; i++)
            {
                if (i >= firstPolynomial.Length)
                {
                    ratios[i] += secondPolynomial._ratios[i];
                }
                else if (i >= secondPolynomial._ratios.Length)
                {
                    ratios[i] += firstPolynomial._ratios[i];
                }
                else
                {
                    ratios[i] = firstPolynomial._ratios[i] + secondPolynomial._ratios[i];
                }
            }

            return new Polynomial(ratios);
        }

        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            CheckPolynomialOnNull(firstPolynomial, secondPolynomial);

            double[] ratios = (firstPolynomial.Length > secondPolynomial.Length) ? new double[firstPolynomial.Length] :
                 new double[secondPolynomial.Length];

            for (var i = 0; i < ratios.Length; i++)
            {
                if (i >= firstPolynomial.Length)
                {
                    ratios[i] -= secondPolynomial._ratios[i];
                }
                else if (i >= secondPolynomial.Length)
                {
                    ratios[i] = firstPolynomial._ratios[i];
                }
                else
                {
                    ratios[i] = firstPolynomial._ratios[i] - secondPolynomial._ratios[i];
                }
            }

            return new Polynomial(ratios);
        }

        public static Polynomial operator *(Polynomial polynomial, double number)
        {
            if (polynomial is null)
            {
                throw new ArgumentNullException(nameof(polynomial));
            }

            double[] ratios = new double[polynomial.Length];

            for (var i = 0; i < ratios.Length; i++)
            {
                ratios[i] = polynomial._ratios[i] * number;
            }

            return new Polynomial(ratios);
        }

        public static Polynomial operator *(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            CheckPolynomialOnNull(firstPolynomial, secondPolynomial);

            double[] ratios = new double[firstPolynomial.Degree + secondPolynomial.Degree + 1];

            for (var i = 0; i < firstPolynomial.Degree + 1; i++)
            {
                for (var j = 0; j < secondPolynomial.Degree + 1; j++)
                {
                    ratios[i + j] += firstPolynomial._ratios[i] * secondPolynomial._ratios[j];
                }
            }

            return new Polynomial(ratios);
        }
    }
}
