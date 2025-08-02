using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlatForm : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
  public int delay;
    // Start is called before the first frame update
    void Start()
    {

    }


        public void DestroyOnNetwork()
{
    GetComponent<MeshRenderer>().material.color=Color.red;
GetComponent<PhotonView>().RPC("NetworkDestroy", RpcTarget.AllBuffered);
}





[PunRPC]
private void NetworkDestroy()
{
Destroy(gameObject,delay);
}




void OnTriggerEnter(Collider other)
{
    if(other.CompareTag("Player")){
        DestroyOnNetwork();
    }
}
}

 
