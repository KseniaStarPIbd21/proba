using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMethods
{
    public class Data
    {
        //double[,] a = { { 2.0, 4.0, -4.0, 6.0 },
        //             { 1.0, 4.0, 2.0, 1.0 },
        //             { 3.0, 8.0, 1.0, 1.0 },
        //             { 2.0, 5.0, 0.0, 5.0 }};
        double[,] a;
        double[,] aInver;
        double[,] lu;
        double[] x;
        double[] b;
        double[] w;
        double[] xReady;
        int[] q;
        double[,] l;
        double[,] u;
        double[,] i;
        double errorX;
        double errorI;

        public void Init(int n)
        {
            Random r = new Random();
            a = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = (r.NextDouble() * 2 - 1) * 100;
                }
            }
            q = new int[n];
            x = new double[n];
            XReady = new double[n];
            i = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                q[i] = i;
                x[i] = i + 1.0;
                this.i[i, i] = 1;
            }
        }

        public void InitBadMatrx1(int n)
        {
            a = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (((i == 1) && (j == 0)) || ((i == 0) && (j == 1)))
                    {
                        a[i, j] = 0;
                    }
                    else
                    {
                        a[i, j] = 1 / (i + j - 1);
                    }
                }
            }
            q = new int[n];
            x = new double[n];
            XReady = new double[n];
            i = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                q[i] = i;
                x[i] = i + 1.0;
                this.i[i, i] = 1;
            }
        }

        public void InitBadMatrx2(int n)
        {
            a = new double[n, n];
            for (int i = 0; i < n; i++)
            {               
                    a[i, i] = 1;               
            }
            for (int i = 0; i < n-1; i++)
            {
                a[i, i+1] = 1;
            }
            q = new int[n];
            x = new double[n];
            XReady = new double[n];
            i = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                q[i] = i;
                x[i] = i + 1.0;
                this.i[i, i] = 1;
            }
        }

        public void InitBadMatrx3(int n)
        {
            double[,] a1 = { { 5.0, 4.0, 7.0, 5.0, 6.0, 7.0, 5.0},
                     { 4.0, 12.0, 8.0, 7.0, 8.0, 8.0,6.0},
                     { 7.0, 8.0, 10.0, 9.0, 8.0, 7.0, 7.0},
                     { 5.0, 7.0, 9.0, 11.0, 9.0, 7.0, 5.0},
                     { 6.0, 8.0, 8.0, 9.0, 10.0, 8.0, 9.0},
                     { 7.0, 8.0, 7.0, 7.0, 8.0, 10.0, 10.0},
                     { 5.0, 6.0, 7.0, 5.0, 9.0, 10.0, 10.0}};
            a = new double[n, n];
            Array.Copy(a1, a, 49);
            q = new int[n];
            x = new double[n];
            XReady = new double[n];
            i = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                q[i] = i;
                x[i] = i + 1.0;
                this.i[i, i] = 1;
            }
        }

        public void InitBadMatrx4(int n)
        {
            a = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                a[i, i]  = 0.01 / ((n - i + 1)*(i+1)); 
                for (int j = 0; j < i; j++)
                {
                    a[i, j] = i*(n-j);
                }
                for (int j = i+1; j < n; j++)
                {
                    a[i, j] = 0;
                }
            }
            q = new int[n];
            x = new double[n];
            XReady = new double[n];
            i = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                q[i] = i;
                x[i] = i + 1.0;
                this.i[i, i] = 1;
            }
        }

        public void InitBadMatrx5(int n)
        {
            a = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                a[i, i] = 0.01 / ((n - i + 1) * (i + 1));
                for (int j = 0; j < i; j++)
                {
                    a[i, j] = 0;
                }
                for (int j = i + 1; j < n; j++)
                {
                    a[i, j] = i * (n - j);
                }
            }
            q = new int[n];
            x = new double[n];
            XReady = new double[n];
            i = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                q[i] = i;
                x[i] = i + 1.0;
                this.i[i, i] = 1;
            }
        }

        public void InitBadMatrx6(int n, double arg)
        {
            a = new double[n, n];
            double[,] T = new double[,] { { 1, 1 }, { 1, 1 } };
            double[,] R = new double[,] { { ctg(arg), cosec(arg) },
{ -cosec(arg), ctg(arg) } };
            double[,] S = new double[,] { { 1 - ctg(arg), cosec(arg) },
{ 1 - cosec(arg), 1 + ctg(arg) } };
            for (int i = 0; i < n; i += 2)
            {
                for (int j = 0; j < n; j += 2)
                {
                    double[,] V = null;
                    if (i == j)
                    {
                        V = R;
                    }
                    else if (i == j + 2 || i + 2 == j)
                    {
                        V = S;
                    }
                    else
                    {
                        V = T;
                    }
                    for (int k = 0; k < 2; k++)
                    {
                        for (int t = 0; t < 2; t++)
                        {
                            a[i + k, j + t] = V[k, t];
                        }
                    }
                }
            }
        }

        public void InitBadMatrx7(int n, double al)
        {
            a = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                    a[i, i] = Math.Pow(al, Math.Abs(n-2*i)/2);                
            }
            for (int j = 0; j < n; j++)
            {
                a[0, j] = a[0, 0] / Math.Pow(al, j);
                a[j, 0] = a[1, j];
            }
            for (int j = 0; j < n; j++)
            {
                a[n-1, j] = a[n-1, n-1] / Math.Pow(al, j);
                a[j, n-1] = a[n-1, j];
            }
            q = new int[n];
            x = new double[n];
            XReady = new double[n];
            i = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                q[i] = i;
                x[i] = i + 1.0;
                this.i[i, i] = 1;
            }
        }

        public void InitBadMatrx8(int n, double h)
        {
            a = new double[n, n];
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    a[i, j] = Math.Pow( Math.E, i*j*h);
                }

            }
            q = new int[n];
            x = new double[n];
            XReady = new double[n];
            i = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                q[i] = i;
                x[i] = i + 1.0;
                this.i[i, i] = 1;
            }
        }

        public void InitBadMatrx9(int n, int c)
        {
            a = new double[n, n];
            for (int i = 0; i < n; i++)
            {
               
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = c + Math.Log((i * j), 2);
                }
                
            }
            q = new int[n];
            x = new double[n];
            XReady = new double[n];
            i = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                q[i] = i;
                x[i] = i + 1.0;
                this.i[i, i] = 1;
            }
        }

        public void InitBadMatrx10(int n)
        {
            double[,] a1 = { { 0.00009143, 0.0, 0.0, 0.0},
                     { 0.8762,  0.00007156, 0.0,0.0},
                     { 0.7943, 0.8143,  0.00009504, 0.0},                    
                     { 0.8017, 0.6123, 0.7165,  0.00007123}};
            a = new double[n, n];
            Array.Copy(a1, a, 16);
            q = new int[n];
            x = new double[n];
            XReady = new double[n];
            i = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                q[i] = i;
                x[i] = i + 1.0;
                this.i[i, i] = 1;
            }
        }

        double cosec(double arg)
        {
            try
            {
                return 1 / Math.Sin(arg);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        double ctg(double arg)
        {
            try
            {
                return Math.Sin(arg) / Math.Cos(arg);
            }
            catch (Exception e)
            {
                return 0;
            }
        }


        public double[,] A
        {
            get { return a; }
            set { a = value; }
        }

        public double[,] AInver
        {
            get { return aInver; }
            set { aInver = value; }
        }

        public int[] Q
        {
            get { return q; }
            set { q = value; }
        }
        public double[] X
        {
            get { return x; }
            set { x = value; }
        }

        public double[,] L
        {
            get { return l; }
            set { l = value; }
        }

        public double[,] U
        {
            get { return u; }
            set { u = value; }
        }

        public double[,] LU
        {
            get { return lu; }

            set { lu = value; }
        }

        public double[] W
        {
            get { return w; }
            set { w = value; }
        }

        public double[] B
        {
            get { return b; }
            set { b = value; }
        }

        public double[] XReady
        {
            get { return xReady; }
            set { xReady = value; }
        }

        public double[,] I
        {
            get { return i; }
            set { i = value; }
        }

        public double ErrorX
        {
            get { return errorX; }
            set { errorX = value; }
        }

        public double ErrorI
        {
            get { return errorI; }
            set { errorI = value; }
        }
    }
}
