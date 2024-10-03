using UnityEngine;

public class Sample3axisRobotFK
{
    readonly float link1Length = 2.0f;
    readonly float link2Length = 2.0f;
    readonly float link3Length = 2.0f;

    public Vector3 GetEndEffectorPosition(float angle1, float angle2, float angle3)
    {
        var mat1to2 = MakeTransMatYAxis(angle1) * MakeTransMatYMove(link1Length);
        var mat2to3 = MakeTransMatZAxis(angle2) * MakeTransMatYMove(link2Length);
        var mat3to4 = MakeTransMatZAxis(angle3) * MakeTransMatYMove(link3Length);

        var mat1to4 = mat1to2 * mat2to3 * mat3to4;

        return mat1to4.GetColumn(3);
    }

    Matrix4x4 MakeTransMatYAxis(float angle)
    {
        var mat = Matrix4x4.identity;
        mat.m00 = Mathf.Cos(angle * Mathf.Deg2Rad);
        mat.m02 = Mathf.Sin(angle * Mathf.Deg2Rad);
        mat.m20 = -Mathf.Sin(angle * Mathf.Deg2Rad);
        mat.m22 = Mathf.Cos(angle * Mathf.Deg2Rad);
        return mat;
    }

    Matrix4x4 MakeTransMatZAxis(float angle)
    {
        var mat = Matrix4x4.identity;
        mat.m00 = Mathf.Cos(angle * Mathf.Deg2Rad);
        mat.m01 = -Mathf.Sin(angle * Mathf.Deg2Rad);
        mat.m10 = Mathf.Sin(angle * Mathf.Deg2Rad);
        mat.m11 = Mathf.Cos(angle * Mathf.Deg2Rad);
        return mat;
    }

    Matrix4x4 MakeTransMatYMove(float length)
    {
        var mat = Matrix4x4.identity;
        mat.m13 = length;
        return mat;
    }

}
