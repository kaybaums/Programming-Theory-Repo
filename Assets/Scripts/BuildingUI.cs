using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    private bool isPlacing = false;
    public bool bulldozing = false;

    private Mesh previewMesh;
    [SerializeField] private Material previewMaterial;
    [SerializeField] private Material blockedMaterial;

    private BuildingManager buildManagerScript;
    private GameManager gameManager;
    private Keeper keeper;
    [SerializeField] private int currentIndex = 0;

    public int rockIndex = 0;
    public int grassIndex = 0;
    public int foodIndex = 0;

    public bool isBlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        // find the UI buttons and assign an index
        Button[] buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length - 1; i++)
        {
            int index = i;
            buttons[index].onClick.AddListener(() => SelectItemToBuild(index));
        }

        // get the building manager script
        buildManagerScript = GameObject.Find("Building Manager").GetComponent<BuildingManager>();

        // get the Game Manager script
        gameManager = GameObject.Find("Focal Point").GetComponent<GameManager>();

        // get the Keeper script
        keeper = GameObject.Find("Keeper").GetComponent<Keeper>();
        isBlocked = false;
}

    // Update is called once per frame
    void Update()
    {
        if (isPlacing)
        {
            // find mouse position on terrain
            Vector3 position = MouseToTerrainPosition();

            if (!isBlocked)
            {
                // draw mesh preview at mouse position
                Graphics.DrawMesh(previewMesh, position, Quaternion.identity, previewMaterial, 0);

                // if player clicks mouse
                if (Input.GetMouseButtonDown(0))
                {
                    // BuildingManager spawn building
                    buildManagerScript.SpawnItemToBuild(currentIndex, position);
                    isPlacing = false;
                    gameManager.gameAudio.PlayOneShot(gameManager.buildSound, 0.7f);
                }
            }
            else
            {
                // draw blocked mesh preview at mouse position
                Graphics.DrawMesh(previewMesh, position, Quaternion.identity, blockedMaterial, 0);

                // if player clicks left mouse button, play error sound
                if (Input.GetMouseButtonDown(0))
                {
                    gameManager.gameAudio.PlayOneShot(gameManager.errorSound, 0.7f);
                }
            }
            
        }

        if (bulldozing)
        {
            if (isBlocked)
            {
                // if player clicks mouse
                if (Input.GetMouseButtonDown(0))
                {
                    keeper.CalcHabitatQuality();
                    keeper.CheckHabitatQuality();
                    isBlocked = false;
                    bulldozing = false;
                }
            }
        }
    }


    // Raycast from the main camera to the layer labeled "Level" to get the mouse position
    private Vector3 MouseToTerrainPosition()
    {
        Vector3 position = Vector3.zero;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit info, 100, LayerMask.GetMask("Level")))
        {
            position = info.point;
        }
        return position;
    }

    private RaycastHit CameraRay()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit info, 100))
        {
            return info;
        }
        return new RaycastHit();
    }

    // Select fir tree to build
    void SelectFirTree()
    {
        previewMesh = buildManagerScript.firTree.GetComponentInChildren<MeshFilter>().sharedMesh;
    }

    void SelectSakuraTree()
    {
        previewMesh = buildManagerScript.sakuraTree.GetComponentInChildren<MeshFilter>().sharedMesh;
    }

    void SelectRock(int index)
    {
        previewMesh = buildManagerScript.rocksList[index].GetComponentInChildren<MeshFilter>().sharedMesh;
    }

    void SelectGrass(int index)
    {
        previewMesh = buildManagerScript.grassList[index].GetComponentInChildren<MeshFilter>().sharedMesh;
    }

    void SelectMushroom(int index)
    {
        previewMesh = buildManagerScript.foodList[index].GetComponentInChildren<MeshFilter>().sharedMesh;
    }

    void SelectItemToBuild(int index)
    {
        gameManager.gameAudio.PlayOneShot(gameManager.buttonSound, 1.0f);
        currentIndex = index;
        isPlacing = true;
        if (index == 0)
        {
            SelectFirTree();
        } else if (index == 1)
        {
            SelectSakuraTree();
        } else if (index == 2)
        {
            // choose random rock prefab
            rockIndex = Random.Range(0, 3);
            SelectRock(rockIndex);
        } else if (index == 3)
        {
            // choose random grass prefab
            grassIndex = Random.Range(0, 3);
            SelectGrass(grassIndex);
        } else if (index == 4)
        {
            // choose random mushroom prefab
            foodIndex = Random.Range(0, 3);
            SelectMushroom(foodIndex);
        }
    }

    public void StartBulldozing()
    {
        gameManager.gameAudio.PlayOneShot(gameManager.buttonSound, 1.0f);
        bulldozing = true;
    }

    public void CheckPlacement(bool blockedFlag)
    {
        isBlocked = blockedFlag;
    }
}
