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
    // Start is called before the first frame update
    void Start()
    {
        vfx.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Scene(){
        StartCoroutine(PressButton());
    }

    private IEnumerator PressButton()
    {
        Effect();
        yield return new WaitForSeconds(6);
        StartCoroutine(SceneLoader());
    }
    public void Effect()
    {
        sound.Play();
        vfx.Play();
        //VFX Fade
        Debug.Log("Effect!");
    }
    public IEnumerator SceneLoader()
    {
        StartCoroutine(FadeOutSound());
        vfx.Stop();
        yield return new WaitForSeconds(1);
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
}
