using UnityEngine;

public class InverseKinematicsPointer : MonoBehaviour
{
    [SerializeField, Range(0, 0.2f)] private float _velocity = 0.05f;

    private Sample3axisRobotController _robotController;
    readonly Sample3axisRobotIK _sample3AxisRobotIK = new();
    uint ik_calc_mode = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Sample3axisRobotControllerを取得

        if (!GameObject.Find("Sample3axisRobot").TryGetComponent<Sample3axisRobotController>(out _robotController))
        {
            Debug.LogError("Sample3axisRobotControllerの取得に失敗しました");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // キー入力による位置の変更
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, _velocity);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -_velocity);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-_velocity, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(_velocity, 0, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += new Vector3(0, _velocity, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.position += new Vector3(0, -_velocity, 0);
        }

        // 逆運動学による角度の計算
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var angles = _sample3AxisRobotIK.GetJointAngles(transform.position, ik_calc_mode);
            _robotController.Axis1Angle = angles[0];
            _robotController.Axis2Angle = angles[1];
            _robotController.Axis3Angle = angles[2];
        }

        // 逆運動学の計算結果を変更
        if (Input.GetKeyDown(KeyCode.R))
        {
            ik_calc_mode++;

            var angles = _sample3AxisRobotIK.GetJointAngles(transform.position, ik_calc_mode);
            _robotController.Axis1Angle = angles[0];
            _robotController.Axis2Angle = angles[1];
            _robotController.Axis3Angle = angles[2];
        }
    }
}
