using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField createRoom;
    public TMP_InputField inputRoom;
    public void CreateRoom(){
        PhotonNetwork.CreateRoom(createRoom.text);
    }
    public void joinRoom(){
        PhotonNetwork.JoinRoom(inputRoom.text);
    }

    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("GameLobby");
    }

  
}
