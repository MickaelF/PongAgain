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

    private bool m_waiting = false;
    private float m_duration = 0.0f;

    void Awake()
    {
        m_input = GetComponent<PlayerInput>();
        GameParameters.playerInput[m_input.playerIndex] = m_input;
        GameParameters.devices.Add(m_input.devices[0]);
        if (GameParameters.DeviceListUpdate != null)
            GameParameters.DeviceListUpdate();
    }

    void Update()
    {
        if (m_waiting && (m_duration += Time.deltaTime) >= 0.10f)
            m_waiting = false;   
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (PlayerMoved != null && !m_waiting)
        {
            PlayerMoved(ctx.ReadValue<Vector2>());
            m_waiting = true;
            m_duration = 0.0f;
        }
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
