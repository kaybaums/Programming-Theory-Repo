using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleUI : MonoBehaviour
{
    public AudioClip buttonSound;
    public AudioSource gameAudio;

    public bool isGameActive = true;

    private void Start()
    {
        gameAudio = GetComponent<AudioSource>();
    }

    public void LoadDesert()
    {
        gameAudio.PlayOneShot(buttonSound, 1.0f);
        isGameActive = false;
        SceneManager.LoadScene(1);
    }

    public void LoadForest()
    {
        gameAudio.PlayOneShot(buttonSound, 1.0f);
        isGameActive = false;
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        gameAudio.PlayOneShot(buttonSound, 1.0f);
        isGameActive = false;
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
