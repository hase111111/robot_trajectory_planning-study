using UnityEngine;

public class ObstacleInitializer : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float radius = 1.0f;
    [SerializeField] private Vector3 center = new Vector3(0, 0, 0);

    // Obstacle prefab
    void Start()
    {
        // center ‚ÌˆÊ’u‚É”¼Œa radius ‚Ì‰~Œ`‚ÉáŠQ•¨‚ğ¶¬
        var ins = Instantiate(obstaclePrefab, center, Quaternion.identity);

        // ‘å‚«‚³‚ğ•ÏX
        var scale = radius / 1.0f;
        ins.transform.localScale = new Vector3(scale, scale, scale);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
