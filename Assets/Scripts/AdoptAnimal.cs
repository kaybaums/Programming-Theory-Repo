using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdoptAnimal : MonoBehaviour
{
    // the purpose of this script is to allow the player to add or remove animals from the scene

    private int animalIndex = 0;

    private bool isPlacing = false;
    public bool bulldozing = false;

    private Mesh previewMesh;
    [SerializeField] private Material previewMaterial;
    [SerializeField] private Material blockedMaterial;

    private BuildingManager buildManagerScript;
    private GameManager gameManager;

    public bool isBlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        AddButtonListeners();

        // get the building manager script
        buildManagerScript = GameObject.Find("Building Manager").GetComponent<BuildingManager>();

        // get the Game Manager script
        gameManager = GameObject.Find("Focal Point").GetComponent<GameManager>();
    }

    void AddButtonListeners()
    {
        // find the UI buttons and assign an index
        Button[] buttons = GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[index].onClick.AddListener(() => SelectAnimalToAdopt(index));
        }
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
                    buildManagerScript.SpawnAdoptedAnimal(animalIndex, position);
                    isPlacing = false;
                    gameManager.gameAudio.PlayOneShot(gameManager.adoptSound, 0.7f);
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

    public void SelectAnimalToAdopt(int index)
    {
        gameManager.gameAudio.PlayOneShot(gameManager.buttonSound, 1.0f);
        animalIndex = index;
        isPlacing = true;
        if (index == 0)
        {
            previewMesh = buildManagerScript.animals[index].GetComponentInChildren<MeshFilter>().sharedMesh;
        }
        else if (index == 1)
        {
            previewMesh = buildManagerScript.animals[index].GetComponentInChildren<MeshFilter>().sharedMesh;
        }
        else if (index == 2)
        {
            previewMesh = buildManagerScript.animals[index].GetComponentInChildren<MeshFilter>().sharedMesh;
        }
    }

    
}
