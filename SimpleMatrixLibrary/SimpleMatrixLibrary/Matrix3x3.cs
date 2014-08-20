using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMatrixLibrary
{
    /// <summary>
    /// 3x3 matrix class
    /// </summary>
    public class Matrix3x3
    {
        /// <summary>
        /// Row major matrix data
        /// </summary>
        public float[,] matrix = new float[3,3]
        {
            { 1.0f, 0.0f, 0.0f },
            { 0.0f, 1.0f, 0.0f },
            { 0.0f, 0.0f, 1.0f }
        };

        /// <summary>
        /// Value m11 of the matrix
        /// </summary>
        public float m11 { get { return this.matrix[0, 0]; } set { this.matrix[0, 0] = value; } }
        /// <summary>
        /// Value m12 of the matrix
        /// </summary>
        public float m12 { get { return this.matrix[0, 1]; } set { this.matrix[0, 1] = value; } }
        /// <summary>
        /// Value m13 of the matrix
        /// </summary>
        public float m13 { get { return this.matrix[0, 2]; } set { this.matrix[0, 2] = value; } }
        /// <summary>
        /// Value m21 of the matrix
        /// </summary>
        public float m21 { get { return this.matrix[1, 0]; } set { this.matrix[1, 0] = value; } }
        /// <summary>
        /// Value m22 of the matrix
        /// </summary>
        public float m22 { get { return this.matrix[1, 1]; } set { this.matrix[1, 1] = value; } }
        /// <summary>
        /// Value m23 of the matrix
        /// </summary>
        public float m23 { get { return this.matrix[1, 2]; } set { this.matrix[1, 2] = value; } }
        /// <summary>
        /// Value m31 of the matrix
        /// </summary>
        public float m31 { get { return this.matrix[2, 0]; } set { this.matrix[2, 0] = value; } }
        /// <summary>
        /// Value m32 of the matrix
        /// </summary>
        public float m32 { get { return this.matrix[2, 1]; } set { this.matrix[2, 1] = value; } }
        /// <summary>
        /// Value m33 of the matrix
        /// </summary>
        public float m33 { get { return this.matrix[2, 2]; } set { this.matrix[2, 2] = value; } }

        /// <summary>
        /// Multiply another matrix to this matrix
        /// </summary>
        /// <param name="secondMatrix">The second matrix</param>
        /// <returns>Returns the multiplied matrix</returns>
        public Matrix3x3 Mult(Matrix3x3 secondMatrix)
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m11 = ((this.m11 * secondMatrix.m11) + (this.m12 * secondMatrix.m21) + (this.m13 * secondMatrix.m31));
            newMatrix.m12 = ((this.m11 * secondMatrix.m12) + (this.m12 * secondMatrix.m22) + (this.m13 * secondMatrix.m32));
            newMatrix.m13 = ((this.m11 * secondMatrix.m13) + (this.m12 * secondMatrix.m23) + (this.m13 * secondMatrix.m33));
            newMatrix.m21 = ((this.m21 * secondMatrix.m11) + (this.m22 * secondMatrix.m21) + (this.m23 * secondMatrix.m31));
            newMatrix.m22 = ((this.m21 * secondMatrix.m12) + (this.m22 * secondMatrix.m22) + (this.m23 * secondMatrix.m32));
            newMatrix.m23 = ((this.m21 * secondMatrix.m13) + (this.m22 * secondMatrix.m23) + (this.m23 * secondMatrix.m33));
            newMatrix.m31 = ((this.m31 * secondMatrix.m11) + (this.m32 * secondMatrix.m21) + (this.m33 * secondMatrix.m31));
            newMatrix.m32 = ((this.m31 * secondMatrix.m12) + (this.m32 * secondMatrix.m22) + (this.m33 * secondMatrix.m32));
            newMatrix.m33 = ((this.m31 * secondMatrix.m13) + (this.m32 * secondMatrix.m23) + (this.m33 * secondMatrix.m33));

            return newMatrix;
        }

        /// <summary>
        /// Multiply two matrices
        /// </summary>
        /// <param name="firstMatrix">The first matrix</param>
        /// <param name="secondMatrix">The second matrix</param>
        /// <returns>Returns the multiplied matrix</returns>
        public static Matrix3x3 Mult(Matrix3x3 firstMatrix, Matrix3x3 secondMatrix)
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m11 = ((firstMatrix.m11 * secondMatrix.m11) + (firstMatrix.m12 * secondMatrix.m21) + (firstMatrix.m13 * secondMatrix.m31));
            newMatrix.m12 = ((firstMatrix.m11 * secondMatrix.m12) + (firstMatrix.m12 * secondMatrix.m22) + (firstMatrix.m13 * secondMatrix.m32));
            newMatrix.m13 = ((firstMatrix.m11 * secondMatrix.m13) + (firstMatrix.m12 * secondMatrix.m23) + (firstMatrix.m13 * secondMatrix.m33));
            newMatrix.m21 = ((firstMatrix.m21 * secondMatrix.m11) + (firstMatrix.m22 * secondMatrix.m21) + (firstMatrix.m23 * secondMatrix.m31));
            newMatrix.m22 = ((firstMatrix.m21 * secondMatrix.m12) + (firstMatrix.m22 * secondMatrix.m22) + (firstMatrix.m23 * secondMatrix.m32));
            newMatrix.m23 = ((firstMatrix.m21 * secondMatrix.m13) + (firstMatrix.m22 * secondMatrix.m23) + (firstMatrix.m23 * secondMatrix.m33));
            newMatrix.m31 = ((firstMatrix.m31 * secondMatrix.m11) + (firstMatrix.m32 * secondMatrix.m21) + (firstMatrix.m33 * secondMatrix.m31));
            newMatrix.m32 = ((firstMatrix.m31 * secondMatrix.m12) + (firstMatrix.m32 * secondMatrix.m22) + (firstMatrix.m33 * secondMatrix.m32));
            newMatrix.m33 = ((firstMatrix.m31 * secondMatrix.m13) + (firstMatrix.m32 * secondMatrix.m23) + (firstMatrix.m33 * secondMatrix.m33));

            return newMatrix;
        }

        /// <summary>
        /// Multiply two matrices
        /// </summary>
        /// <param name="firstMatrix">The first matrix</param>
        /// <param name="secondMatrix">The second matrix</param>
        /// <returns>Returns the multiplied matrix</returns>
        public static Matrix3x3 operator *(Matrix3x3 firstMatrix, Matrix3x3 secondMatrix)
        {
            return Matrix3x3.Mult(firstMatrix, secondMatrix);
        }

        /// <summary>
        /// Divide a matrix by another matrix (using its inverse)
        /// </summary>
        /// <param name="firstMatrix">The first matrix</param>
        /// <param name="secondMatrix">The second matrix</param>
        /// <returns>Returns the divided matrix</returns>
        public static Matrix3x3 operator /(Matrix3x3 firstMatrix, Matrix3x3 secondMatrix)
        {
            return Matrix3x3.Mult(firstMatrix, secondMatrix.Inverse());
        }

        /// <summary>
        /// Multiply a float with the matrix
        /// </summary>
        /// <param name="value">The float to multiply to the matrix</param>
        /// <returns>Returns the multiplied matrix</returns>
        public Matrix3x3 Mult(float value)
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m11 = this.m11 * value;
            newMatrix.m12 = this.m12 * value;
            newMatrix.m13 = this.m13 * value;
            newMatrix.m21 = this.m21 * value;
            newMatrix.m22 = this.m22 * value;
            newMatrix.m23 = this.m23 * value;
            newMatrix.m31 = this.m31 * value;
            newMatrix.m32 = this.m32 * value;
            newMatrix.m33 = this.m33 * value;

            return newMatrix;
        }

        /// <summary>
        /// Multiply a float with a matrix
        /// </summary>
        /// <param name="matrix">The matrix to multiplay the float to</param>
        /// <param name="value">The float to multiply to the matrix</param>
        /// <returns>Returns the multiplied matrix</returns>
        public static Matrix3x3 Mult(Matrix3x3 matrix, float value)
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m11 = matrix.m11 * value;
            newMatrix.m12 = matrix.m12 * value;
            newMatrix.m13 = matrix.m13 * value;
            newMatrix.m21 = matrix.m21 * value;
            newMatrix.m22 = matrix.m22 * value;
            newMatrix.m23 = matrix.m23 * value;
            newMatrix.m31 = matrix.m31 * value;
            newMatrix.m32 = matrix.m32 * value;
            newMatrix.m33 = matrix.m33 * value;

            return newMatrix;
        }

        /// <summary>
        /// Multiply a float with a matrix
        /// </summary>
        /// <param name="matrix">The matrix to multiplay the float to</param>
        /// <param name="value">The float to multiply to the matrix</param>
        /// <returns>Returns the multiplied matrix</returns>
        public static Matrix3x3 operator *(Matrix3x3 matrix, float value)
        {
            return Matrix3x3.Mult(matrix, value);
        }

        /// <summary>
        /// Divide a matrix by a float
        /// </summary>
        /// <param name="matrix">The matrix to divide by the float</param>
        /// <param name="value">The float to divide the matrix by</param>
        /// <returns>Returns the divided matrix</returns>
        public static Matrix3x3 operator /(Matrix3x3 matrix, float value)
        {
            return Matrix3x3.Mult(matrix, 1.0f/value);
        }

        /// <summary>
        /// Calculate the determinant of the matrix
        /// </summary>
        /// <returns>Returns the determinant</returns>
        public float Determinant()
        {
            return
                + (this.m11 * this.m22 * this.m33)
                + (this.m12 * this.m23 * this.m31)
                + (this.m13 * this.m21 * this.m32)
                - (this.m13 * this.m22 * this.m31)
                - (this.m12 * this.m21 * this.m33)
                - (this.m11 * this.m23 * this.m32);
        }

        /// <summary>
        /// Calculate the determinant of a matrix
        /// </summary>
        /// <param name="matrix">Matrix to calculate determinant of</param>
        /// <returns>Returns the determinant</returns>
        public static float Determinant(Matrix3x3 matrix)
        {
            return
                + (matrix.m11 * matrix.m22 * matrix.m33)
                + (matrix.m12 * matrix.m23 * matrix.m31)
                + (matrix.m13 * matrix.m21 * matrix.m32)
                - (matrix.m13 * matrix.m22 * matrix.m31)
                - (matrix.m12 * matrix.m21 * matrix.m33)
                - (matrix.m11 * matrix.m23 * matrix.m32);
        }

        /// <summary>
        /// Calculate the coefficient of the matrix
        /// </summary>
        /// <returns>Returns the coefficient</returns>
        public Matrix3x3 Coefficient()
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m11 = + ((this.m22 * this.m33) - (this.m23 * this.m32));
            newMatrix.m12 = - ((this.m21 * this.m33) - (this.m23 * this.m31));
            newMatrix.m13 = + ((this.m21 * this.m32) - (this.m22 * this.m31));
            newMatrix.m21 = - ((this.m12 * this.m33) - (this.m13 * this.m32));
            newMatrix.m22 = + ((this.m11 * this.m33) - (this.m13 * this.m31));
            newMatrix.m23 = - ((this.m11 * this.m32) - (this.m12 * this.m31));
            newMatrix.m31 = + ((this.m12 * this.m23) - (this.m13 * this.m22));
            newMatrix.m32 = - ((this.m11 * this.m23) - (this.m13 * this.m21));
            newMatrix.m33 = + ((this.m11 * this.m22) - (this.m12 * this.m21));

            return newMatrix;
        }

        /// <summary>
        /// Calculate the coefficient of a matrix
        /// </summary>
        /// <param name="matrix">Matrix to calculate coefficient of</param>
        /// <returns>Returns the coefficient</returns>
        public static Matrix3x3 Coefficient(Matrix3x3 matrix)
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m11 = + ((matrix.m22 * matrix.m33) - (matrix.m23 * matrix.m32));
            newMatrix.m12 = - ((matrix.m21 * matrix.m33) - (matrix.m23 * matrix.m31));
            newMatrix.m13 = + ((matrix.m21 * matrix.m32) - (matrix.m22 * matrix.m31));
            newMatrix.m21 = - ((matrix.m12 * matrix.m33) - (matrix.m13 * matrix.m32));
            newMatrix.m22 = + ((matrix.m11 * matrix.m33) - (matrix.m13 * matrix.m31));
            newMatrix.m23 = - ((matrix.m11 * matrix.m32) - (matrix.m12 * matrix.m31));
            newMatrix.m31 = + ((matrix.m12 * matrix.m23) - (matrix.m13 * matrix.m22));
            newMatrix.m32 = - ((matrix.m11 * matrix.m23) - (matrix.m13 * matrix.m21));
            newMatrix.m33 = + ((matrix.m11 * matrix.m22) - (matrix.m12 * matrix.m21));

            return newMatrix;
        }

        /// <summary>
        /// Transpose the matrix
        /// </summary>
        /// <returns>Returns transposed matrix</returns>
        public Matrix3x3 Transpose()
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m11 = this.m11;
            newMatrix.m12 = this.m21;
            newMatrix.m13 = this.m31;
            newMatrix.m21 = this.m12;
            newMatrix.m22 = this.m22;
            newMatrix.m23 = this.m32;
            newMatrix.m31 = this.m13;
            newMatrix.m32 = this.m23;
            newMatrix.m33 = this.m33;

            return newMatrix;
        }

        /// <summary>
        /// Transpose a matrix
        /// </summary>
        /// <param name="matrix">Matrix to transpose</param>
        /// <returns>Returns transposed matrix</returns>
        public static Matrix3x3 Transpose(Matrix3x3 matrix)
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m11 = matrix.m11;
            newMatrix.m12 = matrix.m21;
            newMatrix.m13 = matrix.m31;
            newMatrix.m21 = matrix.m12;
            newMatrix.m22 = matrix.m22;
            newMatrix.m23 = matrix.m32;
            newMatrix.m31 = matrix.m13;
            newMatrix.m32 = matrix.m23;
            newMatrix.m33 = matrix.m33;

            return newMatrix;
        }

        /// <summary>
        /// Calculate the inverse of the matrix
        /// </summary>
        /// <returns>Returns inverse of matrix</returns>
        public Matrix3x3 Inverse()
        {
            float determinant = this.Determinant();

            Matrix3x3 newMatrix = this.Coefficient();
            newMatrix = newMatrix.Transpose();
            newMatrix = newMatrix / determinant;

            return newMatrix;
        }

        /// <summary>
        /// Calculate the inverse of a matrix
        /// </summary>
        /// <param name="matrix">Matrix to calculate inverse of</param>
        /// <returns>Returns inverse of matrix</returns>
        public static Matrix3x3 Inverse(Matrix3x3 matrix)
        {
            float determinant = matrix.Determinant();

            Matrix3x3 newMatrix = matrix.Coefficient();
            newMatrix = newMatrix.Transpose();
            newMatrix = newMatrix / determinant;

            return newMatrix;
        }

        /// <summary>
        /// Returns the view matrix for the given parameters
        /// </summary>
        /// <param name="right">The camera's right vector</param>
        /// <param name="up">The camera's up vector</param>
        /// <param name="position">The camera's position</param>
        /// <returns>View matrix</returns>
        public static Matrix3x3 ViewTransform(Vector2 right, Vector2 up, Vector2 position)
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m11 = right.x;
            newMatrix.m12 = right.y;
            newMatrix.m21 = up.x;
            newMatrix.m22 = up.y;
            newMatrix.m31 = -(right * position);
            newMatrix.m32 = -(up * position);

            return newMatrix;
        }

        /// <summary>
        /// Returns the rotation matrix of a clockwise rotation by an angle given in radians
        /// </summary>
        /// <param name="angle">The angle in radians</param>
        /// <returns>Returns the rotation matrix</returns>
        public static Matrix3x3 RotateTransform(float angle)
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m11 = (float)(Math.Cos(angle));
            newMatrix.m12 = (float)(Math.Sin(angle));
            newMatrix.m21 = (float)(-Math.Sin(angle));
            newMatrix.m22 = (float)(Math.Cos(angle));

            return newMatrix;
        }

        /// <summary>
        /// Returns transformation matrix for shearing along X axis
        /// </summary>
        /// <param name="shear">Shearing value</param>
        /// <returns>Returns transformation matrix for shearing along X axis</returns>
        public static Matrix3x3 ShearXTransform(float shear)
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m12 = shear;

            return newMatrix;
        }

        /// <summary>
        /// Returns transformation matrix for shearing along Y axis
        /// </summary>
        /// <param name="shear">Shearing value</param>
        /// <returns>Returns transformation matrix for shearing along Y axis</returns>
        public static Matrix3x3 ShearYTransform(float shear)
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m21 = shear;

            return newMatrix;
        }

        /// <summary>
        /// Returns a translation matrix for the given vector
        /// </summary>
        /// <param name="translation">Translation vector</param>
        /// <returns>Returns translated matrix</returns>
        public static Matrix3x3 TranslateTransform(Vector2 translation)
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m31 = translation.x;
            newMatrix.m32 = translation.y;

            return newMatrix;
        }

        /// <summary>
        /// Returns a scale matrix for the given vector
        /// </summary>
        /// <param name="translation">Scale vector</param>
        /// <returns>Returns scale matrix</returns>
        public static Matrix3x3 ScaleTransform(Vector2 scale)
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m11 = scale.x;
            newMatrix.m22 = scale.y;

            return newMatrix;
        }

        /// <summary>
        /// Returns a world matrix for the given vectors
        /// </summary>
        /// <param name="right">The right vector</param>
        /// <param name="up">The up vector</param>
        /// <param name="position">The position vector</param>
        /// <returns></returns>
        public static Matrix3x3 WorldTransform(Vector2 right, Vector2 up, Vector2 position)
        {
            Matrix3x3 newMatrix = new Matrix3x3();

            newMatrix.m11 = right.x;
            newMatrix.m12 = right.y;
            newMatrix.m21 = up.x;
            newMatrix.m22 = up.y;
            newMatrix.m31 = position.x;
            newMatrix.m32 = position.y;

            return newMatrix;
        }

        /// <summary>
        /// Return string representation of the matrix
        /// </summary>
        /// <returns>Returns a string representation of the matrix</returns>
        public override string ToString()
        {
            return "{m11=" + this.m11.ToString("0.000") + ", m12=" + this.m12.ToString("0.000") + ", m13=" + this.m13.ToString("0.000") + "}\n{m21=" + this.m21.ToString("0.000") + ", m22=" + this.m22.ToString("0.000") + ", m23=" + this.m23.ToString("0.000") + "}\n{m31=" + this.m31.ToString("0.000") + ", m32=" + this.m32.ToString("0.000") + ", m33=" + this.m33.ToString("0.000") + "}";
        }

        /// <summary>
        /// Matrix3x3 constructor (identity matrix)
        /// </summary>
        public Matrix3x3()
        {
        }

        /// <summary>
        /// Matrix3x3 constructor
        /// </summary>
        /// <param name="m11">Value m11 of the matrix</param>
        /// <param name="m12">Value m12 of the matrix</param>
        /// <param name="m13">Value m13 of the matrix</param>
        /// <param name="m21">Value m21 of the matrix</param>
        /// <param name="m22">Value m22 of the matrix</param>
        /// <param name="m23">Value m23 of the matrix</param>
        /// <param name="m31">Value m31 of the matrix</param>
        /// <param name="m32">Value m32 of the matrix</param>
        /// <param name="m33">Value m33 of the matrix</param>
        public Matrix3x3(float m11, float m12, float m13, float m21, float m22, float m23, float m31, float m32, float m33)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m21 = m21;
            this.m22 = m22;
            this.m23 = m23;
            this.m31 = m31;
            this.m32 = m32;
            this.m33 = m33;
        }
    }
}
