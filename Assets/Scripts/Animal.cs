using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Animal : MonoBehaviour
{
    public float animalHappiness = 0.2f;

    private BuildingUI buildingUI;
    private Animator animator;
    private Keeper keeper;

    private NavMeshAgent navMeshAgent;
    private GameManager gameManager;

    [SerializeField] private GameObject happyIndicator;
    [SerializeField] private GameObject sadIndicator;

    public int treesWanted { get; set; }
    public int rocksWanted { get; set; }
    public int grassWanted { get; set; }
    public int foodWanted { get; set; }
    protected private int totalWanted { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        buildingUI = GameObject.Find("Building UI").GetComponent<BuildingUI>();
        animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.Find("Focal Point").GetComponent<GameManager>();
        keeper = GameObject.Find("Keeper").GetComponent<Keeper>();

        // pick a random direction to walk in
        navMeshAgent.destination = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 0.0f));

        totalWanted = treesWanted + rocksWanted + grassWanted + foodWanted;
        //Walk();
        navMeshAgent.speed = 1.5f;
    }

    private void Update()
    {
        animator.SetFloat("ani_speed", navMeshAgent.speed);
    }

    /*public virtual void Walk()
    {
        if (navMeshAgent.destination != null)
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
        
    }*/

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

    private void CheckTrees()
    {
        float perItemValue = 1.0f / (float)totalWanted;

        // check tree need, if animal doesn't want trees then it will ignore this
        if (treesWanted != 0 && keeper.treesCurrent > 0)
        {
            if (treesWanted <= keeper.treesCurrent)
            {
                animalHappiness += perItemValue; // add the per item value
                LookHappy();
            }
            else if (treesWanted > keeper.treesCurrent)
            {
                animalHappiness -= perItemValue;
                LookSad();
            }
        }
    }

    private void CheckRocks()
    {
        float perItemValue = 1.0f / (float)totalWanted;

        // check rock need, if animal doesn't want rocks then it will ignore this
        if (rocksWanted != 0 && keeper.rocksCurrent > 0)
        {
            if (rocksWanted <= keeper.rocksCurrent)
            {
                animalHappiness += perItemValue; // add the per item value
                LookHappy();
            }
            else if (rocksWanted > keeper.rocksCurrent)
            {
                animalHappiness -= perItemValue;
                LookSad();
            }
        }
    }

    private void CheckGrasses()
    {
        float perItemValue = 1.0f / (float)totalWanted;

        // check grass need, if animal doesn't want grass then it will ignore this
        if (grassWanted != 0 && keeper.grassesCurrent > 0)
        {
            if (grassWanted <= keeper.grassesCurrent)
            {
                animalHappiness += perItemValue; // add the per item value
                LookHappy();
            }
            else if (grassWanted > keeper.grassesCurrent)
            {
                animalHappiness -= perItemValue;
                LookSad();
            }
        }
    }

    private void CheckFood()
    {
        float perItemValue = 1.0f / (float)totalWanted;

        // check food need, if animal doesn't want food then it will ignore this
        if (foodWanted != 0 && keeper.foodCurrent > 0)
        {
            if (foodWanted <= keeper.foodCurrent)
            {
                animalHappiness += perItemValue; // add the per item value
                LookHappy();
            }
            else if (foodWanted > keeper.foodCurrent)
            {
                animalHappiness -= perItemValue;
                LookSad();
            }
        }
    }

    public virtual void CheckAnimalHappiness()
    {
        animalHappiness = 0.0f;

        CheckTrees();
        CheckRocks();
        CheckGrasses();
        CheckFood();

        Debug.Log(gameObject.name + ": " + animalHappiness);

        if (animalHappiness >= 0.8f)
        {
            animator.SetBool("isHappy", true);
        } else if ( animalHappiness < 0.15f)
        {
            animator.SetBool("isSad", true);
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
