
public class Sample3axisRobotPlanLiner : ISample3axisRobotPlan
{
    private float[] initialPosition;
    private float[] finalPosition;
    private float overallTime;

    public void SetInitialPosition(float[] axis)
    {
        initialPosition = axis;
    }

    public void SetFinalPosition(float[] axis)
    {
        finalPosition = axis;
    }

    public void SetOverallTime(float time)
    {
        overallTime = time;
    }

    public float[] GetTrajectory(float time)
    {
        float[] trajectory = new float[3];
        for (int i = 0; i < 3; i++)
        {
            trajectory[i] = initialPosition[i] + (finalPosition[i] - initialPosition[i]) * time / overallTime;
        }
        return trajectory;
    }
}
