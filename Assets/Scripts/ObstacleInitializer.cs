using UnityEngine;

public class ObstacleInitializer : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float radius = 1.0f;
    [SerializeField] private Vector3 center = new Vector3(0, 0, 0);

    // Obstacle prefab
    void Start()
    {
        // center の位置に半径 radius の円形に障害物を生成
        var ins = Instantiate(obstaclePrefab, center, Quaternion.identity);

        // 大きさを変更
        var scale = radius / 1.0f;
        ins.transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
