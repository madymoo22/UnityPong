using Unity.Netcode;
using UnityEngine;

public class NetworkUI : MonoBehaviour
{
    private void OnGUI()
    {
        if (NetworkManager.Singleton == null) return;

        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            if (GUI.Button(new Rect(20, 20, 150, 40), "Start Host"))
                NetworkManager.Singleton.StartHost();

            if (GUI.Button(new Rect(20, 70, 150, 40), "Start Client"))
                NetworkManager.Singleton.StartClient();
        }
        else
        {
            string mode = NetworkManager.Singleton.IsHost ? "HOST"
                        : NetworkManager.Singleton.IsServer ? "SERVER"
                        : "CLIENT";

            GUI.Label(new Rect(20, 20, 200, 40), "Running: " + mode);
        }
    }
}
