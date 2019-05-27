using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UdpKit;
using UnityEngine.SceneManagement;
using System;
public class Menu : Bolt.GlobalEventListener
{
    //public class RoomProtocolToken : Bolt.IProtocolToken
    //{
    //    public String ArbitraryData;

    //    public void Read(UdpPacket packet)
    //    {
    //        ArbitraryData = packet.ReadString();
    //    }

    //    public void Write(UdpPacket packet)
    //    {
    //        packet.WriteString(ArbitraryData);
    //    }
    //}
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, Screen.width - 20, Screen.height - 20));

        if (GUILayout.Button("Start Server", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true)))
        {
            // START SERVER
            BoltLauncher.StartServer(UdpKit.UdpEndPoint.Parse("127.0.0.1:22000"));
        }

        if (GUILayout.Button("Start Client", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true)))
        {
            // START CLIENT
            BoltLauncher.StartClient();
        }

        GUILayout.EndArea();
    }
    //string serverAddress = "127.0.0.1";
    //int serverPort = 25000;
    //public override void BoltStartDone()
    //{
    //    if (BoltNetwork.isClient)
    //    {
    //        UdpEndPoint endPoint = new UdpEndPoint(UdpIPv4Address.Parse(serverAddress), (ushort)serverPort);

    //        RoomProtocolToken token = new RoomProtocolToken();
    //        token.ArbitraryData = "Room Token";

    //        BoltNetwork.Connect(endPoint, token);
    //    }
    //    else
    //    {
    //        BoltNetwork.LoadScene("Demo");
    //    }
    //}
    public override void BoltStartDone()
    {
        if (BoltNetwork.isServer)
        {
            BoltNetwork.LoadScene("Demo");
            print("端口号:  "+BoltRuntimeSettings.instance.debugStartPort);
        }
        else
        {
            BoltNetwork.Connect(UdpKit.UdpEndPoint.Parse("127.0.0.1:22000"));
        }
    }
}
