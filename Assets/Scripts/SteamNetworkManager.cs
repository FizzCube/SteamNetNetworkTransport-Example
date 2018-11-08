using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SteamNetworkManager : NetworkManager {

    public override void InitializeTransport()
    {
        Transport.layer = new SteamworksNetworkTransport();
    }



}
