
/// <summary>
/// 3次式で間接角度軌道を生成する
/// </summary>
public class Sample3axisRobotPlanVelocity : ISample3axisRobotPlan
{
    private float[] _initialPosition;
    private float[] _finalPosition;
    private float _overallTime;

    private readonly float _initialVelocity = 0.0f;
    private readonly float _finalVelocity = 0.0f;

    public void SetInitialPosition(float[] axis)
    {
        _initialPosition = axis;
    }

    public void SetFinalPosition(float[] axis)
    {
        _finalPosition = axis;
    }

    public void SetOverallTime(float time)
    {
        _overallTime = time;
    }

    public float[] GetTrajectory(float time)
    {
        var trajectory = new float[3];

        for (var i = 0; i < 3; i++)
        {
            var a0 = _initialPosition[i];
            var a1 = _initialVelocity;
            var a2 = 3 * (_finalPosition[i] - _initialPosition[i]) / (_overallTime * _overallTime) - 2 * _initialVelocity / _overallTime - _finalVelocity / _overallTime;
            var a3 = -2 * (_finalPosition[i] - _initialPosition[i]) / (_overallTime * _overallTime * _overallTime) + (_initialVelocity + _finalVelocity) / (_overallTime * _overallTime);

            trajectory[i] = a0 + a1 * time + a2 * time * time + a3 * time * time * time;
        }

        return trajectory;
    }
}
