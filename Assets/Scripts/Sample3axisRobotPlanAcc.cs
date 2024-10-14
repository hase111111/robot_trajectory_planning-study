
/// <summary>
/// 5次式で間接角度軌道を生成する
/// </summary>
public class Sample3axisRobotPlanAcc : ISample3axisRobotPlan
{
    private float[] _initialPosition;
    private float[] _finalPosition;
    private float _overallTime;

    private readonly float _initialVelocity = 0.0f;
    private readonly float _finalVelocity = 0.0f;
    private readonly float _initialAcceleration = 0.0f;
    private readonly float _finalAcceleration = 0.0f;

    public void SetInitialPosition(float[] axis)
    {
        _initialPosition = axis;
    }

    public void SetFinalPosition(float[] axis)
    {
        _finalPosition = axis;

        // 360度以上の回転を避けるため，最短距離を計算
        for (int i = 0; i < 3; i++)
        {
            if (_finalPosition[i] - _initialPosition[i] > 180)
            {
                _finalPosition[i] -= 360;
            }
            else if (_finalPosition[i] - _initialPosition[i] < -180)
            {
                _finalPosition[i] += 360;
            }
        }
    }

    public void SetOverallTime(float time)
    {
        _overallTime = time;
    }

    public float[] GetTrajectory(float time)
    {
        float[] trajectory = new float[3];

        for (int i = 0; i < 3; i++)
        {
            float a0 = _initialPosition[i];
            float a1 = _initialVelocity;
            float a2 = _initialAcceleration / 2;
            float a3 = (20 * _finalPosition[i] - 20 * _initialPosition[i] - (8 * _finalVelocity + 12 * _initialVelocity) * _overallTime - (3 * _initialAcceleration - _finalAcceleration) * _overallTime * _overallTime) / (2 * _overallTime * _overallTime * _overallTime);
            float a4 = (30 * _initialPosition[i] - 30 * _finalPosition[i] + (14 * _finalVelocity + 16 * _initialVelocity) * _overallTime + (3 * _initialAcceleration - 2 * _finalAcceleration) * _overallTime * _overallTime) / (2 * _overallTime * _overallTime * _overallTime * _overallTime);
            float a5 = (12 * _finalPosition[i] - 12 * _initialPosition[i] - (6 * _finalVelocity + 6 * _initialVelocity) * _overallTime - (3 * _initialAcceleration - _finalAcceleration) * _overallTime * _overallTime) / (2 * _overallTime * _overallTime * _overallTime * _overallTime * _overallTime);

            trajectory[i] = a0 + a1 * time + a2 * time * time + a3 * time * time * time + a4 * time * time * time * time + a5 * time * time * time * time * time;
        }

        return trajectory;
    }
}
