using UnityEngine;
using Unity.AI.Navigation;

public class PlatformManager : MonoBehaviour
{
    public Transform player;
    public GameObject platformPrefab;
    public float platformLength = 30f; // Distance ahead to spawn platforms
    public int numOfPlatforms=0;

    private GameObject lastPlatform;

    public  NavMeshSurface navMeshSurface;

    void Start()
    {
        navMeshSurface = GameObject.Find("NMS").GetComponent<NavMeshSurface>();
        StartPlatform();
    }

    void Update()
    {
        if (player.position.z > lastPlatform.transform.position.z - platformLength*2)
        {
            SpawnPlatform();
        }

    }

    void StartPlatform()
    {
        for(int i =0; i<numOfPlatforms-1;i++)
        {
            Instantiate(platformPrefab, new Vector3(0,0,platformLength*i), Quaternion.identity);
        }
        lastPlatform=Instantiate(platformPrefab, new Vector3(0,0,platformLength*(numOfPlatforms-1)), Quaternion.identity);

        navMeshSurface.BuildNavMesh(); // Rebuild the NavMesh

    }

    void SpawnPlatform()
    {
        Vector3 spawnPosition = lastPlatform.transform.position + new Vector3(0,0,platformLength);
        lastPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        navMeshSurface.BuildNavMesh(); // Rebuild the NavMesh
    }

}
