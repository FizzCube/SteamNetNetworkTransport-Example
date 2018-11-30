using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using UnityEngine.UI;
using Mirror;

public class Controller : MonoBehaviour {

    public Text labelUser;
    public Dropdown dropdownSteamFriends;
    public Text ipAddress;

    List<CSteamID> friendSteamIDs = new List<CSteamID>();

	// Use this for initialization
	void Start () {
        if (SteamManager.Initialized)
        {
            //get My steam name
            if (labelUser)
            {
                labelUser.text = "Current Steam User: " + SteamFriends.GetPersonaName();
                
            }

            dropdownSteamFriends.ClearOptions();
            int friendCount = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
            
            for (int i = 0; i < friendCount; ++i)
            {
                CSteamID friendSteamId = SteamFriends.GetFriendByIndex(i, EFriendFlags.k_EFriendFlagImmediate);
                string friendName = SteamFriends.GetFriendPersonaName(friendSteamId);
                EPersonaState friendState = SteamFriends.GetFriendPersonaState(friendSteamId);

                Dropdown.OptionData option = new Dropdown.OptionData();
                option.text = friendName;
                if (friendState != EPersonaState.k_EPersonaStateOffline)
                {
                    dropdownSteamFriends.options.Add(option);
                    friendSteamIDs.Add(friendSteamId);
                }


            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Disconnect()
    {
        if (Transport.layer.ClientConnected())
        {
            SteamNetworkManager.singleton.StopClient();
        }
        
        if (Transport.layer.ServerActive())
        {
            SteamNetworkManager.singleton.StopHost();
        }
        
    }

    public void StartAsHost()
    {
        Transport.layer = SteamNetworkManager.steam;
        SteamNetworkManager.singleton.StartHost();
    }

    public void StartAsHostTelepathy()
    {
        Transport.layer = SteamNetworkManager.telepathy;
        SteamNetworkManager.singleton.StartHost();
    }

    public void StartAsClient()
    {
        Transport.layer = SteamNetworkManager.steam;
        Debug.Log("connect to friend index " + dropdownSteamFriends.value);
        Debug.Log("connect to friend steam ID " + friendSteamIDs[dropdownSteamFriends.value].ToString());
        SteamNetworkManager.singleton.networkAddress = friendSteamIDs[dropdownSteamFriends.value].ToString();
        SteamNetworkManager.singleton.StartClient();
    }

    public void StartAsClientTelepathy()
    {
        Transport.layer = SteamNetworkManager.telepathy;
        SteamNetworkManager.singleton.networkAddress = ipAddress.text;
        SteamNetworkManager.singleton.StartClient();
    }

}
