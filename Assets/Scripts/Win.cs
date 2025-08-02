using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Win : MonoBehaviourPunCallbacks
{
    void Start()
    {
        // Initialize anything if needed
    }

    void Update()
    {
        // Handle any frame updates if needed
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Load the scene for all players in the room
            PhotonNetwork.LoadLevel("GameLobby");
        }
    }
}
