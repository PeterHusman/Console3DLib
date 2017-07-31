using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console3dLib.CoreTypes
{
    class Matrix
    {
        public float[,] Values = new float[4, 4];
        public Matrix IdentityMatrix
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

        public float[] this[int m]
        {
            get
            {
                return new float[] { Values[m, 0], Values[m, 1], Values[m, 2], Values[m, 4] };
            }
            set
            {
                Values[m, 0] = value[0];
                Values[m, 1] = value[1];
                Values[m, 2] = value[2];
                Values[m, 3] = value[3];
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
            float[,] output = new float[array[0].Length,array.Length];
            for(int x =0; x< array[0].Length; x++)
            {
                for (int y = 0; y < array.Length; y++)
                {
                    output[x, y] = array[y][x];
                }
            }
            return output;
        }


        public static Matrix operator *(Matrix left, Vector4d right)
        {
            return new Matrix(new float[,]{
                { left[0,0]*right.X, left[0,1]*right.Y, left[0,2]*right.Z, left[0,3]*right.W },
                { left[1,0]*right.X, left[1,1]*right.Y, left[1,2]*right.Z, left[1,3]*right.W },
                { left[2,0]*right.X, left[2,1]*right.Y, left[2,2]*right.Z, left[2,3]*right.W },
                { left[3,0]*right.X, left[3,1]*right.Y, left[3,2]*right.Z, left[3,3]*right.W } });
        }

        public Matrix TranslationMatrix(Vector4d translation)
        {
            Matrix translationMatrix = IdentityMatrix;
            translationMatrix[0, 3] = translation.X;
            translationMatrix[1, 3] = translation.Y;
            translationMatrix[2, 3] = translation.Z;
            translationMatrix[3, 3] = translation.W;
            return translationMatrix;
        }

        public Matrix ScalarMatrix(Vector3d scale)
        {
            return new Matrix(nestedTo2D(new float[][] { scaleFloatArray(IdentityMatrix[0], scale.X), scaleFloatArray(IdentityMatrix[1], scale.Y), scaleFloatArray(IdentityMatrix[2], scale.Z), IdentityMatrix[3] }));
        }

        public static Matrix operator *(Matrix left, Matrix right)
        {
            float[,] output = new float[right.Values.GetLength(0), left.Values.GetLength(1)];
            for(int x = 0; x < right.Values.GetLength(0); x++)
            {
                for(int y = 0; y < left.Values.GetLength(1); y++)
                {
                    float val = 0.0f;
                    for(int x2 = 0; x2 < right.Values.GetLength(0); x2++)
                    {
                        for (int y2 = 0; y2 < left.Values.GetLength(1); y2++)
                        {
                            val += left[x2, y2] * right[y2, x2];
                        }
                    }
                    output[x, y] = val;
                }
            }

            return new Matrix(output);
            
        }
    }
}
