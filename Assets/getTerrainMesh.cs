using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getTerrainMesh : MonoBehaviour
{
     public Terrain terrain;
    // Start is called before the first frame update
    void Start()
    {
         MeshFilter terrainMeshFilter = terrain.GetComponent<MeshFilter>();

        // Get the terrain mesh
        Mesh terrainMesh = terrainMeshFilter.mesh;

        // Do something with the mesh (e.g. add a mesh collider)
        gameObject.AddComponent<MeshCollider>().sharedMesh = terrainMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
