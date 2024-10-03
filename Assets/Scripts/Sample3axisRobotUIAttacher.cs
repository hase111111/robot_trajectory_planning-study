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
        // Sample3axisRobotControllerを取得
        _robotController = GameObject.Find("Sample3axisRobot").GetComponent<Sample3axisRobotController>();

        if (_robotController == null)
        {
            Debug.LogError("Sample3axisRobotControllerの取得に失敗しました");
            return;
        }

        // 各Sliderの値が変更されたときの処理を設定
        axis1Slider.onValueChanged.AddListener((float value) => _robotController.Axis1Angle = value);
        axis2Slider.onValueChanged.AddListener((float value) => _robotController.Axis2Angle = value);
        axis3Slider.onValueChanged.AddListener((float value) => _robotController.Axis3Angle = value);
    }

    // Update is called once per frame
    void Update()
    {
        // 各軸の角度を表示
        axis1Value.text = $"Axis1: {_robotController.Axis1Angle}°";
        axis2Value.text = $"Axis2: {_robotController.Axis2Angle}°";
        axis3Value.text = $"Axis3: {_robotController.Axis3Angle}°";
    }
}
