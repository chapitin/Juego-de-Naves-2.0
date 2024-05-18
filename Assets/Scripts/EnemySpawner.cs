using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  public Transform playerTransform;
  public GameObject enemyPrefab;
  public GameObject complexEnemy;
  private GameObject obj = null;
  public float spawnRate = 2f;
  public Transform spawnPosition;
  public float deltaSpawnPosition;


  public static EnemySpawner instance;

  private void Awake()
  {
    if(instance != null)
    {
        Destroy(this.gameObject);
    }
    else
    {
        instance = this;
    }
  }

  private void Start()
  {
    InvokeRepeating("CreateEnemy", spawnRate, spawnRate);
  }

  private void CreateEnemy()
  {
    Vector3 randomPos = spawnPosition.position;

    randomPos.x += Random.Range(
        randomPos.x - deltaSpawnPosition,
        randomPos.x + deltaSpawnPosition);

    randomPos.z += Random.Range(
        randomPos.z - deltaSpawnPosition,
        randomPos.z + deltaSpawnPosition);


    int randomEnemy = Random.Range(0,2);

    if (randomEnemy == 0)
    {
      obj = Instantiate(enemyPrefab,
          randomPos,
          Quaternion.identity);
          obj.GetComponent<Enemy>().playerTransform = this.playerTransform;

    }
    else
    {
      obj = Instantiate(complexEnemy,
        randomPos,
        Quaternion.identity);
        obj.GetComponent<ComplexEnemy>().playerTransform = this.playerTransform;

    }

    if (obj != null)
    {
    }
  }

}
