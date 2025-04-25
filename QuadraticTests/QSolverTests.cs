using OtusQuadraticSolver;

namespace QuadraticTests
{
    [TestFixture]
    public class QSolverTests
    {

        [Test]
        public void Solve_NoRealRoots_ReturnsEmptyArray()
        {
            var result = QSolver.Solve(1, 0, 1);
            Assert.IsEmpty(result);
        }

        [Test]
        public void Solve_TwoDistinctRoots_ReturnsBothRoots()
        {
            var result = QSolver.Solve(1, 0, -1);
            Assert.AreEqual(2, result.Length);
            Assert.Contains(1, result);
            Assert.Contains(-1, result);
        }

        [Test]
        public void Solve_DoubleRoot_ReturnsOneRoot()
        {
            var result = QSolver.Solve(1, 2, 1);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(-1, result[0], 1e-9);
        }

        [Test]
        public void Solve_AIsZero_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => QSolver.Solve(0.0, 2, 1));
        }

        [Test]
        public void Solve_AlmostZeroDiscriminant_ReturnsOneRoot()
        {
            var result = QSolver.Solve(1, 2.00000000001, 1);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(-1, result[0], 1e-5);
        }

        [TestCase(double.NaN, 1, 1)]
        [TestCase(1, double.NaN, 1)]
        [TestCase(1, 1, double.NaN)]
        [TestCase(double.PositiveInfinity, 1, 1)]
        [TestCase(1, double.NegativeInfinity, 1)]
        [TestCase(1, 1, double.PositiveInfinity)]
        public void Solve_NonFiniteInputs_ThrowsArgumentException(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => QSolver.Solve(a, b, c));
        }
    }
}