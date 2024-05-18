using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour, Idamage
{
    //public values
    public Transform playerTransform;
    public float speed = 2f;
    public int points = 1;


    // layers
    public string laserLayerName = "Laser";
    private int laserLayer;
    public string playerLayerName = "Player";
    private int playerLayer;

    public GameObject explosion;

    private AudioSource explosionAudio;


    public static Action<int> OnDead;

    void Start()
    {
        laserLayer = LayerMask.NameToLayer(laserLayerName);
        playerLayer = LayerMask.NameToLayer(playerLayerName);
        explosionAudio = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        MoveToPlayer();

    }

    public void MoveToPlayer()
    {

        // if(playerTransform == null)
        // {
        //     Debug.LogWarning("Player transform not assigned to enemy.");
        //     return;
        // }

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
        Vector3 dist = playerTransform.position - this.transform.position;

        this.transform.Translate(dist.normalized * speed * Time.deltaTime);
        }
        else

        {
            Debug.LogWarning("Player Tag not found");
        }
    }


    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.layer == laserLayer)
    //     {
    //         Destroy(this.gameObject);
    //     }
    // }

    private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.layer == laserLayer ||
            collision.gameObject.layer == playerLayer)
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            OnDead?.Invoke(points);
            Destroy(this.gameObject);

        }
    }

    public void TakeDamage()
    {
      explosionAudio.Play();
      Destroy(gameObject);
      OnDead?.Invoke(points);
      GameObject explosionInstance = Instantiate(explosion, this.transform.position, Quaternion.identity);


    if (explosionInstance != null)
    {
        Debug.Log("Explosion instantiated successfully at " + explosionInstance.transform.position);
    }
    else
    {
        Debug.Log("Failed to instantiate explosion.");
    }

    }
}
