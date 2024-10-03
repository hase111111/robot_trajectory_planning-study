using TMPro;
using UnityEngine;

public class Sample3axisRobotDisplay : MonoBehaviour
{
    // TextMeshPro
    [SerializeField] TextMeshProUGUI joint1Value;
    [SerializeField] TextMeshProUGUI joint2Value;
    [SerializeField] TextMeshProUGUI joint3Value;
    [SerializeField] TextMeshProUGUI endEffectorValue;

    [SerializeField] TextMeshProUGUI forwardKinematics;

    Sample3axisRobotController _robotController;

    Sample3axisRobotFK _sample3AxisRobotFK = new Sample3axisRobotFK();

    // Start is called before the first frame update
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
        // 各軸の角度を表示
        joint1Value.text = $"Joint1: {_robotController.Joint1Position}, Posture: {_robotController.Joint1Posture}";
        joint2Value.text = $"Joint2: {_robotController.Joint2Position}, Posture: {_robotController.Joint2Posture}";
        joint3Value.text = $"Joint3: {_robotController.Joint3Position}, Posture: {_robotController.Joint3Posture}";
        endEffectorValue.text = $"EndEffector: {_robotController.EndEffectorPosition}, Posture: {_robotController.EndEffectorPosture}";

        // 順運動学の計算結果を表示
        var a1 = _robotController.Axis1Angle;
        var a2 = _robotController.Axis2Angle;
        var a3 = _robotController.Axis3Angle;

        forwardKinematics.text = $"Forward Kinematics: {_sample3AxisRobotFK.GetEndEffectorPosition(a1, a2, a3)}";

        // 順運動学の計算結果が等しいか
        if (_sample3AxisRobotFK.GetEndEffectorPosition(a1, a2, a3) == _robotController.EndEffectorPosition)
        {
            forwardKinematics.color = Color.green;
        }
        else
        {
            forwardKinematics.color = Color.red;
        }
    }
}
