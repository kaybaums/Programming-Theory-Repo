using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class UpdateNavMeshSurface : MonoBehaviour
{

    NavMeshSurface m_Surface;

    void Awake()
    {
        m_Surface = GetComponent<NavMeshSurface>();
    }

    /*void OnEnable()
    {
        m_Surface.BuildNavMesh();
    }*/

    public void UpdateWalkableEnvironment()
    {
        m_Surface.UpdateNavMesh(m_Surface.navMeshData);
    }

}
