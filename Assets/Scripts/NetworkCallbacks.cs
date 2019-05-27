using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[BoltGlobalBehaviour]
public class NetworkCallbacks :  Bolt.GlobalEventListener
{
    public override void SceneLoadLocalDone(string map)
    {
        // randomize a position
        var pos = new Vector3(Random.Range(-2, 2), 1, Random.Range(-2, 2));

        // 实例化自己
        BoltNetwork.Instantiate(BoltPrefabs.Cube, pos, Quaternion.identity);
    }
}
