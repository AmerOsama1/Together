using System.Collections;
using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    public On_Off_Rag onR;
private GameObject Player;
    void Start()
    {
        // onR=GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<On_Off_Rag>();
    }

    void Update()
    {
        
    }

   
     void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
        {  
          onR=other.GetComponentInChildren<On_Off_Rag>();
          if(onR!=null){
            onR.EnableRagdoll();
          }
          Player=other.gameObject;
          Player.GetComponent<Movement>().enabled=false;
            StartCoroutine(SwitchBackToNormal(1.5f));
        }
   }

    IEnumerator SwitchBackToNormal(float delay)
    {
        yield return new WaitForSeconds(delay);
        onR.DisableRagdoll();
          Player.GetComponent<Movement>().enabled=true;

    }
}
