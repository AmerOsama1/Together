using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCam : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        Invoke ("ss",8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ss(){
        cam.SetActive(true);
    }
}
