using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text textServerConnection;
    [SerializeField] TMP_InputField inputFieldRoomCode;
    [SerializeField] GameObject connectionIcon;
    [SerializeField] Sprite connectedSprite;
    [SerializeField] Color connectedColor;
    [SerializeField] Sprite disconnectedSprite;
    [SerializeField] Color disconnectedColor;

    Image connectionImage;

    // Start is called before the first frame update
    void Start()
    {
        connectionImage = connectionIcon.GetComponent<Image>();

        connectionImage.sprite = disconnectedSprite;
        connectionImage.color = disconnectedColor;
        textServerConnection.text = "Connecting to server";

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        textServerConnection.text = "Joining lobby";

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        textServerConnection.text = "Joined lobby";
        connectionImage.sprite = connectedSprite;
        connectionImage.color = connectedColor;

        this.CreateRoom();
    }

    public void CreateRoom()
    {
        if(!string.IsNullOrEmpty(inputFieldRoomCode.text))
        {
            textServerConnection.text = $"Creating room ({inputFieldRoomCode.text})";
            PhotonNetwork.CreateRoom(inputFieldRoomCode.text);
        }
            
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        textServerConnection.text = $"Failed to create room ({inputFieldRoomCode.text})";
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        textServerConnection.text = $"Created room ({inputFieldRoomCode.text})";
    }
}
