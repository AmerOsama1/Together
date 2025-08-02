using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class des : MonoBehaviourPunCallbacks
{
        public int delay;
    // Start is called before the first frame update
    void Start()
    {
                    DestroyOnNetwork();

    }

    // Update is called once per frame
    void Update()
    {
    }
        public void DestroyOnNetwork()
{
GetComponent<PhotonView>().RPC("NetworkDestroy", RpcTarget.AllBuffered);
}
[PunRPC]

private void NetworkDestroy()
{
Destroy(gameObject,delay);
}
}
