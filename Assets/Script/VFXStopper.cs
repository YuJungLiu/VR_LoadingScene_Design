using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXStopper : MonoBehaviour
{
    public GameObject Line;
    // Start is called before the first frame update
    void Awake()
    {
        Line.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Line.SetActive(true);
        }
    }
    public void Stopper()
    {
        Line.SetActive(true);
    }
}
