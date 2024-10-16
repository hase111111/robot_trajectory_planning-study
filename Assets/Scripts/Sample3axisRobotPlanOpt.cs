
/// <summary>
/// 最適化手法で間接角度軌道を生成する
/// </summary>
public class Sample3axisRobotPlanOpt : ISample3axisRobotPlan
{
    private float[] _initialPosition;
    private float[] _finalPosition;
    private float _overallTime;

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



        return trajectory;
    }
}
