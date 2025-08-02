using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Ping : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI PingText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PingText.text=PhotonNetwork.GetPing().ToString("0");
    }
}
