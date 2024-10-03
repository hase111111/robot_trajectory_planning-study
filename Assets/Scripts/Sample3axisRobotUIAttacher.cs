using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sample3axisRobotUIAttacher : MonoBehaviour
{
    [SerializeField] Slider axis1Slider;
    [SerializeField] Slider axis2Slider;
    [SerializeField] Slider axis3Slider;

    // TextMeshPro
    [SerializeField] TextMeshProUGUI axis1Value;
    [SerializeField] TextMeshProUGUI axis2Value;
    [SerializeField] TextMeshProUGUI axis3Value;

    Sample3axisRobotController _robotController;

    void Start()
    {
        // Sample3axisRobotController���擾
        _robotController = GameObject.Find("Sample3axisRobot").GetComponent<Sample3axisRobotController>();

        if (_robotController == null)
        {
            Debug.LogError("Sample3axisRobotController�̎擾�Ɏ��s���܂���");
            return;
        }

        // �eSlider�̒l���ύX���ꂽ�Ƃ��̏�����ݒ�
        axis1Slider.onValueChanged.AddListener((float value) => _robotController.Axis1Angle = value);
        axis2Slider.onValueChanged.AddListener((float value) => _robotController.Axis2Angle = value);
        axis3Slider.onValueChanged.AddListener((float value) => _robotController.Axis3Angle = value);
    }

    // Update is called once per frame
    void Update()
    {
        // �e���̊p�x��\��
        axis1Value.text = $"Axis1: {_robotController.Axis1Angle}��";
        axis2Value.text = $"Axis2: {_robotController.Axis2Angle}��";
        axis3Value.text = $"Axis3: {_robotController.Axis3Angle}��";
    }
}
