using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //public float speed = 2f;
    public float destroyTime = 2f;

  
    void Start()
    {
       Invoke("AutoDestroy", destroyTime); 
    }



    void Update()
    {
       this.transform.Translate(this.transform.forward);
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }
}
