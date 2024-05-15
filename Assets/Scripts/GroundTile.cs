using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public string playerLayerName = "Player";
    private int playerLayer;

    GroundSpawner groundSpawner;

    private void Start()
    {
      groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
      playerLayer = LayerMask.NameToLayer(playerLayerName);
    }

    private void OnTriggerExit (Collider other)
    {
      // if (other.CompareTag("Player"))
      // {
      //   groundSpawner.SpawnTile();
      //   Destroy(gameObject, 2);
      // }
    
      if (other.gameObject.layer == playerLayer)
      {
          groundSpawner.SpawnTile();
          Destroy(gameObject, 2);
      }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
