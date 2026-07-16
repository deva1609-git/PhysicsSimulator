using UnityEngine;

[System.Serializable]
public struct Vector3d
{
    public double x, y, z;

    public static implicit operator Vector3d(Vector3 v)
    {
        return new Vector3d(v.x, v.y, v.z);
    }

    public Vector3d(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static Vector3d operator /(Vector3d a, double b)
    {
        return new Vector3d(
            a.x / b,
            a.y / b,
            a.z / b
        );
    }

    public static Vector3d operator *(Vector3d a, double b)
    {
        return new Vector3d(
            a.x * b,
            a.y * b,
            a.z * b
        );
    }

    public static Vector3d operator +(Vector3d a, Vector3d b)
    {
        return new Vector3d(
            a.x + b.x,
            a.y + b.y,
            a.z + b.z
        );
    }
    public static Vector3d operator -(Vector3d a)
    {
        return new Vector3d(
            -a.x, -a.y, -a.z
        );

    }

    public static Vector3d operator -(Vector3d a, Vector3d b)
    {
        return new Vector3d(
            a.x - b.x,
            a.y - b.y,
            a.z - b.z
        );

    }
    public static Vector3d Cross(Vector3d a, Vector3d b)
    {
        return new Vector3d(
            a.y * b.z - a.z * b.y,
            a.z * b.x - a.x * b.z,
            a.x * b.y - a.y * b.x
        );
    }

    public double Magnitude
    {
        get
        {
            return System.Math.Sqrt(x * x + y * y + z * z);
        }
    }
    public Vector3d Normalized
    {
        get
        {
            double mag = Magnitude;
            if (mag == 0)
            {
                return new Vector3d(0, 0, 0);
            }

            return this / mag;
        }
    }
    public Vector3 ToVector3()
    {
        return new Vector3(
            (float)x,
            (float)y,
            (float)z
        );
    }
    public static double Distance(Vector3d a, Vector3d b)
    {
        Vector3d bMinusA = b - a;
        double dist = bMinusA.Magnitude;

        return dist;
    }
    public static double DistanceVector3(Vector3 a, Vector3 b)
    {
        Vector3d bMinusA = new Vector3d(
                (double)(b.x - a.x),
                (double)(b.y - b.y),
                (double)(b.z - a.z)
            );
        double dist = bMinusA.Magnitude;
        return dist;
    }
}