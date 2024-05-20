using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, Idamage
{
    public LayerMask layerMaskToCheck;

    //layers
    //public string enemyLayerName = "Enemy";
    //private int enemyLayer;

    //public values
    public float sidewaysSpeed = 5f;
    public float boostSpeed = 10f;
    public float fireRate = 0.2f;
    public int maxLives = 3;
    public float invincibilityDuration = 2f;



    //private values
    private float lastShot;
    private int currentLives;
    private bool isInvincible;
    private float invincibilityEndTime;

    private AudioSource mySource;


    //objects
    public Transform LaserSpawnPoint;
    public GameObject LaserPrefab;


    //statics
    public static Action OnShoot;
    public static Action OnDead;
    public static Action<int> OnDamage;

    public static Player instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        mySource = this.GetComponent<AudioSource>();
        currentLives = maxLives;
        //enemyLayer = LayerMask.NameToLayer(enemyLayerName);
    }

    // Update is called once per frame
    void Update()
    {
        AllMovement();
        Shoot();
    }

    private void AllMovement()
    {
        ForwardMovement();
        SidewaysMovement();
        Boost();
    }

    private void ForwardMovement()
    {
        transform.Translate(Vector3.forward *
        GameManager.movementSpeed * Time.deltaTime);
    }

        private void SidewaysMovement()
    {
         Vector3 direction = new Vector3();

            if (Input.GetKey(KeyCode.RightArrow))
        {

            direction.x = 1;
        }

           if (Input.GetKey(KeyCode.LeftArrow))
        {

            direction.x = -1;
        }

        Vector3 move = direction * Time.deltaTime * sidewaysSpeed;
        this.transform.Translate(move);
    }

    private void Boost()
    {
        Vector3 forwardDirection = new Vector3();

        if (Input.GetKey(KeyCode.UpArrow))
        {

            forwardDirection.z = 1;
        }

        float totalSpeed = GameManager.movementSpeed + boostSpeed;

        Vector3 boost = forwardDirection * Time.deltaTime * totalSpeed;
        this.transform.Translate(boost);
    }

    private void Shoot()
    {
          if (Input.GetKey(KeyCode.Space) && (Time.time - lastShot) >= fireRate)
        {
            GameObject go = Instantiate(LaserPrefab,
                LaserSpawnPoint.position,
                this.transform.rotation);


                go.GetComponent<Laser>().Init(true);

                lastShot = Time.time;

                mySource.Play();

               OnShoot?.Invoke();

               //print("shot working");


        }
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     int collisionLayer = collision.gameObject.layer;

    //     //if(!isInvincible && collisionLayer == enemyLayer)
    //     //{
    //         //Damage();
    //         print("Your Lives: " + currentLives);


    //     //}

    //     print("hay colision");
    // }

    private void OnTriggerEnter(Collider collider)
    {
      //Debug.Log("trigger working");


        if(!isInvincible && GameManager.IsInLayerMask(collider.gameObject, layerMaskToCheck))
        {
            Damage();
            print("Your Lives: " + currentLives);


        }
        else
        {
          Debug.Log($"{isInvincible} {collider.gameObject.layer} {layerMaskToCheck}");
        }
    }

    private void Damage()
    {
       currentLives--;
       OnDamage?.Invoke(currentLives);

       if (currentLives <= 0)
       {
            //print("Mission Failed");
            OnDead?.Invoke();
            Destroy(this.gameObject);
            LoadNextScene();
       }
       else
       {
            isInvincible = true;
            invincibilityEndTime = Time.time + invincibilityDuration;
            StartCoroutine(EndInvincibility());
       }
    }

    public void LoadNextScene()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator EndInvincibility()
    {
      yield return new WaitForSeconds(invincibilityDuration);
      isInvincible = false;
    }

    public void TakeDamage()
    {
      Damage();
    }

}
