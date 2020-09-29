using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputProxy : MonoBehaviour
{
    private PlayerInput m_input = null; 
    public event System.Action<Vector2> PlayerMoved;
    public event System.Action PlayerAccept;
    public event System.Action PlayerDecline;
    public event System.Action DeviceRemoved;

    void Awake()
    {
        m_input = GetComponent<PlayerInput>();
        if (m_input.playerIndex == 0)
            GameParameters.playerOneInput = m_input;
        else 
            GameParameters.playerTwoInput = m_input;
        GameParameters.devices.Add(m_input.devices[0]);
        if (GameParameters.DeviceListUpdate != null)
            GameParameters.DeviceListUpdate();
    }

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

    void OnDestroy()
    {
        if (GetComponent<PlayerInput>().devices.Count <= 0)
            return;

        GameParameters.RemoveDevice(GetComponent<PlayerInput>().devices[0]);
    }
}
