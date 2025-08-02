using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayer : MonoBehaviour
{
    public GameObject PlayerPrefab;
   public Transform[] pos ;
   
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(PlayerPrefab.name,pos[Random.Range(0,pos.Length)].position,pos[0].transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
