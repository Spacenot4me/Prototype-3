using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject barrierPrefab;
    public int startGameTimer = 2;
    public float repeatingTimer = 2f;
    private Vector3 spawnPos = new Vector3(17.1599998f, 1.1920929e-07f, 1);
    private PlayerController playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnBarrier", startGameTimer, repeatingTimer);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnBarrier()
    {
        if(playerControllerScript.isGameOver == false)
        {
            Instantiate(barrierPrefab, spawnPos, barrierPrefab.transform.rotation);
        }
        
    }

}
