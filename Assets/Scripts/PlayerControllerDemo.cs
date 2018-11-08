using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class PlayerControllerDemo : NetworkBehaviour {

    float speedMultiplier = 0.1f;

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        float controllerHorizontal = Input.GetAxis("Horizontal");
        float controllerVertical = Input.GetAxis("Vertical");

        transform.Translate(controllerHorizontal * speedMultiplier, controllerVertical * speedMultiplier, 0);

    }

}
