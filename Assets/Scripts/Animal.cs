using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Animal : MonoBehaviour
{
    private int animalHappiness = 5;

    private BuildingUI buildingUI;
    private Animator animator;
    private UpdateTextCounter updateTextCounter;

    private NavMeshAgent navMeshAgent;
    private GameManager gameManager;

    [SerializeField] GameObject happyIndicator;
    [SerializeField] GameObject sadIndicator;

    public bool gameWon = false;
    public bool gameLost = false;

    // Start is called before the first frame update
    void Start()
    {
        buildingUI = GameObject.Find("Building UI").GetComponent<BuildingUI>();
        animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.Find("Focal Point").GetComponent<GameManager>();
        updateTextCounter = GameObject.FindWithTag("Counter").GetComponent<UpdateTextCounter>();

        // pick a random direction to walk in
        navMeshAgent.destination = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {

        // while animal is not at destination, use walking animation
        if (Mathf.Abs(transform.position.x - navMeshAgent.destination.x) > 0.9f && Mathf.Abs(transform.position.z - navMeshAgent.destination.z) > 0.9f)
        {
            navMeshAgent.speed = 1.5f;
            animator.SetFloat("ani_speed", navMeshAgent.speed);
        }
        else
        {
            navMeshAgent.speed = 0.0f;
            animator.SetFloat("ani_speed", 0);
        }

        
    }

    public void LookSad()
    {
        /* if (animator != null)
        {
            animator.Play("Eyes_Cry", 1);
            animator.Play("Bounce", 0);
        }*/
        animator.SetTrigger("makeSad");
        gameManager.gameAudio.PlayOneShot(gameManager.sadSound, 0.6f);
        Instantiate(sadIndicator, new Vector3(transform.position.x, 3.0f, transform.position.z), Quaternion.identity);
        animalHappiness--;
        CheckAnimalHappiness();
    }

    public void LookHappy()
    {
        /*if (animator != null)
        {
            animator.Play("Eyes_Happy", 1);
            animator.Play()
        }*/
        animator.SetTrigger("makeHappy");
        gameManager.gameAudio.PlayOneShot(gameManager.happySound, 0.3f);
        Instantiate(happyIndicator, new Vector3(transform.position.x, 3.0f, transform.position.z), Quaternion.identity);
        CheckAnimalHappiness();
    }

    public void SetNewDestination(Vector3 destination)
    {
        navMeshAgent.destination = destination;
        Debug.Log("New Destination: " +  destination);
    }

    public void CheckAnimalHappiness()
    {
        
        if (updateTextCounter.treesMet && updateTextCounter.rocksMet && updateTextCounter.grassesMet && updateTextCounter.mushroomsMet)
        {
            if (animator != null)
            {
                animator.SetBool("isHappy", true);
                gameWon = true;
                gameManager.GameOver();
                Debug.Log("Game Over");
            }
        } else if (animalHappiness <= 0)
        {
            if (animator != null)
            {
                animator.SetBool("isSad", true);
                gameLost = true;
                gameManager.GameOver();
            }
        }
        else
        {
            animator.SetBool("isHappy", false);
            animator.SetBool("isSad", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Water") && collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isSwimming", true);
        } else if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isSwimming", false);
        }
    }

    private void OnMouseOver()
    {
        buildingUI.isBlocked = true;
    }
    private void OnMouseExit()
    {
        buildingUI.isBlocked = false;
    }
}
