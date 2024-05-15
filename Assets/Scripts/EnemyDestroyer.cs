using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{

    public string enemyLayerName = "Enemy";
    public string complexEnemyLayerName = "Complex Enemy";
    private int enemyLayer;
    private int complexEnemyLayer;


    void Start()
    {
        enemyLayer = LayerMask.NameToLayer(enemyLayerName);
        complexEnemyLayer = LayerMask.NameToLayer(complexEnemyLayerName);
    }

    private void OnTriggerExit(Collider other)
    {
        int collisionLayer = other.gameObject.layer;

        if(collisionLayer == enemyLayer ||
           collisionLayer == complexEnemyLayer)
        {
            Destroy(other.gameObject);
        }
    }
}
