using UnityEngine;

public class Sample3axisRobotController : MonoBehaviour
{
    private GameObject axis1;
    private GameObject axis2;
    private GameObject axis3;
    private GameObject axis4;

    public float Axis1Angle
    {
        get { return ClampAngle(axis1.transform.rotation.eulerAngles.y); }
        set { axis1.transform.localRotation = Quaternion.AngleAxis(value, Vector3.up); }
    }

    public float Axis2Angle
    {
        get { return ClampAngle(axis2.transform.rotation.eulerAngles.z); }
        set { axis2.transform.localRotation = Quaternion.AngleAxis(value, Vector3.forward); }
    }

    public float Axis3Angle
    {
        get { return ClampAngle(axis3.transform.rotation.eulerAngles.z - axis2.transform.rotation.eulerAngles.z); }
        set { axis3.transform.localRotation = Quaternion.AngleAxis(value, Vector3.forward); }
    }

    public Vector3 Joint1Position { get => axis1.transform.position; }
    public Vector3 Joint2Position { get => axis2.transform.position; }
    public Vector3 Joint3Position { get => axis3.transform.position; }

    public Vector3 Joint1Posture { get => axis1.transform.rotation.eulerAngles; }

    public Vector3 Joint2Posture { get => axis2.transform.rotation.eulerAngles; }

    public Vector3 Joint3Posture { get => axis3.transform.rotation.eulerAngles; }

    public Vector3 EndEffectorPosition { get => axis4.transform.position; }

    public Vector3 EndEffectorPosture { get => axis4.transform.rotation.eulerAngles; }


    // Start is called before the first frame update
    void Start()
    {
        // �N�����Ƀ��b�Z�[�W��\��
        Debug.Log("3�����{�b�g�̐���X�N���v�g���A�^�b�`����܂���");

        // �e����GameObject���擾
        axis1 = GameObject.Find("Axis1");
        axis2 = GameObject.Find("Axis2");
        axis3 = GameObject.Find("Axis3");
        axis4 = GameObject.Find("Axis4");

        // �e����GameObject���A�^�b�`����Ă��邩�m�F
        if (axis1 == null || axis2 == null || axis3 == null)
        {
            Debug.LogError("Axis�̃A�^�b�`�Ɏ��s���܂���");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SampleRobotMove()
    {
        var axis1_rot = UnityEngine.Quaternion.Euler(0, Mathf.Sin(Time.time) * 45, 0);
        var axis2_rot = axis1_rot * UnityEngine.Quaternion.Euler(0, 0, Mathf.Sin(Time.time) * 45);
        var axis3_rot = axis2_rot * UnityEngine.Quaternion.Euler(0, 0, Mathf.Sin(Time.time) * 45);

        axis1.transform.SetLocalPositionAndRotation(
            axis1.transform.position, axis1_rot);

        axis2.transform.SetLocalPositionAndRotation(
            axis2.transform.position, axis2_rot);

        axis3.transform.SetLocalPositionAndRotation(
            axis3.transform.position, axis3_rot);
    }

    float ClampAngle(float angle)
    {
        if (angle > 180)
        {
            return angle - 360;
        }
        else if (angle < -180)
        {
            return angle + 360;
        }
        return angle;
    }
}
