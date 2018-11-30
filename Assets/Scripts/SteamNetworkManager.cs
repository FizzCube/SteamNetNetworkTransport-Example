using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class SteamNetworkManager : NetworkManager {

    public Text conenctionList;

    public static TransportLayer telepathy;
    public static TransportLayer steam;

    public override void InitializeTransport()
    {
        telepathy = new TelepathyWebsocketsMultiplexTransport();
        steam = new SteamworksNetworkTransport();

        Transport.layer = steam;
    }

    private void Update()
    {
        string connections = "";

        foreach (var connection in NetworkServer.connections)
        {
            connections += connection.Value.connectionId + " : " + connection.Value.address + "\n";
        }
        conenctionList.text = connections;
    }



}
