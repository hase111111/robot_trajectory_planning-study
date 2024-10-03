using UnityEngine;

public class Sample3axisRobotFKDebug : MonoBehaviour
{
    Sample3axisRobotController _robotController;

    Sample3axisRobotFK _sample3AxisRobotFK = new Sample3axisRobotFK();


    void Start()
    {
        // Sample3axisRobotController‚ğæ“¾
        _robotController = GameObject.Find("Sample3axisRobot").GetComponent<Sample3axisRobotController>();

        if (_robotController == null)
        {
            Debug.LogError("Sample3axisRobotController‚Ìæ“¾‚É¸”s‚µ‚Ü‚µ‚½");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var a1 = _robotController.Axis1Angle;
        var a2 = _robotController.Axis2Angle;
        var a3 = _robotController.Axis3Angle;

        // ©g‚ÌˆÊ’u‚ğ•ÏX
        transform.position = _sample3AxisRobotFK.GetEndEffectorPosition(a1, a2, a3);
    }
}
