using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    private void Start()
    {
        //PhotonNetwork.Instantiate(playerPrefab.name, this.transform.position, Quaternion.identity);
        Instantiate(playerPrefab, this.transform.position, this.transform.rotation);
    }
}
