using UnityEngine;

public class ObstacleInitializer : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float radius = 1.0f;
    [SerializeField] private Vector3 center = new Vector3(0, 0, 0);

    // Obstacle prefab
    void Start()
    {
        // center �̈ʒu�ɔ��a radius �̉~�`�ɏ�Q���𐶐�
        var ins = Instantiate(obstaclePrefab, center, Quaternion.identity);

        // �傫����ύX
        var scale = radius / 1.0f;
        ins.transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
