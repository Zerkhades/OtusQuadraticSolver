using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusQuadraticSolver
{
    public static class QSolver
    {
        private const double Epsilon = 1e-10;

        public static double[] Solve(double a, double b, double c)
        {
            if (!IsFinite(a) || !IsFinite(b) || !IsFinite(c))
                throw new ArgumentException("Coefficients must be finite numbers.");

            if (Math.Abs(a) < Epsilon)
                throw new ArgumentException("Coefficient 'a' must not be zero.");

            double d = b * b - 4 * a * c;
            if (d < 0)
                return Array.Empty<double>();

            double sqrtD = Math.Sqrt(d);
            if (d > Epsilon)
                return new double[] { (-b + sqrtD) / (2 * a), (-b - sqrtD) / (2 * a) };

            return new double[] { -b / (2 * a) };
        }

        private static bool IsFinite(double x)
        {
            return !double.IsNaN(x) && !double.IsInfinity(x);
        }
    }
}
