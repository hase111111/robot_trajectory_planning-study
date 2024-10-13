
using UnityEngine;

public class Sample3axisRobotIK
{
    readonly float link1Length = 2.0f;
    readonly float link2Length = 2.0f;
    readonly float link3Length = 2.0f;

    /// <summary>
    /// 逆運動学計算により、目標位置に対する各関節の角度を求める    
    /// </summary>
    /// <param name="target"> 手先位置 </param>
    /// <returns> 間接角度の配列 </returns>
    public float[] GetJointAngles(Vector3 target, uint calc_mode = 0)
    {
        var angles = new float[3];

        try
        {
            var theta1 = Mathf.Atan2(target.z, -target.x);

            if ((calc_mode & 0b01) != 0)
            {
                theta1 += Mathf.PI;
            }

            var x = target.y - link1Length;
            var y = Mathf.Sqrt(target.x * target.x + target.z * target.z);

            if ((calc_mode & 0b01) != 0)
            {
                y = -y;
            }
            var theta2_1 = Mathf.Acos((link2Length * link2Length + x * x + y * y - link3Length * link3Length) / (2 * link2Length * Mathf.Sqrt(x * x + y * y)));
            var theta2_2 = Mathf.Atan2(y, x);
            var theta2 = ((calc_mode & 0b10) != 0) ? theta2_2 - theta2_1 : theta2_2 + theta2_1;
            var theta3 = Mathf.Atan2(y - link2Length * Mathf.Sin(theta2), x - link2Length * Mathf.Cos(theta2)) - theta2;

            angles[0] = theta1 * Mathf.Rad2Deg;
            angles[1] = theta2 * Mathf.Rad2Deg;
            angles[2] = theta3 * Mathf.Rad2Deg;
        }
        catch (System.Exception e)
        {
            angles[0] = 0;
            angles[1] = 0;
            angles[2] = 0;

            Debug.Log("Error: " + e.Message);
        }

        // もし NaN が含まれていた場合は、0 に置き換える
        if (float.IsNaN(angles[0]) || float.IsNaN(angles[1]) || float.IsNaN(angles[2]))
        {
            angles[0] = 0;
            angles[1] = 0;
            angles[2] = 0;

            Debug.Log("Error: NaN");
        }

        return angles;
    }
}
