using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject Player;
    public float offsetX = 0f;
    public float offsetY = 2f;
    public float offsetZ = -5f;

    public float cameraAngleX = 30f;


    private Camera cam;
    private Vector3 cameraOffset;

    public float minX = -10f;
    public float maxX = 10f;
    //public float minZ = -10f;
    //public float maxZ = 10f;



    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cameraOffset = new Vector3(offsetX, offsetY, offsetZ);
    }

    
    void LateUpdate()
    {
        if (Player != null)
        {
            Vector3 desiredPosition = Player.transform.position + cameraOffset;
            float clampedX = Mathf.Clamp(desiredPosition.x, minX, maxX);
            //float clampedZ = Mathf.Clamp(desiredPosition.z, minZ, maxZ);

            desiredPosition = new Vector3(clampedX, desiredPosition.y, 
            desiredPosition.z);

            transform.position = Vector3.Lerp(transform.position, desiredPosition, 
            Time.deltaTime * GameManager.movementSpeed);

            transform.rotation = Quaternion.Euler(cameraAngleX, 0f, 0f);
        }
        else
        {
            return;
        }
    }
}
