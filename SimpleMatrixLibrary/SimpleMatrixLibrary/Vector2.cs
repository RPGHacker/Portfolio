using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMatrixLibrary
{
    /// <summary>
    /// Vector2 class
    /// </summary>
    public struct Vector2
    {
        /// <summary>
        /// Zero vector
        /// </summary>
        public static Vector2 zeroVector
        {
            get
            {
                return new Vector2(0.0f, 0.0f);
            }
        }

        /// <summary>
        /// The vector's x component
        /// </summary>
        public float x;
        /// <summary>
        /// The vector's y component
        /// </summary>
        public float y;

         /// <summary>
        /// Multiplay this vector with another vector
        /// </summary>
        /// <param name="secondVector">Second vector</param>
        /// <returns>Returns multiplied vector</returns>
        public float Mult(Vector2 secondVector)
        {
            return ((this.x * secondVector.x) + (this.y * secondVector.y));
        }

        /// <summary>
        /// Multiplay a vector with another vector
        /// </summary>
        /// <param name="firstVector">First vector</param>
        /// <param name="secondVector">Second vector</param>
        /// <returns>Returns multiplied vector</returns>
        public static float Mult(Vector2 firstVector, Vector2 secondVector)
        {
            return ((firstVector.x * secondVector.x) + (firstVector.y * secondVector.y));
        }

        /// <summary>
        /// Multiplay a vector with another vector
        /// </summary>
        /// <param name="firstVector">First vector</param>
        /// <param name="secondVector">Second vector</param>
        /// <returns>Returns multiplied vector</returns>
        public static float operator *(Vector2 firstVector, Vector2 secondVector)
        {
            return ((firstVector.x * secondVector.x) + (firstVector.y * secondVector.y));
        }

        /// <summary>
        /// Multiply a Matrix3x3 to the vector (ignoring the third dimension of the matrix)
        /// </summary>
        /// <param name="matrix">The Matrix3x3 to multiply to the vector</param>
        /// <returns>Returns the multiplied vector</returns>
        public Vector2 Mult(Matrix3x3 matrix)
        {
            Vector2 newVector = new Vector2();

            newVector.x = ((matrix.m11 * this.x) + (matrix.m12 * this.y));
            newVector.y = ((matrix.m21 * this.x) + (matrix.m22 * this.y));

            return newVector;
        }

        /// <summary>
        /// Multiply a Matrix3x3 to a vector (ignoring the third dimension of the matrix)
        /// </summary>
        /// <param name="matrix">The Matrix3x3 to multiply to the vector</param>
        /// <returns>Returns the multiplied vector</returns>
        public static Vector2 Mult(Vector2 vector, Matrix3x3 matrix)
        {
            Vector2 newVector = new Vector2();

            newVector.x = ((matrix.m11 * vector.x) + (matrix.m12 * vector.y));
            newVector.y = ((matrix.m21 * vector.x) + (matrix.m22 * vector.y));

            return newVector;
        }

        /// <summary>
        /// Multiply a Matrix3x3 to a vector (ignoring the third dimension of the matrix)
        /// </summary>
        /// <param name="matrix">The Matrix3x3 to multiply to the vector</param>
        /// <returns>Returns the multiplied vector</returns>
        public static Vector2 operator *(Vector2 vector, Matrix3x3 matrix)
        {
            Vector2 newVector = new Vector2();

            newVector.x = ((matrix.m11 * vector.x) + (matrix.m12 * vector.y));
            newVector.y = ((matrix.m21 * vector.x) + (matrix.m22 * vector.y));

            return newVector;
        }

        /// <summary>
        /// Rotates the Vector2 clockwise by an angle given in radians
        /// </summary>
        /// <param name="angle">The angle in radians</param>
        /// <returns>Returns the rotated vector</returns>
        public Vector2 Rotate(float angle)
        {
            Vector2 newVector = new Vector2();

            Matrix3x3 rotationMatrix = Matrix3x3.RotateTransform(angle);
            newVector = Vector2.Mult(this, rotationMatrix);

            return newVector;
        }

        /// <summary>
        /// Rotates a Vector2 clockwise by an angle given in radians
        /// </summary>
        /// <param name="vector">The vector to rotate</param>
        /// <param name="angle">The angle in radians</param>
        /// <returns>Returns the rotated vector</returns>
        public static Vector2 Rotate(Vector2 vector, float angle)
        {
            Vector2 newVector = new Vector2();

            Matrix3x3 rotationMatrix = Matrix3x3.RotateTransform(angle);
            newVector = Vector2.Mult(vector, rotationMatrix);

            return newVector;
        }

        /// <summary>
        /// Shear the vector along X axis
        /// </summary>
        /// <param name="shear">Shearing value</param>
        /// <returns>Returns the sheared vector</returns>
        public Vector2 ShearX(float shear)
        {
            Vector2 newVector = new Vector2();

            Matrix3x3 rotationMatrix = Matrix3x3.ShearXTransform(shear);
            newVector = Vector2.Mult(this, rotationMatrix);

            return newVector;
        }

        /// <summary>
        /// Shear a vector along X axis
        /// </summary>
        /// <param name="vector">The vector to shear</param>
        /// <param name="shear">Shearing value</param>
        /// <returns>Returns the sheared vector</returns>
        public static Vector2 ShearX(Vector2 vector, float shear)
        {
            Vector2 newVector = new Vector2();

            Matrix3x3 rotationMatrix = Matrix3x3.ShearXTransform(shear);
            newVector = Vector2.Mult(vector, rotationMatrix);

            return newVector;
        }

        /// <summary>
        /// Shear the vector along Y axis
        /// </summary>
        /// <param name="shear">Shearing value</param>
        /// <returns>Returns the sheared vector</returns>
        public Vector2 ShearY(float shear)
        {
            Vector2 newVector = new Vector2();

            Matrix3x3 rotationMatrix = Matrix3x3.ShearYTransform(shear);
            newVector = Vector2.Mult(this, rotationMatrix);

            return newVector;
        }

        /// <summary>
        /// Shear a vector along Y axis
        /// </summary>
        /// <param name="vector">The vector to shear</param>
        /// <param name="shear">Shearing value</param>
        /// <returns>Returns the sheared vector</returns>
        public static Vector2 ShearY(Vector2 vector, float shear)
        {
            Vector2 newVector = new Vector2();

            Matrix3x3 rotationMatrix = Matrix3x3.ShearYTransform(shear);
            newVector = Vector2.Mult(vector, rotationMatrix);

            return newVector;
        }

        /// <summary>
        /// Return string representation of the vector
        /// </summary>
        /// <returns>Returns a string representation of the vector</returns>
        public override string ToString()
        {
            return "{x=" + this.x.ToString("0.000") + ", y=" + this.y.ToString("0.000") + "}";
        }

        /// <summary>
        /// Vector2 constructor
        /// </summary>
        /// <param name="x">The vector's x component</param>
        /// <param name="y">The vector's y component</param>
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
