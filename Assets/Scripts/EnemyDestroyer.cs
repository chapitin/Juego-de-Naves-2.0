using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{

    public LayerMask layerMaskToCheck;

    public string enemyLayerName = "Enemy";
    public string complexEnemyLayerName = "Complex Enemy";
    private int enemyLayer;
    private int complexEnemyLayer;


    void Start()
    {
        enemyLayer = LayerMask.NameToLayer(enemyLayerName);
        complexEnemyLayer = LayerMask.NameToLayer(complexEnemyLayerName);
    }

    private void OnTriggerEnter(Collider collider)
      {


          if(GameManager.IsInLayerMask(collider.gameObject, layerMaskToCheck))
          {
            print("clean up enemy");
            //Destroy(gameObject);
          }

      }
}
