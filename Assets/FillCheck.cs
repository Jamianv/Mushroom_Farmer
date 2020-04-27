using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillCheck : MonoBehaviour
{
    public GameObject Dirt;
    int count = 0;
    private void OnCollisionEnter(Collision collision)
    {
        //checking for collisions with dirt will probably be changed to material
        //for differnet things like grains straw etc.
        if (collision.collider.tag == "dirt")
        {
            //If weve gotten one "piece" of dirt enable dirtfill object renderer and destroy dirt object
            if (count == 0)
            {
                Debug.Log("touched dirt");
                Destroy(collision.gameObject);
                Renderer renderer = Dirt.GetComponent<Renderer>();
                renderer.enabled = true;                
            }
            //if we've gotten two pieces scale the dirtfill object and shift it up
            if (count == 1)
            {
                Destroy(collision.gameObject);
                Transform dTransform = Dirt.GetComponent<Transform>();
                dTransform.localScale += new Vector3(0, 0.25f, 0);
                dTransform.position += new Vector3(0, 0.2f, 0);
            }
            //scale the dirt up and shift up again
            if (count == 2)
            {
                Destroy(collision.gameObject);
                Transform dTransform = Dirt.GetComponent<Transform>();
                dTransform.localScale += new Vector3(0, 0.25f, 0);
                dTransform.position += new Vector3(0, 0.2f, 0);
            }
            if (count < 3)
            {
                count++;
            }

        }
    }
}
