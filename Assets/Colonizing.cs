using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colonizing : MonoBehaviour
{
    Material shader;
    float alpha = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        shader = gameObject.GetComponent<Renderer>().material;    
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha >= -1f)
        {
            alpha -= 0.01f * Time.deltaTime;
        }
        shader.SetFloat("Vector1_F53F4417", alpha);
        //Shader.SetGlobalFloat("Vector1_F53F4417", -1f);
    }
}
