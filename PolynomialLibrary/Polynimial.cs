using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialLibrary
{
    public class Polynimial
    {
        private int[] array;

        public Polynimial(int[] array)
        {
            if (array == null)
                throw new NullReferenceException();

            DeleteNullInStart(ref array);
            this.array = new int[array.Length];
            Array.Copy(array, this.array, array.Length);
        }

        public int Calculate(int x)
        {
            int value = 0, xPow = 1;

            for(int i = 0; i < array.Length; i++)
            {
                value += array[i] * xPow;
                xPow *= x;
            }

            return value;
        }
        public override string ToString()
        {
            int n = array.Length - 1;
            string s = string.Format("{0} x^{1}", array[n], n);

            for (int i = n - 1; i > 0; i--)
            {
                if (array[i] == 0) continue;
                if (array[i] > 0)
                    s += "+";
                s += string.Format("{0} x^{1}", array[i], i);
            }

            if (array[0] == 0) return s;
            if (array[0] > 0) s += "+";
            return s + string.Format("{0}", array[0]);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Parallel)) return false;

            return Equals((Polynimial)obj);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public int this[int i]
        {
            get
            {
                return array[i];
            }
        }
        public static implicit operator Polynimial (int[] a)
        {
            return new Polynimial(a);
        }
        public static implicit operator int[](Polynimial p)
        {
            return p.array;
        }
        public static Polynimial operator + (Polynimial p1, Polynimial p2)
        {
            int minLength = Math.Min(p1.array.Length, p2.array.Length);
            int maxLength = Math.Max(p1.array.Length, p2.array.Length);
            int[] coef = new int[maxLength];
            
            for(int i = 0; i < minLength; i++)
                coef[i] = p1.array[i] + p2.array[i];

            if(p1.array.Length == maxLength)
            {
                for (int i = minLength; i < maxLength; i++)
                    coef[i] = p1.array[i];
            }
            else
            {
                for (int i = minLength; i < maxLength; i++)
                    coef[i] = p2.array[i];
            }

            DeleteNullInStart(ref coef);

            return new Polynimial(coef);
        }
        public static Polynimial operator - (Polynimial p1, Polynimial p2)
        {
            int minLength = Math.Min(p1.array.Length, p2.array.Length);
            int maxLength = Math.Max(p1.array.Length, p2.array.Length);
            int[] coef = new int[maxLength];

            for (int i = 0; i < minLength; i++)
                coef[i] = p1.array[i] - p2.array[i];

            if (p2.array.Length == maxLength)
                for (int i = minLength; i < maxLength; i++)
                    coef[i] = - p2.array[i];
            else
                for (int i = minLength; i < maxLength; i++)
                    coef[i] = p1.array[i];

            DeleteNullInStart(ref coef);
            
            return new Polynimial(coef);
        }
        public static Polynimial operator * (Polynimial p1, Polynimial p2)
        {
            int[] coef = new int[p1.array.Length + p2.array.Length - 1];

            for (int i = 0; i < p1.array.Length; i++)
                for (int j = 0; j < p2.array.Length; j++)
                    coef[i + j] += p1.array[i] * p2.array[j];

            return new Polynimial(coef);
        }
        public static Polynimial operator * (Polynimial p1, int c)
        {
            int[] newArray = new int[p1.array.Length];
            Array.Copy(p1.array, newArray, p1.array.Length);

            for (int i = 0; i < p1.array.Length; i++)
                newArray[i] *= c;

            return new Polynimial(newArray);
        }
        public static Polynimial operator * (int c, Polynimial p1)
        {
            return p1 * c;
        }
        public static bool operator == (Polynimial p1, Polynimial p2)
        {
            return p1.Equals(p2);
        }
        public static bool operator != (Polynimial p1, Polynimial p2)
        {
            return !p1.Equals(p2);
        }
        private bool Equals(Polynimial p)
        {
            return array.SequenceEqual(p.array);
        }
        private static void DeleteNullInStart(ref int[] coef)
        {
            int ind = coef.Length - 1;
            while (ind > 0 && coef[ind] == 0)
                ind--;

            if (ind != 0)
                Array.Copy(coef, coef, ind);
            else
                coef = new int[1];
        }
    }
}
