using Mirror;

namespace COTL_Multiplayer.Manager;

public class NetworkManagerCOTL : NetworkManager
{
    public new static NetworkManagerCOTL singleton => (NetworkManagerCOTL)NetworkManager.singleton;

    public void OnServerInitialized()
    {
        if (Plugin.Instance)
            Plugin.Instance.Logger.LogInfo("Server initialized!");
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        if (Plugin.Instance)
            Plugin.Instance.Logger.LogInfo("Player added!");
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        if (Plugin.Instance)
            Plugin.Instance.Logger.LogInfo("Player removed!");

        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }
}