using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioClip buttonSound;
    public AudioClip sadSound;
    public AudioClip happySound;
    public AudioClip buildSound;
    public AudioClip errorSound;

    public List<AudioClip> musicClips;

    public AudioSource gameAudio;

    public GameObject gameStart;
    public GameObject gameUI;
    public GameObject buildingUI;
    public GameObject animal;
    public GameObject buildingManager;
    public GameObject gameOverUI;

    private Animal animalScript;

    // Start is called before the first frame update
    void Start()
    {
        gameAudio = GetComponent<AudioSource>();
        gameAudio.PlayOneShot(musicClips[0], 0.7f);
    }

    public void StartGame()
    {
        gameAudio.PlayOneShot(buttonSound, 1.0f);
        gameStart.gameObject.SetActive(false);

        // set needed objects to active
        gameUI.gameObject.SetActive(true);
        buildingUI.gameObject.SetActive(true);
        animal.gameObject.SetActive(true);
        buildingManager.gameObject.SetActive(true);
        animalScript = animal.GetComponent<Animal>();

        // switch game music
        gameAudio.Stop();
        gameAudio.PlayOneShot(musicClips[1], 0.4f);
    }

    public void GameOver()
    {
        gameUI.gameObject.SetActive(false);
        buildingUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);

        if (animalScript.gameWon)
        {
            gameOverUI.GetComponentInChildren<TextMeshProUGUI>().text = "Play Again?";
        } else if ( animalScript.gameLost)
        {
            gameOverUI.GetComponentInChildren<TextMeshProUGUI>().text = "Game Over";
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
