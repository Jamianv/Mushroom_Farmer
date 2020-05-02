using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    float distance = 5f;
    public float thrust = 600f;
    
    public Camera mainCam;

    GameObject hitObj;
    Vector3 objectPos;
    RaycastHit hit;
    bool isHolding = false;

    public LayerMask grabMask;
    
    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, distance, grabMask))
        {
            //Debug.Log(hit.transform.name);
            
            //grab the item
            if(hit.collider.gameObject && Input.GetMouseButtonDown(0) && !isHolding)
            {
                hitObj = hit.collider.gameObject;
                isHolding = true;
            }
            //drop the item
            else if (hit.collider.gameObject && Input.GetMouseButtonDown(0) && isHolding)
            {
                isHolding = false;
                drop();
            }
            //throw the item
            else if(hit.collider.gameObject && Input.GetMouseButtonDown(1) && isHolding)
            {
                hit.rigidbody.AddForce(mainCam.transform.forward * thrust, ForceMode.Impulse);
                isHolding = false;
                drop();
            }
            
        }

        if (isHolding && hitObj != null)
        {
            grab();
        }
        else
        {
            isHolding = false;
        }
    }

    void grab()
    {
        //Debug.Log(hitObj.transform.name);
        hitObj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        hitObj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        hitObj.GetComponent<Rigidbody>().useGravity = false;
        hitObj.GetComponent<Rigidbody>().detectCollisions = true;

        hitObj.transform.SetParent(mainCam.transform);
    }
    public void drop()
    {
        objectPos = hitObj.transform.position;
        hitObj.transform.SetParent(null);
        hitObj.GetComponent<Rigidbody>().useGravity = true;
        hitObj.transform.position = objectPos;
    }
}
