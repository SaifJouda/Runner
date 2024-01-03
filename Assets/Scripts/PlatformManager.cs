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


    void Start()
    {
        //navMeshSurface = GameObject.Find("NMS").GetComponent<NavMeshSurface>();
        StartPlatform();
    }

    void Update()
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
        for(int i =1; i<numOfPlatforms-1;i++)
        {
            //lastPlatform=Instantiate(platformPrefab, new Vector3(0,0,platformLength*i), Quaternion.identity);
            //lastPlatform.GetComponent<CheckPoint>().createPowerUps();
            //lastPlatform.GetComponent<CheckPoint>().allyController=allyController;
            SpawnPlatform(new Vector3(0,0,platformLength*i));
        }
        SpawnPlatform(new Vector3(0,0,platformLength*(numOfPlatforms-1)));
        //lastPlatform=Instantiate(platformPrefab, new Vector3(0,0,platformLength*(numOfPlatforms-1)), Quaternion.identity);
        //lastPlatform.GetComponent<CheckPoint>().createPowerUps();
        //lastPlatform.GetComponent<CheckPoint>().allyController=allyController;

        //navMeshSurface.BuildNavMesh(); // Rebuild the NavMesh

    }

    void SpawnPlatform(Vector3 spawnPosition)
    {
    
        nextPlatform=lastPlatform;
        //Vector3 spawnPosition = lastPlatform.transform.position + new Vector3(0,0,platformLength);
        lastPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        navMeshSurface.BuildNavMesh(); // Rebuild the NavMesh
        lastPlatform.GetComponent<CheckPoint>().createPowerUps();
        lastPlatform.GetComponent<CheckPoint>().allyController=allyController;
        lastPlatform.GetComponent<CheckPoint>().nextPlatform=nextPlatform;
    }

    void SpawnEnemies(Vector3 spawnPosition)
    {
        for(int i=0;i< Random.Range(1, 10); i++) lastEnemySpawned=Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }


}
