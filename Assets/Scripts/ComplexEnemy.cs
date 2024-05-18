using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ComplexEnemy : MonoBehaviour, Idamage
{

    //public values
    public Transform playerTransform;
    public float speed = 2f;
    public int points = 2;
    public float zigzagFrequency = 2f;
    public float zigzagAmplitude = 1f;
    public int health = 2;
    public float minShootInterval = 1f;
    public float maxShootInterval = 3f;


    //private
    public float timeOffset = 1;
    private float nextShootTime;

    private AudioSource explosionAudio;

    // layers
    public string laserLayerName = "Laser";
    private int laserLayer;
    public string playerLayerName = "Player";
    private int playerLayer;

    public Transform LaserSpawnPoint;
    public GameObject EnemyLaserPrefab;
    public GameObject explosion;

    public static Action<int> OnDead;

    void Awake()
    {
        if (Player.instance != null)
            playerTransform = Player.instance.transform;
        else
            Debug.LogError("Player instance not found");
    }

    void Start()
    {
        laserLayer = LayerMask.NameToLayer(laserLayerName);
        playerLayer = LayerMask.NameToLayer(playerLayerName);
        explosionAudio = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        Movement();
        TimeToShoot();
    }

private void Movement()
    {

        if (playerTransform == null)
        {
            Debug.LogWarning("Player Transform not assigned to ComplexEnemy.");
            return;
        }

        Vector3 zigzagOffset = new Vector3(Mathf.Sin((Time.time + timeOffset)
         * zigzagFrequency) * zigzagAmplitude, 0f, 0f);


        Vector3 directionToPlayer = (playerTransform.position -
        transform.position).normalized;

        Vector3 movement = (directionToPlayer + zigzagOffset).normalized
        * speed * Time.deltaTime;

        transform.Translate(movement);
    }

    private void LookAtPlayer()
    {

        if (playerTransform != null)
        {
            transform.LookAt(playerTransform);
        }
    }

    private void Death()
    {
        if (health <= 0)
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            OnDead?.Invoke(points);
            explosionAudio.Play();
            Destroy(this.gameObject);

        }
    }

    private void TimeToShoot()
    {
        if (Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time +
            UnityEngine.Random.Range(minShootInterval, maxShootInterval);
        }

    }

    private void Shoot()
    {
        GameObject go = Instantiate(EnemyLaserPrefab,
        LaserSpawnPoint.position,
        this.transform.rotation);

        go.GetComponent<Laser>().Init(false);
    }

    public void TakeDamage()
    {
      health--;
      Death();
    }

}
