using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    { if(other.CompareTag("Player")){
         other.transform.SetParent(this.transform);
    }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")){
                     other.transform.SetParent(null);

        }
    }
}
