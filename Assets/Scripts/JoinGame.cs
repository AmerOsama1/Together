using System.Collections;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class JoinGame : MonoBehaviourPunCallbacks
{
    public float timer = 60f;  // Set the starting time here
    public TextMeshProUGUI timerText;
    private PhotonView pv;
    public string[] Level;

    void Start()
    {
        pv = GetComponent<PhotonView>();

        PhotonNetwork.AutomaticallySyncScene = true;

        // If this is the master client, start the timer
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(TimerCoroutine());
        }
    }

    void Update()
    {
        timerText.text = Mathf.Max(timer, 0).ToString("0");
    }

    private IEnumerator TimerCoroutine()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer -= 1f;
            pv.RPC("UpdateTimer", RpcTarget.AllBuffered, timer);
        }

        if (PhotonNetwork.IsMasterClient)
        {
            int game = Random.Range(0,Level.Length);
            PhotonNetwork.LoadLevel(Level[game]);
            timer=30;
        }
    }

    [PunRPC]
    public void UpdateTimer(float newTime)
    {
        timer = newTime;
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            pv.RPC("UpdateTimer", RpcTarget.AllBuffered, timer);
        }
        else
        {
            pv.RPC("RequestTimer", RpcTarget.MasterClient);
        }
    }

    [PunRPC]
    public void RequestTimer()
    {
        pv.RPC("UpdateTimer", RpcTarget.AllBuffered, timer);
    }
}

