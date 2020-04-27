using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script allows you to pickup drop and throw an object
public class PickupObject : MonoBehaviour
{
    public float throwForce = 600;
    Vector3 objectPos;
    float distance;
    public float distanceThres = 5f;

    public GameObject item;
    public GameObject tempParent;
    bool isHolding = false;
    bool clicked = false;
    bool grabOne = false;
    void Update()
    {
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        
        //make sure object isnt too far away if it is drop object
        if (distance >= distanceThres) 
        {
            isHolding = false;
            Debug.Log("isHolding false from distance");
        }
        //this is what happens if we;ve grabbed the object
        if (isHolding == true)
        {
            //set velocity and rotation to zero stops object moving when grabbed
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            //"grab the item" set objects parent to tempParent 
            item.transform.SetParent(tempParent.transform);

            //"Throw" the object addforce to its rigidbody
            if (Input.GetMouseButtonDown(1))
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
                Debug.Log("isHolding false from Throw");
            }
        }
        //"drop" the object
        else 
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }             
    }
    void OnMouseOver()
    {
        //"grab" the object by pressing the left mouse button
        if (Input.GetMouseButtonDown(0) && !isHolding && !grabOne)
        {
            Debug.Log("pressed key");
            if (distance <= distanceThres)
            {
                isHolding = true;
                item.GetComponent<Rigidbody>().useGravity = false;
                item.GetComponent<Rigidbody>().detectCollisions = true;
                Debug.Log("isHolding true MB down and !isholding");

            }
            
        }
        //"hold" the item after you let off the mouse button
        if (Input.GetMouseButtonUp(0) && isHolding) {
            Debug.Log("clicked true");
            clicked = true;
            grabOne = true;
        }
        //"drop" the object by pressing the mouse button again
        if (Input.GetMouseButtonDown(0) && clicked && isHolding) {
            isHolding = false;
            clicked = false;
            grabOne = false;
            Debug.Log("isholding false & clicked false");
        }
    }
}
