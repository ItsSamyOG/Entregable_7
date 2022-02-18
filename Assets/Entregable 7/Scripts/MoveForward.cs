using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5f; // La velocidad a la q va el Game Object

    void Update()
    {
        // desplazar el Game Object hacia la derecha
        transform.Translate(Vector3.right * speed * Time.deltaTime); 
    }
}
