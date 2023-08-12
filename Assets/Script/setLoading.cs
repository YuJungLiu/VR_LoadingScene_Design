using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class setLoading : MonoBehaviour
{
    //public Text counterText;
    public TMP_Text counterText;
    public int counter;

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<TMP_Text>();

        if (counterText == null)
        {
            Debug.LogError("No Text component found.");
            enabled = false; 
        }
        else
        {
            string initialText = counterText.text;
            Debug.Log("Initial Text: " + initialText);

        }

        StartCoroutine(increaseCount());
    }

    // Update is called once per frame
    void Update()
    {
        //int counter = int.Parse(counterText.text);
        //int decresse = Random.Range(1, 10);
        //counter -= decresse;

        //StartCoroutine(downCount());

        //if (counter <= 0)
        //{
        //    counterText.text = "0";
        //    enabled = false;
        //}
        //else
        //{
        //    counterText.text = counter.ToString();
        //}


    }

    public IEnumerator increaseCount()
    {
        counter = int.Parse(counterText.text);

        while (counter < 100)
        {
            int increase = Random.Range(1, 10);
            counter += increase;

            if (counter > 100)
            {
                counterText.text = "100";
                break;
            }
            counterText.text = counter.ToString();
            yield return new WaitForSeconds(0.5f);
        }

        counterText.text = "100";
        enabled = false;
        
    }

    // pass counter to vfxChangeAlpha.cs
    public int passCounter()
    { 
        return counter;
    }
}
