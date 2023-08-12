using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public GameObject blackoutPlane; // 你的黑幕物體
    public float fadeDuration = 2.0f; // 漸進時間（秒）

    private Material blackoutMaterial;
    private Color initialColor;
    // Start is called before the first frame update
    void Awake()
    {
        blackoutMaterial = blackoutPlane.GetComponent<Renderer>().material;
        initialColor = blackoutMaterial.color;
        initialColor.a = 1.0f; // 初始透明度為 0
        blackoutMaterial.color = initialColor;
    }
    void Start() 
    {
        StartCoroutine(FadeToClear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator FadeToClear()
    {
        float elapsedTime = 0.0f;
        Color targetColor = initialColor;
        targetColor.a = 0.0f; // 目標透明度為 1

        while (elapsedTime < fadeDuration)
        {
            blackoutMaterial.color = Color.Lerp(initialColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        blackoutMaterial.color = targetColor; // 確保最終的顏色值正確
    }
}
