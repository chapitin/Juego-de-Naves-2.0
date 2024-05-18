using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float movementSpeed = 30f;

    public static bool IsInLayerMask(GameObject obj, LayerMask mask)
    {
      return ((mask.value & (1 << obj.layer)) > 0);
    }

}
