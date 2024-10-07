using UnityEngine;

public class InverseKinematicsPointer : MonoBehaviour
{
    [SerializeField, Range(0, 0.2f)] private float _velocity = 0.05f;

    private Sample3axisRobotController _robotController;
    Sample3axisRobotIK _sample3AxisRobotIK = new Sample3axisRobotIK();

    // Start is called before the first frame update
    void Start()
    {
        // Sample3axisRobotController���擾
        _robotController = GameObject.Find("Sample3axisRobot").GetComponent<Sample3axisRobotController>();

        if (_robotController == null)
        {
            Debug.LogError("Sample3axisRobotController�̎擾�Ɏ��s���܂���");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �L�[���͂ɂ��ʒu�̕ύX
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

        // �t�^���w�ɂ��p�x�̌v�Z
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var angles = _sample3AxisRobotIK.GetJointAngles(transform.position);
            _robotController.Axis1Angle = angles[0];
            _robotController.Axis2Angle = angles[1];
            _robotController.Axis3Angle = angles[2];
        }
    }
}
