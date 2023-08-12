using UnityEngine;

public class CurvedMovement : MonoBehaviour
{
    public float minRadius = 5.0f;  // 弧面最小半徑
    public float maxRadius = 10.0f; // 弧面最大半徑
    public float maxDelta = 0.5f;   // 最大起伏幅度
    public float speed = 1.0f;      // 移動速度

    private float angleX = 0.0f;
    private float angleY = 0.0f;
    private float radius = 0.0f;
    private float currentDelta = 0.0f;

    private void Start()
    {
        radius = Random.Range(minRadius, maxRadius);
        currentDelta = Random.Range(-maxDelta, maxDelta);
    }

    private void Update()
    {
        // 更新角度
        angleX += speed * Time.deltaTime;
        angleY += speed * Time.deltaTime;

        // 計算球面座標
        float x = radius * Mathf.Sin(angleX) * Mathf.Cos(angleY);
        float y = radius * Mathf.Sin(angleX) * Mathf.Sin(angleY);

        // 計算限制後的z座標
        float maxZ = radius * Mathf.Cos(angleX);
        float z = Mathf.Clamp(maxZ + currentDelta, maxZ - maxDelta, maxZ + maxDelta);

        // 設置新位置
        transform.position = new Vector3(x, y, z);

        // 更新隨機的起伏幅度
        currentDelta = Random.Range(-maxDelta, maxDelta);
    }
}
