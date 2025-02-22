using UnityEngine;

public class Sample3axisRobotFKDebug : MonoBehaviour
{
    Sample3axisRobotController _robotController;

    Sample3axisRobotFK _sample3AxisRobotFK = new Sample3axisRobotFK();


    void Start()
    {
        // Sample3axisRobotControllerを取得
        _robotController = GameObject.Find("Sample3axisRobot").GetComponent<Sample3axisRobotController>();

        if (_robotController == null)
        {
            Debug.LogError("Sample3axisRobotControllerの取得に失敗しました");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var a1 = _robotController.Axis1Angle;
        var a2 = _robotController.Axis2Angle;
        var a3 = _robotController.Axis3Angle;

        // 自身の位置を変更
        transform.position = _sample3AxisRobotFK.GetEndEffectorPosition(a1, a2, a3);
    }
}
