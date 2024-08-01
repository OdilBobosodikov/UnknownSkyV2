using System.Collections;
using System.Collections.Generic;
using FishNet;
using FishNet.Transporting;
using Unity.VisualScripting;
using UnityEngine;

public enum ConnectionType
{
    Host,
    Client,
}
public class ConnectionHandler : MonoBehaviour
{
    public ConnectionType ConnectionType;
    #if UNITY_EDITOR
    void OnEnable()
    {
        InstanceFinder.ClientManager.OnClientConnectionState += OnClientConnectionState;
    }

    void OnDisable()
    {
        InstanceFinder.ClientManager.OnClientConnectionState -= OnClientConnectionState;
    }
    private void OnClientConnectionState(ClientConnectionStateArgs args)
    {
        if(args.ConnectionState == LocalConnectionState.Stopping)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    #endif
    void Start()
    {
        #if UNITY_EDITOR
        if(ParrelSync.ClonesManager.IsClone())
        {
            InstanceFinder.ClientManager.StartConnection();
        }   
        else
        {
            if(ConnectionType == ConnectionType.Host)
            {
                InstanceFinder.ServerManager.StartConnection();
                InstanceFinder.ClientManager.StartConnection();
            }
            else
            {
                InstanceFinder.ClientManager.StartConnection();
            }
        }
        #endif
    }
}
