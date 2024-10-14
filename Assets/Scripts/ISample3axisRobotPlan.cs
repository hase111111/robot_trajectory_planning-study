
public interface ISample3axisRobotPlan
{
    void SetInitialPosition(float[] axis);

    void SetFinalPosition(float[] axis);

    void SetOverallTime(float time);

    float[] GetTrajectory(float time);
}
