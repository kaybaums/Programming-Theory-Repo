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

    public AudioSource gameAudio;

    public GameObject buildingUI;
    public GameObject buildingManager;
    public GameObject gameOverUI;
    public GameObject animalUI;

    // replace with habitatTracker
    private Animal animalScript;

    // Start is called before the first frame update
    void Start()
    {
        gameAudio = GetComponent<AudioSource>();
    }

    public void GameOver()
    {
        // set animal UI false
        animalUI.gameObject.SetActive(false);
        buildingUI.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);

        if (animalScript.gameWon)
        {
            gameOverUI.GetComponentInChildren<TextMeshProUGUI>().text = "Play Again?";
        } else if (animalScript.gameLost)
        {
            gameOverUI.GetComponentInChildren<TextMeshProUGUI>().text = "Game Over";
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
