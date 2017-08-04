using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes
{
    class Matrix
    {
        public float[,] Values;
        public static Matrix IdentityMatrix
        {
            get
            {
                return new Matrix(new float[,] {
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 } });
            }
        }


        public int Rows
        {
            get
            {
                return Values.GetLength(0);
            }
        }

        public int Columns
        {
            get
            {
                return Values.GetLength(1);
            }
        }


        public float this[int m, int n]
        {
            get
            {
                return Values[m, n];
            }
            set
            {
                Values[m, n] = value;
            }
        }

        

        public Matrix(float[,] values)
        {
            Values = values;
        }

        private float[] scaleFloatArray(float[] array, float scalar)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] *= scalar;
            }
            return array;
        }

        private float[,] nestedTo2D(float[][] array)
        {
            float[,] output = new float[array[0].Length, array.Length];
            for (int x = 0; x < array[0].Length; x++)
            {
                for (int y = 0; y < array.Length; y++)
                {
                    output[x, y] = array[y][x];
                }
            }
            return output;
        }


        //public static Matrix operator *(Matrix left, Vector4 right)
        //{
        //    return new Matrix(new float[,]{
        //        { left[0,0]*right.X, left[0,1]*right.Y, left[0,2]*right.Z, left[0,3]*right.W },
        //        { left[1,0]*right.X, left[1,1]*right.Y, left[1,2]*right.Z, left[1,3]*right.W },
        //        { left[2,0]*right.X, left[2,1]*right.Y, left[2,2]*right.Z, left[2,3]*right.W },
        //        { left[3,0]*right.X, left[3,1]*right.Y, left[3,2]*right.Z, left[3,3]*right.W } });
        //}

        public static Matrix TranslationMatrix(Vector4 translation)
        {
            Matrix translationMatrix = IdentityMatrix;
            translationMatrix[0, 3] = translation.X;
            translationMatrix[1, 3] = translation.Y;
            translationMatrix[2, 3] = translation.Z;
            translationMatrix[3, 3] = translation.W;
            return translationMatrix;
        }

        public static Matrix ScalarMatrix(Vector4 scalar)
        {
            Matrix scalarMatrix = IdentityMatrix;
            scalarMatrix[0, 0] = scalar.X;
            scalarMatrix[1, 1] = scalar.Y;
            scalarMatrix[2, 2] = scalar.Z;
            scalarMatrix[3, 3] = scalar.W;
            return scalarMatrix;
        }

        public static Matrix FromVector4(Vector4 vector)
        {
            return new Matrix(new float[4, 1] {
            { vector.X },
            { vector.Y },
            { vector.Z },
            { vector.W } });
        }

        

        public static Matrix operator *(Matrix left, Matrix right)
        {
            float[,] output = new float[left.Rows, right.Columns];
            for (int c = 0; c < right.Columns; c++)
            {
                for (int r = 0; r < left.Rows; r++)
                {
                    output[r, c] = dot(getRowVector(left,r), getColVector(right, c));
                }
            }

            return new Matrix(output);

        }

        private static float[] getRowVector(Matrix a, int row)
        {
            float[] output = new float[a.Columns];

            for(int i = 0; i < a.Columns; i++)
            {
                output[i] = a[row,i];
            }

            return output;
        }

        private static float[] getColVector(Matrix a, int column)
        {
            float[] output = new float[a.Rows];

            for (int i = 0; i < a.Rows; i++)
            {
                output[i] = a[i, column];
            }

            return output;
        }


        private static float dot(float[] a, float[] b)
        {
            float dotProd = 0f;
            for(int i = 0; i < a.Length; i++)
            {
                dotProd += a[i] * b[i];
            }
            return dotProd;
        }
    }
}
