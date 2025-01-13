using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Enemy enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Spawner()
    {
        while (true)
        {
            Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
