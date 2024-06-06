using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using TMPro;

public abstract class Animal : MonoBehaviour
{
    public float animalHappiness = 0.0f;

    protected BuildingUI buildingUI;
    protected Animator animator;
    protected Keeper keeper; 
    protected GameManager gameManager;

    [SerializeField] Material highlightMaterial;
    private Material originalMaterial;

    private NavMeshAgent navMeshAgent;

    [SerializeField] private GameObject happyIndicator;
    [SerializeField] private GameObject sadIndicator;

    public int treesWanted;
    public int rocksWanted;
    public int grassWanted;
    public int foodWanted;
    protected private int totalWanted;

    // Start is called before the first frame update
    void Awake()
    {
        SetVariables();
    }

    public abstract void DefineWants();

    public void SetVariables()
    {
        buildingUI = GameObject.Find("Building UI").GetComponent<BuildingUI>();

        animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        gameManager = GameObject.Find("Focal Point").GetComponent<GameManager>();
        keeper = GameObject.Find("Keeper").GetComponent<Keeper>();

        // pick a random direction to walk in
        navMeshAgent.destination = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-10.0f, 0.0f));
        navMeshAgent.speed = 1.5f;

        SkinnedMeshRenderer[] modelRenderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
        for (int i = 0; i < modelRenderers.Length; i++)
        {
            originalMaterial = modelRenderers[i].material;
        }
    }

    public void Walk()
    {
        if (navMeshAgent != null)
        {
            // check if animal is happy or is sad because we don't want a moving spinning animal or dead animal
            if (animator.GetBool("isHappy"))
            {
                navMeshAgent.speed = 0.0f;
                animator.SetFloat("ani_speed", 0);
            }
            else if (animator.GetBool("isSad"))
            {
                navMeshAgent.speed = 0.0f;
                animator.SetFloat("ani_speed", 0);
            }
            else
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
        }
        
    }

    public void LookSad()
    {
        animator.SetTrigger("makeSad");
        gameManager.gameAudio.PlayOneShot(gameManager.sadSound, 0.6f);
        Instantiate(sadIndicator, new Vector3(transform.position.x, 3.0f, transform.position.z), Quaternion.identity);
    }

    public void LookHappy()
    {
        animator.SetTrigger("makeHappy");
        gameManager.gameAudio.PlayOneShot(gameManager.happySound, 0.3f);
        Instantiate(happyIndicator, new Vector3(transform.position.x, 3.0f, transform.position.z), Quaternion.identity);
    }

    public void SetNewDestination(Vector3 destination)
    {
        navMeshAgent.destination = destination;
    }

    private void CheckTrees()
    {
        float perItemValue = 1.0f / (float)totalWanted;

        // check tree need, if animal doesn't want trees then it will ignore this
        if (treesWanted != 0 && keeper.treesCurrent > 0)
        { 
            if (treesWanted >= keeper.treesCurrent)
            {
                animalHappiness += perItemValue; // add the per item value
                LookHappy();
            }
            else if (keeper.treesCurrent > treesWanted)
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
            if (rocksWanted >= keeper.rocksCurrent)
            {
                animalHappiness += perItemValue; // add the per item value
                LookHappy();
            }
            else if (keeper.rocksCurrent > rocksWanted)
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
            if (grassWanted >= keeper.grassesCurrent)
            {
                animalHappiness += perItemValue; // add the per item value
                LookHappy();
            }
            else if (keeper.grassesCurrent > grassWanted)
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
            if (foodWanted >= keeper.foodCurrent)
            {
                animalHappiness += perItemValue; // add the per item value
                LookHappy();
            }
            else if (keeper.foodCurrent > foodWanted)
            {
                animalHappiness -= perItemValue;
                LookSad();
            }
        }
    }

    public void CheckAnimalHappiness(string item)
    {
        if (item == "tree")
        {
            CheckTrees();
        } else if (item == "rock")
        {
            CheckRocks();
        } else if (item == "grass")
        {
            CheckGrasses();
        } else if (item == "food")
        {
            CheckFood();
        }

        Debug.Log(gameObject.name + ": " + animalHappiness);

        if (animalHappiness >= 0.85f)
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

    public void OnMouseEnter()
    {
        buildingUI.isBlocked = true;
        if (buildingUI.bulldozing)
        {
            SkinnedMeshRenderer[] modelRenderers =  gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
            for (int i = 0; i < modelRenderers.Length; i++)
            {
                modelRenderers[i].material = highlightMaterial;
            }
        }
    }
    public void OnMouseExit()
    {
        buildingUI.isBlocked = false;
        if (buildingUI.bulldozing)
        {
            SkinnedMeshRenderer[] modelRenderers = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
            for (int i = 0; i < modelRenderers.Length; i++)
            {
                modelRenderers[i].material = originalMaterial;
            }
        }
    }

    public void OnMouseDown()
    {
        if (buildingUI.bulldozing)
        {
            keeper.UpdateHabitatNeeds(-treesWanted, -rocksWanted, -grassWanted, -foodWanted);
            buildingUI.bulldozing = false;
            buildingUI.isBlocked = false;
            for (int i = 0; i < keeper.animals.Count; i++)
            {
                if (keeper.animals[i].name == gameObject.name)
                {
                    keeper.animals.RemoveAt(i);
                }
            }
            keeper.CalcHabitatQuality();
            keeper.CheckHabitatQuality();
            Destroy(gameObject);
        }
    }
}
