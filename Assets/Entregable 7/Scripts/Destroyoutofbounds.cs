using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyoutofbounds : MonoBehaviour
{
    private float leftLim = 15f;

    void Update()
    {
        // Obstaculos cruza el limite derecho
        if (transform.position.x > leftLim)
        {
            Destroy(gameObject);
          
        }
    }
}
