﻿using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomCtrl : MonoBehaviourPunCallbacks
{

    private bool GameReady;
    private byte nextTeam = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Photon Callbacks

    public override void OnJoinedRoom()
    {
        
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
            if (PhotonNetwork.IsMasterClient)
            {
                var propsToSet = new ExitGames.Client.Photon.Hashtable() { { "Team", nextTeam } };
                newPlayer.SetCustomProperties(propsToSet);
                nextTeam = (nextTeam == 1) ? (byte)2 : (byte)1;               
                
            }
           
            if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers && !GameReady)
            {
                UIManager.Instance.ShowProgress("Match Ready");
                GameReady = true;
                if (PhotonNetwork.IsMasterClient)
                    PhotonNetwork.LoadLevel("Map A");
            }        
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {

    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        Debug.Log("El Master Cliente Se fue \nEl nuevo Master Client es :" + newMasterClient.NickName);     
;    }
    public override void OnLeftRoom()
    {
        UIManager.Instance.GoToLobby();
    }

    #endregion

    #region private methods

    #endregion

    #region public Methods

    public void LeaveRoom() // Retorna al lobby
    {
        PhotonNetwork.LeaveRoom();
    }

    #endregion


}
