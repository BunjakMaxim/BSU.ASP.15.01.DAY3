using System;
using System.Diagnostics;
using NUnit.Framework;

namespace PolynomialLibrary.Test
{
    [TestFixture]
    public class PolynimialTest
    {
        [TestCase(new int[] { 3, 2, 3 }, new int[] { 2, 3, 2 }, 1)]
        [TestCase(new int[] { 4, 3, 2, 1}, new int[] {1, 0, 1, 1, 0, 2}, 5)]
        [TestCase(new int[] { -1, 0, 1, 1,-5 }, new int[] { 1, 1 }, 2)]
        [TestCase(new int[] { -1, 0, -1, -10 }, new int[] { 1, -10 }, 3)]
        public void TestOperatorADD(int[] a, int[] b, int r)
        {
            Polynimial p1 = new Polynimial(a);
            Polynimial p2 = new Polynimial(b);
            Polynimial p3;

            Debug.WriteLine(p1);
            Debug.WriteLine(p2);

            p3 = p1 + p2;
            Debug.WriteLine(p3);

            Assert.AreEqual(p3.Calculate(r), p1.Calculate(r) + p2.Calculate(r));
        }

        [TestCase(new int[] { 3, 2, 3 }, new int[] { 1, 1, 1 }, 1)]
        [TestCase(new int[] { 4, 3, 2, 1 }, new int[] { 1, 1}, 1)]
        [TestCase(new int[] { -1, 0, 1, 1 }, new int[] { 2, 1 }, 2)]
        [TestCase(new int[] { 2,5,3,1}, new int[] { 1, -1 }, 2)]
        public void TestOperatorMull(int[] a, int[] b, int r)
        {
            Polynimial p1 = new Polynimial(a);
            Polynimial p2 = new Polynimial(b);
            Polynimial p3;

            Debug.WriteLine(p1);
            Debug.WriteLine(p2);
            
            p3 = p1 * p2;
            Debug.WriteLine(p3);

            Assert.AreEqual(p3.Calculate(r), p1.Calculate(r) * p2.Calculate(r));
        }
        
        [TestCase(new int[] { 3, 2, 3 }, 3)]
        [TestCase(new int[] { 4, 3, 2, 1 }, 5)]
        [TestCase(new int[] { -1, 0, 1, 1 }, 2)]
        [TestCase(new int[] { 2, 5, 3, 1 }, 7)]
        public void TestOperatorMullConst(int[] a, int c)
        {
            int r = 3;
            Polynimial p1 = new Polynimial(a), p2, p3;

            Debug.WriteLine(p1);
            p2 = p1 * c;
            Debug.WriteLine(p2);
            p3 = p1 * c;
            Debug.WriteLine(p3);

            Assert.AreEqual(p1.Calculate(r)*c, p2.Calculate(r));
            Assert.AreEqual(p3.Calculate(r), p2.Calculate(r));
        }

        [TestCase(new int[] { 3, 2, 3 }, new int[] { 2, 3, 2 }, 1)]
        [TestCase(new int[] { 4, 3, 2, 1 }, new int[] { 0, 1, 1, 0, 2 }, 1)]
        [TestCase(new int[] { -1, 0, 1, 1 }, new int[] { 1, 1 }, 2)]
        [TestCase(new int[] { -1, 0, -1, -1 }, new int[] { 1, -1 }, 2)]
        public void TestOperatorMinus(int[] a, int[] b, int r)
        {
            Polynimial p1 = new Polynimial(a);
            Polynimial p2 = new Polynimial(b);
            Polynimial p3;

            Debug.WriteLine(p1);
            Debug.WriteLine(p2);

            p3 = p1 - p2;
            Debug.WriteLine(p3);

            Assert.AreEqual(p3.Calculate(r), p1.Calculate(r) - p2.Calculate(r));
        }


        [TestCase(new int[] { 3, 2, 3 }, new int[] { 2, 3, 2},Result = false)]
        [TestCase(new int[] { 4, 3, 2, 1 }, new int[] { 0, 1, 1, 0, 2 }, Result = false)]
        [TestCase(new int[] { -1, 0, 1, 1 }, new int[] { 1, 1}, Result = false)]
        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1}, Result = true)]
        [TestCase(new int[] { 1, 0, 1, 1 }, new int[] { 1, 1 }, Result = false)]
        public bool TestEquals(int[] a, int[] b)
        {
            Polynimial p1 = new Polynimial(a);
            Polynimial p2 = new Polynimial(b);

            Debug.WriteLine(p1);
            Debug.WriteLine(p2);

            return p1 == p2;
        }

        [TestCase(new int[] { 1, 1, 1 }, new int[] { 1, 1, 1 }, Result = true)]
        [TestCase(new int[] { -1, 0, 1, 1 }, new int[] { 1, 1 }, Result = false)]
        public bool TestGetHashCode(int[] a, int[] b)
        {
            Polynimial p1 = new Polynimial(a);
            Polynimial p2 = new Polynimial(b);

            return p1.GetHashCode() == p2.GetHashCode();
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestConstructor()
        {
            int[] f = null;
            Polynimial p = new Polynimial(f);
        }
    }
}