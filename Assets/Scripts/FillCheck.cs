using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillCheck : MonoBehaviour
{
    public GameObject Dirt0;
    public GameObject Dirt1;
    public GameObject Dirt2;
    public GameObject Dirt3;
    public Camera MainCam;
    

    int count = 0;
    private void OnCollisionEnter(Collision collision)
    {
        
        //checking for collisions with dirt will probably be changed to material
        //for differnet things like grains straw etc.
        if (collision.collider.tag == "dirt")
        {
            Renderer renderer0 = Dirt0.GetComponent<Renderer>();
            Renderer renderer1 = Dirt1.GetComponent<Renderer>();
            Renderer renderer2 = Dirt2.GetComponent<Renderer>();
            Renderer renderer3 = Dirt3.GetComponent<Renderer>();
            //If weve gotten one "piece" of dirt enable dirtfill object renderer and destroy dirt object
            if (count == 0)
            {
                //Debug.Log("touched dirt");
                
                Destroy(collision.gameObject);
                renderer0.enabled = true;
            }
            
            if (count == 1)
            {
                
                Destroy(collision.gameObject);
                renderer0.enabled = false;
                renderer1.enabled = true;
            }
            
            if (count == 2)
            {
                Destroy(collision.gameObject);
                renderer1.enabled = false;
                renderer2.enabled = true;
            }
            if (count == 3)
            {
                Destroy(collision.gameObject);
                renderer2.enabled = false;
                renderer3.enabled = true;
            }
            if (count < 4)
            {
                count++;
            }

        }
    }
}
