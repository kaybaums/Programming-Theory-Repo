using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class UpdateNavMeshSurface : MonoBehaviour
{

    [SerializeField] private NavMeshSurface animal1_Surface;
    [SerializeField] private NavMeshSurface animal2_Surface;
    [SerializeField] private NavMeshSurface animal3_Surface;


    public void UpdateWalkableEnvironment()
    {
        animal1_Surface.BuildNavMesh();
        animal2_Surface.BuildNavMesh();
        animal3_Surface.BuildNavMesh();
    }

}
