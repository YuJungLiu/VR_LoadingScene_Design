using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public GameObject blackoutPlane; // �A���¹�����
    public float fadeDuration = 2.0f; // ���i�ɶ��]��^

    private Material blackoutMaterial;
    private Color initialColor;
    // Start is called before the first frame update
    void Awake()
    {
        blackoutMaterial = blackoutPlane.GetComponent<Renderer>().material;
        initialColor = blackoutMaterial.color;
        initialColor.a = 1.0f; // ��l�z���׬� 0
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
        targetColor.a = 0.0f; // �ؼгz���׬� 1

        while (elapsedTime < fadeDuration)
        {
            blackoutMaterial.color = Color.Lerp(initialColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        blackoutMaterial.color = targetColor; // �T�O�̲ת��C��ȥ��T
    }
}
