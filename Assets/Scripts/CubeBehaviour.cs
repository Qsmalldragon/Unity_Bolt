using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : Bolt.EntityEventListener<ICubeState>
{
    float resetColorTime;
    Renderer renderer;
    public override void Attached()
    {
        state.SetTransforms(state.CubeTransform, transform);

        if (entity.isOwner)
        {
            state.CubeColor = new Color(Random.value, Random.value, Random.value);
        }

        //在Bolt Assets中配置的属性
        state.AddCallback("CubeColor", ColorChanged);

        renderer = GetComponent<Renderer>();


      
    }
    public override void SimulateOwner()
    {
        var speed = 10f;
        var movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) { movement.z += 1; }
        if (Input.GetKey(KeyCode.S)) { movement.z -= 1; }
        if (Input.GetKey(KeyCode.A)) { movement.x -= 1; }
        if (Input.GetKey(KeyCode.D)) { movement.x += 1; }

        if (movement != Vector3.zero)
        {
            transform.position = transform.position + (movement.normalized * speed * BoltNetwork.frameDeltaTime);
        }

    }
    void ColorChanged()
    {
        GetComponent<Renderer>().material.color = state.CubeColor;
    }
}
