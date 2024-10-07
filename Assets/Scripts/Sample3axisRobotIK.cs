
using UnityEngine;

public class Sample3axisRobotIK
{
    readonly float link1Length = 2.0f;
    readonly float link2Length = 2.0f;
    readonly float link3Length = 2.0f;

    public float[] GetJointAngles(Vector3 target)
    {
        var angles = new float[3];

        var theta1 = Mathf.Atan2(target.z, -target.x);

        var x = target.y - link1Length;
        var y = Mathf.Sqrt(target.x * target.x + target.z * target.z);
        var theta2 = -Mathf.Acos((link2Length * link2Length + x * x + y * y - link3Length * link3Length) / (2 * link2Length * Mathf.Sqrt(x * x + y * y)))
            + Mathf.Atan2(y, x);
        var theta3 = Mathf.Atan2(y - link2Length * Mathf.Sin(theta2), x - link2Length * Mathf.Cos(theta2)) - theta2;

        angles[0] = theta1 * Mathf.Rad2Deg;
        angles[1] = theta2 * Mathf.Rad2Deg;
        angles[2] = theta3 * Mathf.Rad2Deg;

        return angles;
    }
}
