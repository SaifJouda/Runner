using UnityEngine;
using Unity.AI.Navigation;

public class PlatformManager : MonoBehaviour
{
    public Transform player;
    public GameObject platformPrefab;
    private float platformLength = 40f; // Distance ahead to spawn platforms
    public int numOfPlatforms=0;

    public GameObject enemyPrefab;

    public AllyController allyController;
    private GameObject lastPlatform;

    public  NavMeshSurface navMeshSurface;

    private GameObject lastEnemySpawned;
    public GameObject nextPlatform;

    public int checkPointsPassed=0;

    public StartingPlatform startingPlatform;

    public MainController mainController;


    void Start()
    {
        //navMeshSurface = GameObject.Find("NMS").GetComponent<NavMeshSurface>();
        StartPlatform();
        InvokeRepeating("CheckPlayerLocation", 0f,0.4f);
    }

    void CheckPlayerLocation()
    {
        if (player.position.z > lastPlatform.transform.position.z - platformLength*2)
        {
            Vector3 spawnLocation= lastPlatform.transform.position + new Vector3(0,0,platformLength);
            SpawnPlatform(spawnLocation);
            //SpawnEnemies(spawnLocation); //moved to EnemyManager located inside platform prefab
        }

    }

    void StartPlatform()
    {
        lastPlatform = Instantiate(platformPrefab, new Vector3(0,0,platformLength), Quaternion.identity, transform);
        navMeshSurface.BuildNavMesh();
        lastPlatform.GetComponent<CheckPoint>().SetCheckPoint(allyController, null, this, checkPointsPassed, mainController);
        startingPlatform.nextEnemyManager=lastPlatform.GetComponent<CheckPoint>().enemyManager;
    }

    void SpawnPlatform(Vector3 spawnPosition)
    {
    
        nextPlatform=lastPlatform;
        lastPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity, transform);
        navMeshSurface.BuildNavMesh(); // Rebuild the NavMesh
        lastPlatform.GetComponent<CheckPoint>().SetCheckPoint(allyController, nextPlatform, this, checkPointsPassed, mainController);
    

    }

    void SpawnEnemies(Vector3 spawnPosition)
    {
        for(int i=0;i< Random.Range(1, 10); i++) lastEnemySpawned=Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    public void PlusCheckpoint()
    {
        checkPointsPassed++;
    }

    public void Restart()
    {
        DeleteAllPlatforms();
        StartPlatform();
    }

    private void DeleteAllPlatforms()
    {
        foreach (Transform child in transform)
        {
            // Destroy each child
            Destroy(child.gameObject);
        }
    }

}
