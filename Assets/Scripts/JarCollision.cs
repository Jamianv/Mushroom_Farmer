using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Jars")
        {
            Debug.Log("touched jar");
            //Destroy(gameObject);
        }
    }
}
