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
    public AudioClip adoptSound;
    public AudioClip errorSound;

    public AudioSource gameAudio;

    public GameObject buildingUI;
    public GameObject buildingManager;
    public GameObject gameOverUI;
    public GameObject animalUI;
    public GameObject backToMenuButton;

    private Keeper keeper;

    // Start is called before the first frame update
    void Start()
    {
        gameAudio = GetComponent<AudioSource>();
        keeper = GameObject.Find("Keeper").GetComponent<Keeper>();
    }

    public void GameOver()
    {
        // set animal UI false
        animalUI.gameObject.SetActive(false);
        buildingUI.gameObject.SetActive(false);
        backToMenuButton.gameObject.SetActive(false);
        gameOverUI.gameObject.SetActive(true);

        if (keeper.gameWon)
        {
            gameOverUI.GetComponentInChildren<TextMeshProUGUI>().text = "Play Again?";
        } else
        {
            gameOverUI.GetComponentInChildren<TextMeshProUGUI>().text = "Game Over";
        }
    }

    public void RestartGame()
    {
        gameAudio.PlayOneShot(buttonSound, 1.0f);
        SceneManager.LoadScene(0);
    }
}
