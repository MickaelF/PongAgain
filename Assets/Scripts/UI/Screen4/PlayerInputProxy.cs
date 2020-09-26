using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputProxy : MonoBehaviour
{
    public event System.Action<Vector2> PlayerMoved;
    public event System.Action PlayerAccept;
    public event System.Action PlayerDecline;
    public event System.Action DeviceRemoved;

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (ctx.started && PlayerMoved != null)
            PlayerMoved(ctx.ReadValue<Vector2>());
    }

    public void OnAccept(InputAction.CallbackContext ctx)
    {
        if (ctx.started && PlayerAccept != null)
            PlayerAccept();
    }

    public void OnDecline(InputAction.CallbackContext ctx)
    {
        if (ctx.started && PlayerDecline != null)
            PlayerDecline();
    }

    public void OnDeviceLost(PlayerInput input)
    {
        if (DeviceRemoved != null)
            DeviceRemoved();
    }
}
