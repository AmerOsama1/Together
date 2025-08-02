using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviour
{
    public GameObject playerPrefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        SpawnPlayerObject();
    }

  void SpawnPlayerObject()
{
    if (playerPrefab == null)
    {
        Debug.LogError("Player prefab is null. Make sure it is assigned in the Inspector.");
        return;
    }

    Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

    Debug.Log("Spawning player at: " + randomPosition);

    PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
}

   
}
