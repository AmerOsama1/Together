using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Obstacle2 : MonoBehaviourPunCallbacks
{
    public Transform shotPos;
    public GameObject Ball;
    public float Force = 20f;
    private GameObject pref;
    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        if (Ball == null || shotPos == null)
        {
            Debug.LogError("Ball or shotPos is not assigned in the Inspector.");
            return;
        }
        InvokeRepeating("ON", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ON()
    {
        if (view.IsMine)
        {
            pref = PhotonNetwork.Instantiate(Ball.name, shotPos.position, shotPos.rotation);
            if (pref == null)
            {
                Debug.LogError("Failed to instantiate Ball.");
                return;
            }
            
            Rigidbody rb = pref.GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.LogError("Rigidbody component is missing on the instantiated Ball.");
                return;
            }

            rb.AddForce(pref.transform.forward * Force, ForceMode.Impulse);
            // DestroyOnNetwork();
        }
    }

    // public void DestroyOnNetwork()
    // {
    //     if (pref == null)
    //     {
    //         Debug.LogError("Cannot destroy a null object.");
    //         return;
    //     }

    //     GetComponent<PhotonView>().RPC("NetworkDestroy", RpcTarget.AllBuffered);
    // }

    // [PunRPC]
    // private void NetworkDestroy()
    // {
    //     if (pref != null)
    //     {
    //         Destroy(pref, 5f);
    //     }
    // }
}
