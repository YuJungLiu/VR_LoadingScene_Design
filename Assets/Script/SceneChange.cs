using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class SceneChange : MonoBehaviour
{
    public GameObject Cube;
    public AudioSource sound;
    public VisualEffect vfx;
    public string sceneToLoad;
    public float fadeDuration = 2f;
    public int totalSecond = 0;

    public int counter = 0;

    // Start is called before the first frame update
    void Awake()
    {
        vfx.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(PressButton());
        }
    }
    public void Scene(){
        StartCoroutine(PressButton());
    }

    private IEnumerator PressButton()
    {
        Effect();
        //Cube.Tranform.Scale =
        Cube.SetActive(false);
        Debug.Log(totalSecond);
        yield return new WaitForSeconds(totalSecond);
        StartCoroutine(SceneLoader());
    }
    public void Effect()
    {
        sound.Play();
        vfx.Play();

        //VFX Fade
        StartCoroutine(increaseCount());
        
        //Debug.Log("Effect!");
    }
    public IEnumerator SceneLoader()
    {
        StartCoroutine(FadeOutSound());
        vfx.Stop();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneToLoad);
    }
    private IEnumerator FadeOutSound()
    {
        float startVolume = sound.volume;

        while (sound.volume > 0)
        {
            sound.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }
        sound.volume = 0;
        sound.Stop();
    }


    // counter
    public IEnumerator increaseCount()
    {
        //int counter = 0;
        totalSecond = Random.Range(8, 12);  // 8
        float iterNum = totalSecond / 0.5f;
        int increase = 100/(int)iterNum;

        for(int i=0; i<iterNum; i++)
        {
            counter += increase; 
            yield return new WaitForSeconds(0.5f);
        }

        if(counter <= 100)
        {
            counter = 100;
        }

        //while (counter < 100)
        //{
        //    // int increase = Random.Range(1, 10);
        //    counter += increase;
            
        //    if (counter > 100)
        //    {
        //        counter = 100;
        //        break;
        //    }
            
        //    yield return new WaitForSeconds(0.5f);
        //}
    }

    // pass counter to vfxChangeAlpha.cs
    public int passCounter()
    {
        //Debug.Log(counter);
        return counter;
    }
}
