using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //public float speed = 2f;
    public Vector3 direction;
    public float destroyTime = 2f;

    public LayerMask layerMaskToCheck;


    void Start()
    {
       Invoke("AutoDestroy", destroyTime);
    }



    void Update()
    {
       this.transform.Translate(direction);
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }

    public void Init(bool player)
    {
      if (player)
      {
        direction = Vector3.forward;
      }
      else
      {
        direction = Vector3.back;
      }
    }

    private void OnTriggerEnter(Collider collider)
      {


          if(GameManager.IsInLayerMask(collider.gameObject, layerMaskToCheck))
          {
            collider.gameObject.GetComponent<Idamage>()?.TakeDamage();

            if (collider.gameObject.GetComponent<Idamage>() != null)
            {
              Destroy(gameObject);
            }
          }

      }
}
