using UnityEngine;

namespace Assets.Scripts
{
    public class Sample3axisRobotPlanner : MonoBehaviour
    {
        private Sample3axisRobotController _robotController;
        readonly private float[] _startAxisAngle = new float[3];
        readonly private float[] _endAxisAngle = new float[3];
        readonly private ISample3axisRobotPlan _plan = new Sample3axisRobotPlanVelocity();
        private float _startTime = 0.0f;
        readonly private float _overallTime = 2.0f;

        enum PlanState
        {
            Start,
            End,
            Plan
        }

        private PlanState _planState = PlanState.Start;

        // Use this for initialization
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
            if (Input.GetKeyDown(KeyCode.T))
            {
                KeyBehavior();
            }

            if (_planState == PlanState.Plan)
            {
                float time = Time.time - _startTime;
                if (time > _overallTime)
                {
                    _startTime = Time.time;
                    time = _overallTime;
                }

                float[] trajectory = _plan.GetTrajectory(time);
                _robotController.Axis1Angle = trajectory[0];
                _robotController.Axis2Angle = trajectory[1];
                _robotController.Axis3Angle = trajectory[2];
            }
        }

        void KeyBehavior()
        {
            if (_planState == PlanState.Start)
            {
                // 開始位置の関節角度を取得
                _startAxisAngle[0] = _robotController.Axis1Angle;
                _startAxisAngle[1] = _robotController.Axis2Angle;
                _startAxisAngle[2] = _robotController.Axis3Angle;
                _planState = PlanState.End;
                Debug.Log("軌道の開始地点を設定しました，\n次に終了地点を設定してください");
            }
            else if (_planState == PlanState.End)
            {
                // 終了位置の関節角度を取得
                _endAxisAngle[0] = _robotController.Axis1Angle;
                _endAxisAngle[1] = _robotController.Axis2Angle;
                _endAxisAngle[2] = _robotController.Axis3Angle;
                _planState = PlanState.Plan;

                Debug.Log("軌道の終了地点を設定しました，\n次にTキーを押すと軌道に基づいて動作します．");

                _robotController.Axis1Angle = _startAxisAngle[0];
                _robotController.Axis2Angle = _startAxisAngle[1];
                _robotController.Axis3Angle = _startAxisAngle[2];

                // 軌道計画の初期化
                _plan.SetInitialPosition(_startAxisAngle);
                _plan.SetFinalPosition(_endAxisAngle);
                _plan.SetOverallTime(_overallTime);
                _startTime = Time.time;
            }
            else if (_planState == PlanState.Plan)
            {
                _planState = PlanState.Start;
                Debug.Log("軌道の計画をリセットしました．");
            }
        }
    }
}