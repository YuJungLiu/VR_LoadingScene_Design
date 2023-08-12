using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class vfxChangeAlpha : MonoBehaviour
{
    public float decreaseRate = 0.2f;
    public setLoading setLoadingScript;

    private VisualEffect ve;

    // Start is called before the first frame update
    void Start()
    {
        ve = GetComponent<VisualEffect>();

        if (ve != null)
        {
            Debug.Log("Get Visual Effect!");

            //Color curColor = ve.GetVector4("Color");
            //Debug.Log(curColor);

            //float curAlpha = ve.GetFloat("Alpha");
            //Debug.Log(curAlpha);

            //float lifetime = ve.GetFloat("Lifetime");
            //Debug.Log(lifetime);

            //Debug.Log(Time.deltaTime);

        }
        else
        {
            Debug.LogError("No Visual Effect component found on the object.");
            enabled = false; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        float curAlpha = ve.GetFloat("Alpha");
        float newAlpha = Mathf.Max(curAlpha - (decreaseRate * Time.deltaTime), 0f);

        if(newAlpha == 0.0f)
        {
            newAlpha = 1.0f;
        }

        //ve.SetFloat("Alpha", newAlpha);


        // get loading counter from ./setLoading.cs
        float num = (float)getCounter();
        float alpha = Mathf.Max(0.0f, (100.0f - num) / 100.0f);

        Debug.Log(alpha);
        ve.SetFloat("Alpha", alpha);
    }

    public int getCounter()
    {
        int num = FindObjectOfType<setLoading>().passCounter();
        return num;
    }
}
