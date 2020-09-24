using System.Collections;
using System.Collections.Generic;
using SimplePong.Controller;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.Switch;
using UnityEngine.InputSystem.XInput;
using UnityEngine.InputSystem.DualShock;

// TODO Correct this class when the new controller handler is created.
public class NavigationKeyInstructionHandler : MonoBehaviour
{
    private InputDevice m_previousDevice = null;
    private UserControl m_actions;
    public enum Controller { Keyboard, DualShock, Switch, Xbox };
    private Controller m_currentController;

    [SerializeField] private NavigationKey m_backKey = null;
    [SerializeField] private NavigationKey m_defaultKey = null;
    [SerializeField] private NavigationKey m_selectKey = null;
    [SerializeField] private NavigationKey m_settingsKey = null;

    private List<NavigationKey> m_keys;

    private bool m_displayLastUsed = true;
    public bool displayLastUsed
    {
        get { return m_displayLastUsed; }
        set
        {
            if (m_displayLastUsed == value)
                return;
            m_displayLastUsed = value;
            if (!m_displayLastUsed)
                UseRegisteredController();
            else
                UseLastUsedController(true);
        }
    }

    void Start()
    {
        m_actions = new UserControl();
        m_keys = new List<NavigationKey>();
        if (m_selectKey != null)
            m_keys.Add(m_selectKey);
        if (m_defaultKey != null)
            m_keys.Add(m_defaultKey);
        if (m_backKey != null)
            m_keys.Add(m_backKey);
        if (m_settingsKey != null)
            m_keys.Add(m_settingsKey);

        InitializeKeys();
        if (Gamepad.all.Count > 0)
            SetCurrentDevice(RetrieveController(Gamepad.all[0]));
        else
            SetCurrentDevice(Controller.Keyboard);

        // ControllerHandler handler = ControllerHandler.instance;
        // handler.UserCreated += UpdateControllerKeys;
        // handler.UserRemoved += UpdateControllerKeys;
    }

    void Update()
    {
        if (m_displayLastUsed)
        {
            UseLastUsedController(false);
        }
    }

    private void SetCurrentDevice(Controller controller)
    {
        foreach (NavigationKey key in m_keys)
            key.SetUniqueControllerType(controller);
    }

    private void DisplayEveryControllerKey()
    {
        List<Controller> controllers = new List<Controller>();
        foreach (Controller type in System.Enum.GetValues(typeof(Controller)))
            controllers.Add(type);

        foreach (NavigationKey key in m_keys)
            key.SetControllerTypes(controllers);
    }

    private void UseLastUsedController(bool force)
    {
        InputDevice currentDevice = null;
        if (Keyboard.current.wasUpdatedThisFrame)
            currentDevice = Keyboard.current;
        else if (Gamepad.current != null && Gamepad.current.wasUpdatedThisFrame)
            currentDevice = Gamepad.current;

        if (!force && (currentDevice == null || currentDevice == m_previousDevice))
            return;

        SetCurrentDevice(RetrieveController(currentDevice));
        m_previousDevice = currentDevice;
    }

    private void UseRegisteredController()
    {
        DisplayEveryControllerKey();
    }

    private void UpdateControllerKeys(InputUser user)
    {
        // ControllerHandler handler = ControllerHandler.instance;
        // if (handler.userCount == 0)
        //     DisplayEveryControllerKey();
        // else
        // {
        //     List<Controller> registeredController = new List<Controller>();
        //     foreach (var device in ControllerHandler.instance.devices)
        //     {
        //         Controller type = RetrieveController(device);
        //         if (!registeredController.Contains(type))
        //             registeredController.Add(type);
        //     }
        //     if (registeredController.Count == 1)
        //         SetCurrentDevice(registeredController[0]);
        //     else
        //         foreach (NavigationKey key in m_keys)
        //             key.SetControllerTypes(registeredController);
        // }
    }

    private Controller RetrieveController(InputDevice device)
    {
        if (device is Keyboard)
        {
            return Controller.Keyboard;
        }
        else
        {
            if (device is SwitchProControllerHID)
            {
                return Controller.Switch;
            }
            else if (device is DualShock3GamepadHID || device is DualShock4GamepadHID)
            {
                return Controller.DualShock;
            }
            else
            {
                return Controller.Xbox;
            }
        }
    }

    private void InitializeKeys()
    {

        // foreach (var controller in System.Enum.GetValues(typeof(Controller)))
        // {
        //     string specificPath = "";
        //     string defaultPath = "<Gamepad>/";
        //     AbstractController controllerPath = null;
        //     switch (controller)
        //     {
        //         case Controller.Keyboard:
        //             specificPath = "<Keyboard>/";
        //             defaultPath = specificPath;
        //             KeyboardController kc = new KeyboardController();
        //             kc.InitializePaths(Keyboard.current);
        //             controllerPath = kc;
        //             break;
        //         case Controller.DualShock:
        //             specificPath = "<DualShockGamepad>/";
        //             controllerPath = new DualShockController();
        //             break;
        //         case Controller.Switch:
        //             specificPath = "<SwitchProControllerHID>/";
        //             controllerPath = new SwitchController();
        //             break;
        //         case Controller.Xbox:
        //             specificPath = "<XInputController>/";
        //             controllerPath = new XboxController();
        //             break;
        //     }

        //     foreach (var bind in m_actions.UI.Confirm.bindings)
        //     {
        //         if (bind.path.Contains(defaultPath) || bind.path.Contains(specificPath))
        //         {
        //             if (DefineKeySprite(bind.path, ref m_settingsKey, controllerPath, specificPath, defaultPath))
        //                 break;
        //         }
        //     }
        //     foreach (var bind in m_actions.UI.Submit.bindings)
        //     {
        //         if (bind.path.Contains(defaultPath) || bind.path.Contains(specificPath))
        //         {
        //             if (DefineKeySprite(bind.path, ref m_selectKey, controllerPath, specificPath, defaultPath))
        //                 break;
        //         }
        //     }
        //     foreach (var bind in m_actions.UI.Cancel.bindings)
        //     {
        //         if (bind.path.Contains(defaultPath) || bind.path.Contains(specificPath))
        //         {
        //             if (DefineKeySprite(bind.path, ref m_backKey, controllerPath, specificPath, defaultPath))
        //                 break;
        //         }
        //     }
        //     foreach (var bind in m_actions.UI.DefaultValue.bindings)
        //     {
        //         if (bind.path.Contains(defaultPath) || bind.path.Contains(specificPath))
        //         {
        //             if (DefineKeySprite(bind.path, ref m_defaultKey, controllerPath, specificPath, defaultPath))
        //                 break;
        //         }
        //     }
        // }
    }

    public void SetKeyVisibiltity(bool backKey, bool defaultKey, bool selectKey, bool settingsKey)
    {
        m_selectKey.gameObject.SetActive(selectKey);
        m_settingsKey.gameObject.SetActive(settingsKey);
        m_defaultKey.gameObject.SetActive(defaultKey);
        m_settingsKey.gameObject.SetActive(settingsKey);
    }

    private bool DefineKeySprite(string bindingPath, ref NavigationKey keyContainer, AbstractController controller, string specificPath, string defaultPath)
    {
        bool isSpecificPath = bindingPath.Contains(specificPath);
        string keyPath = (isSpecificPath) ? bindingPath.Remove(0, specificPath.Length) : bindingPath.Remove(0, defaultPath.Length);
        keyContainer.AddControllerSpriteDefinition(controller.type, Resources.Load<Sprite>(controller.KeyPathToSpritePath(keyPath)));
        return isSpecificPath;
    }
}
