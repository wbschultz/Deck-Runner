using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeckRunner.Positioning;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int maxEnemyCount;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float timeBetweenSpawns = 1f;

    private TrackList posList;
    private Queue<GameObject> enemies;
    private float timeUntilSpawn;

    private void Awake() {
        posList = new TrackList(transform.position);
        timeUntilSpawn = timeBetweenSpawns;
    }

    // Start is called before the first frame update
    void Start()
    {
        ObjectPooler.Instance.CreatePool(enemyPrefab, maxEnemyCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUntilSpawn <= 0){
            // spawn a new enemy at a random track
            Vector3 [] posArray = { posList.LeftPosition, posList.CenterPosition, posList.RightPosition };
            ObjectPooler.Instance.ReuseObject(enemyPrefab, posArray[Random.Range(0, 3)], enemyPrefab.transform.rotation);
            // reset time
            timeUntilSpawn = timeBetweenSpawns;
        } else {
            timeUntilSpawn -= Time.deltaTime;
        }
    }
}
