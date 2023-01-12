using System;

namespace Vector
{
    public class Vector : IEquatable<Vector>
    {
        private const string VectorInfo = "Vector = ";

        private readonly int _coordinateX;
        private readonly int _coordinateY;
        private readonly int _coordinateZ;

        public Vector(int coordinateX, int coordinateY, int coordinateZ)
        {
            _coordinateX = coordinateX;
            _coordinateY = coordinateY;
            _coordinateZ = coordinateZ;
        }

        public int X => _coordinateX;
        public int Y => _coordinateY;
        public int Z => _coordinateZ;

        public override string ToString() => $"{VectorInfo}({X}, {Y}, {Z})";

        public static Vector operator +(Vector firstVector, Vector secondVector)
        {
            CheckVectorsIsNull(firstVector, secondVector);

            return new Vector(firstVector.X + secondVector.X,
                firstVector.Y + secondVector.Y,
                firstVector.Z + secondVector.Z);
        }

        private static void CheckVectorsIsNull(Vector firstVector, Vector secondVector)
        {
            if (firstVector is null)
            {
                throw new ArgumentNullException(nameof(firstVector));
            }

            if (secondVector is null)
            {
                throw new ArgumentNullException(nameof(secondVector));
            }
        }
        public static Vector operator -(Vector firstVector, Vector secondVector)
        {
            CheckVectorsIsNull(firstVector, secondVector);

            return new Vector(firstVector.X - secondVector.X,
                firstVector.Y - secondVector.Y,
                firstVector.Z - secondVector.Z);
        }

        public static int operator *(Vector firstVector, Vector secondVector)
        {
            CheckVectorsIsNull(firstVector, secondVector);

            return firstVector.X * secondVector.X +
                firstVector.Y * secondVector.Y + firstVector.Z * secondVector.Z;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Vector)) return false;

            return Equals(obj as Vector);
        }

        public bool Equals(Vector vector)
        {
            if (ReferenceEquals(null, vector)) return false;
            if (ReferenceEquals(this, vector)) return true;

            return X == vector.X && Y == vector.Y && Z == vector.Z;
        }

        public override int GetHashCode() => HashCode.Combine(X, Y, Z);

        public static bool operator ==(Vector firstVector, Vector secondVector)
        {
            return Equals(firstVector, secondVector);
        }

        public static bool operator !=(Vector firstVector, Vector secondVector)
        {
            return !Equals(firstVector, secondVector);
        }
    }
}
