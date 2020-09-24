using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputProxy : MonoBehaviour
{
    public event System.Action<Vector2> PlayerMoved; 
    public event System.Action PlayerAccept;
    public event System.Action PlayerDecline;

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (PlayerMoved != null)
            PlayerMoved(ctx.ReadValue<Vector2>());
    }

    public void OnAccept(InputAction.CallbackContext ctx)
    {
        if (PlayerAccept != null)
            PlayerAccept();
    }

    public void OnDecline(InputAction.CallbackContext ctx)
    {
        if (PlayerDecline != null)
            PlayerDecline();
    }
}
