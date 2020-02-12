using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTester : PlayerController
{
    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (!Mathf.Approximately(h, 0f))
        {
            if (h > 0f) Move(MoveDirection.Right, Input.GetKey(KeyCode.LeftShift) ? 2f : 1f);
            else Move(MoveDirection.Left, Input.GetKey(KeyCode.LeftShift) ? 2f : 1f);
        }

        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }
}
