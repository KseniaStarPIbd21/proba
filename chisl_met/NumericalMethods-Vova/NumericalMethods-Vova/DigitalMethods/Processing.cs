using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMethods
{
    static class Processing
    {
        /// <summary>
        /// LU-1 Жорданово исключение!!! ПЕРЕДЕЛАТЬ
        /// </summary>
        /// <param name="matrix">Матрица А</param>
        /// <param name="prem">Дополнительный вектор, позволяющий обращаться к определённым элементам в матрице</param>
        /// <returns></returns>
        public static double[,] LUrzl(double[,] matrix, ref int[] prem)
        {
            double[,] LUmatrix = MatrixDuplicate(matrix);
            for (int i = 0; i < LUmatrix.GetLength(0); i++)
            {
                ChangeColumns(i, LUmatrix, ref prem);
                for (int j = i + 1; j < LUmatrix.GetLength(0); j++)
                    LUmatrix[prem[i], j] = LUmatrix[prem[i], j] / LUmatrix[prem[i], i];
                for (int k = 0; k < i; k++)
                {
                    for (int j = i + 1; j < LUmatrix.GetLength(0); j++)
                        LUmatrix[prem[k], j] = LUmatrix[prem[k], j] - LUmatrix[prem[k], i] * LUmatrix[prem[i], j];
                }
                for (int k = i + 1; k < LUmatrix.GetLength(0); k++)
                {
                    for (int j = i+1; j < LUmatrix.GetLength(0); j++)
                        LUmatrix[prem[k], j] = LUmatrix[prem[k], j] - LUmatrix[prem[k], i] * LUmatrix[prem[i], j];
                }
            }
            for (int i = 0; i < LUmatrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < LUmatrix.GetLength(0); j++)
                {
                    LUmatrix[prem[i], j] = -LUmatrix[prem[i], j];
                }

            }
            return LUmatrix;
        }
        /// <summary>
        /// Производит поиск и выбор главного элемента по столбцу
        /// </summary>
        /// <param name="k">Номер шага</param>
        /// <param name="matrix">Матрица А</param>
        /// <param name="prem">Дополнительный вектор</param>
        private static void ChangeColumns(int k, double[,] matrix, ref int[] prem)
        {
            int imax = 0;
            int buf = 0;
            imax = k;
            for (int i = k; i < matrix.GetLength(0); i++)
                if (Math.Abs(matrix[prem[i], k]) > Math.Abs(matrix[prem[i], k]))
                {
                    imax = i;
                }
            if (imax != k)
            {
                buf = prem[k];
                prem[k] = prem[imax];
                prem[imax] = buf;
            }
        }
        /// <summary>
        /// Возвращает детерминант выходной матрицы LU
        /// </summary>
        /// <param name="LUmatrix">LU матрица</param>
        /// <returns></returns>
        public static double Determ(double[,] LUmatrix, int[] prem)
        {
            double det = 1;
            for (int i = 0; i < LUmatrix.GetLength(0); i++)
            {
                for (int j = 0; j < LUmatrix.GetLength(1); j++)
                {
                    if (i == j)
                        det *= LUmatrix[ prem[i], j];
                }
            }
            return Math.Abs(det);
        }
        /// <summary>
        /// Вычисление вектора столбца W из матрицы L и вектора столбца B
        /// </summary>
        /// <param name="Lmatrix">Нижне-треугольная матрица</param>
        /// <param name="b">Вектор столбец</param>
        /// <returns></returns>
        public static double[] FindMatrixW(double[,] Lmatrix, double[] b, int[] prem)
        {
            int n = Lmatrix.GetLength(0);
            double[] w = new double[n];
            b.CopyTo(w, 0);
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < i; j++)
                    sum += Lmatrix[prem[i], j] * w[j];
                w[i] = (b[i] - sum) / Lmatrix[prem[i], i];
            }
            return w;
        }
        /// <summary>
        /// Вычисление вектора столбца Х из матрицы U и вектора столбца W
        /// </summary>
        /// <param name="Umatrix">Верхне-треугольная матрица</param>
        /// <param name="w">Вектор столбец</param>
        /// <returns></returns>
        public static double[] FindMatrixX(double[,] Umatrix, double[] w, int[] prem)
        {
            int n = Umatrix.GetLength(0);
            double[] x = new double[n];
            w.CopyTo(x, 0);
            for (int i = n - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = n - 1; j > i; j--)
                    sum += Umatrix[prem[i], j] * x[j];
                x[i] = (w[i] - sum) / Umatrix[prem[i], i];
            }
            return x;
        }
        /// <summary>
        /// Создание матрицы с заданным количеством столбцов и строк.
        /// </summary>
        /// <param name="rows">Количество строк</param>
        /// <param name="cols">Количество столбцов</param>
        /// <returns></returns>
        public static double[,] MatrixCreate(int rows, int cols)
        {
            // Создаем матрицу, полностью инициализированную
            // значениями 0.0. Проверка входных параметров опущена.
            double[,] result = new double[rows, cols];
            return result;
        }
        /// <summary>
        /// Произведение квадратной матрицы А на вектор стоблец B
        /// </summary>
        /// <param name="matrixA">Квадратная матрица</param>
        /// <param name="matrixB">Вектор столбец</param>
        /// <returns></returns>
        public static double[] MatrixProduct(double[,] matrixA, double[] matrixB)
        {
            int aRows = matrixA.GetLength(0); int aCols = matrixA.GetLength(0);
            int bRows = matrixB.Length;
            double[] result = new double[aRows];
            for (int i = 0; i < aRows; ++i) // каждая строка A
                for (int k = 0; k < aCols; ++k)
                    result[i] += matrixA[i, k] * matrixB[k];
            return result;
        }
        /// <summary>
        /// Произведение квадратной матрицы А на квадратную матрицу B
        /// </summary>
        /// <param name="matrixA">Квадратная матрица</param>
        /// <param name="matrixB">Вектор столбец</param>
        /// <returns></returns>
        public static double[,] MatrixProduct(double[,] matrixA, double[,] matrixB, int[] prem)
        {
            int aRows = matrixA.GetLength(0);
            int aCols = matrixA.GetLength(1);
            int bRows = matrixB.GetLength(0);
            int bCols = matrixB.GetLength(1);
            if (aCols != bRows)
                throw new Exception("Non-conformable matrices in MatrixProduct");
            double[,] result = new double[aRows, aRows];
            for (int i = 0; i < aRows; i++) // каждая строка A
                for (int j = 0; j < bCols; j++) // каждый столбец B
                    for (int k = 0; k < aCols; k++)
                        result[i, j] += matrixA[prem[i], k] * matrixB[prem[k], j];
            return result;
        }
        /// <summary>
        /// Делит входную матрицу на верхнюю и нижнюю треугольные
        /// </summary>
        /// <param name="LUmatrix">Входная матрица LU. Матрица U с единицами по диагонали</param>
        /// <param name="Lmatrix">Нижне-треугольная матрица</param>
        /// <param name="Umatrix">Верхне-треугольная матрица</param>
        public static void Division(double[,] LUmatrix, out double[,] Lmatrix, out double[,] Umatrix, int[] prem)
        {
            Lmatrix = new double[LUmatrix.GetLength(0), LUmatrix.GetLength(0)];
            Umatrix = new double[LUmatrix.GetLength(0), LUmatrix.GetLength(0)];
            for (int i = 0; i < LUmatrix.GetLength(0); i++)
                for (int j = 0; j < LUmatrix.GetLength(1); j++)
                {
                    if (i < j)
                    {
                        Umatrix[prem[i], j] = LUmatrix[prem[i], j];
                    }
                    else if (i > j)
                    {
                        Lmatrix[prem[i], j] = LUmatrix[prem[i], j];
                    }
                    else
                    {
                        Umatrix[prem[i], j] = LUmatrix[prem[i], j] / LUmatrix[prem[i], j];
                        Lmatrix[prem[i], j] = LUmatrix[prem[i], j];
                    }
                }
        }
        /// <summary>
        /// Клонирует входную матрицу. Возвращает ссылку на новую матрицу.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] MatrixDuplicate(double[,] matrix)
        {
            double[,] result = (double[,])matrix.Clone();
            return result;
        }
        /// <summary>
        /// Клонирует столбец входной матрицы по номеру.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[] MatrixDuplicate(double[,] matrix, int j)
        {
            double[] result = new double[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
                result[i] = matrix[i, j];
            return result;
        }
        /// <summary>
        /// Возвращает обратную матрицу
        /// </summary>
        /// <param name="Lmatrix"></param>
        /// <param name="Umatrix"></param>
        /// <param name="prem"></param>
        /// <returns></returns>
        public static double[,] Inversion(double[,] Lmatrix, double[,] Umatrix, double[,] Imatrix, int[] prem)
        {
            double[,] result = new double[Lmatrix.GetLength(0), Lmatrix.GetLength(0)];
            for (int j = 0; j < result.GetLength(0); j++)
            {
                double[] I = MatrixDuplicate(Imatrix, j);
                double[] x = FindMatrixX(Umatrix, FindMatrixW(Lmatrix, I, prem), prem);
                for (int i = 0; i < result.GetLength(0); i++)
                {
                    result[prem[i], j] = x[i];
                }
            }
            return result;
        }
        /// <summary>
        /// Поиск нормы в матрице
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static double FindMax(double[,] matrix)
        {
            double max = Math.Abs(matrix[0, 0]);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (Math.Abs(matrix[i, j]) > max)
                        max = Math.Abs(matrix[i, j]);
                }
            }
            return max;
        }
        /// <summary>
        /// Вычисление погрешности между начальным вектором X и получившимся вектором X  
        /// </summary>
        /// <param name="X"></param>
        /// <param name="XReady"></param>
        /// <returns></returns>
        public static double DeltaMax(double[] X, double[] XReady, int[] prem)
        {
            double max = Math.Abs(X[prem[0]] - XReady[0]);
            for (int i = 1; i < X.GetLength(0); i++)
            {
                if (Math.Abs(X[prem[i]] - XReady[i]) > max)
                    max = Math.Abs(X[prem[i]] - XReady[i]);
            }
            return max;
        }
        /// <summary>
        /// Вычисляет погрешность обратной матрицы. Принимает начальную матрицу, обратную матрицу, единичную матрицу и доп вектор
        /// </summary>
        /// <param name="Amatrix"></param>
        /// <param name="AImatrix"></param>
        /// <param name="Imatrix"></param>
        /// <param name="prem"></param>
        /// <returns></returns>
        public static double DeltaMax(double[,] Amatrix, double[,] AImatrix, double[,] Imatrix, int[] prem)
        {
            double[,] Iproduct = MatrixProduct(Amatrix, AImatrix, prem);
            double[,] IDelta = new double[Amatrix.GetLength(0), Amatrix.GetLength(0)];
            for (int i = 0; i < Amatrix.GetLength(0); i++)
            {
                for (int j = 0; j < Amatrix.GetLength(0); j++)
                {
                    IDelta[i, j] = Imatrix[i, j] - Iproduct[i, j];
                }
            }
            return FindMax(IDelta) / FindMax(Amatrix);
        }

        public static string ArrayToString(double[,] matrix)
        {
            string result = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    result += string.Format("{0,20:0.########}", matrix[i, j]) + "\t";
                    //    result += Math.Round(matrix[i, j], 3) + "\t";
                }
                result += "\r\n";
            }
            return result + "\r\n";
        }

        public static string ArrayToString(double[] vector)
        {
            string result = "";
            for (int i = 0; i < vector.GetLength(0); i++)
            {
                //result += string.Format("{0,10:0.###}", vector[i]) + "\t";
                result += vector[i] + "\t";
            }
            return result + "\r\n\r\n";
        }

        public static string ArrayToString(int[] vector)
        {
            string result = "";
            for (int i = 0; i < vector.GetLength(0); i++)
            {
                result += vector[i] + "\t";
            }
            return result + "\r\n\r\n";
        }

        public static string DoChislMethod(ref Data data)
        {
            string result = "Начальная матрица:\r\n" + Processing.ArrayToString(data.A);
            int[] q = data.Q;
            data.LU = Processing.LUrzl(data.A, ref q);
            result += "Получивщаяся матрица:\r\n" + Processing.ArrayToString(data.LU);
            data.Q = q;
            result += "Дополнительный вектор P:\r\n" + Processing.ArrayToString(data.Q);
            double[] b = Processing.MatrixProduct(data.A, data.X);
            data.B = b;
            double[,] l, u;
            Processing.Division(data.LU, out l, out u, data.Q);
            data.L = l;
            data.U = u;
            double[] w = Processing.FindMatrixW(l, b, data.Q);
            data.W = w;
            data.XReady = Processing.FindMatrixX(u, w, data.Q);
            result += "Начальный вектор B:\r\n" + Processing.ArrayToString(data.B);
            result += "Начальный вектор X:\r\n" + Processing.ArrayToString(data.X);
            result += " вектор W:\r\n" + Processing.ArrayToString(data.W);
            result += "Получившийся вектор X:\r\n" + Processing.ArrayToString(data.XReady);
            result += "Детерминант: " + Processing.Determ(data.LU, data.Q) + "\r\n";
            data.ErrorX = DeltaMax(data.X, data.XReady, data.Q);
            //  result += "Погрешность X: " + string.Format("{0,10:0.##E-0}", data.ErrorX) + "\r\n";
            result += "Погрешность X: " + data.ErrorX + "\r\n";
            data.AInver = Processing.Inversion(data.L, data.U, data.I, data.Q);
            result += "Получивщаяся обратная матрица:\r\n" + Processing.ArrayToString(data.AInver);
            data.ErrorI = DeltaMax(data.A, data.AInver, data.I, data.Q);
            result += "Погрешность для обратной матрицы: " + string.Format("{0,10:0.##E-0}", data.ErrorI) + "\r\n";
            return result;
        }
    }
}
