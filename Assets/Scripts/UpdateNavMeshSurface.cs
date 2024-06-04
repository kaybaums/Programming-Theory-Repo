using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class UpdateNavMeshSurface : MonoBehaviour
{

    [SerializeField] private NavMeshSurface deer_Surface;
    [SerializeField] private NavMeshSurface monkey_Surface;
    [SerializeField] private NavMeshSurface sparrow_Surface;


    public void UpdateWalkableEnvironment()
    {
        deer_Surface.BuildNavMesh();
        monkey_Surface.BuildNavMesh();
        sparrow_Surface.BuildNavMesh();
    }

}
