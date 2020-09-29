using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Screen : MonoBehaviour
{
    protected static Screen m_currentScreen; 
    [SerializeField] protected Screen m_previousScreen = null; 
    [SerializeField] protected Screen m_nextScreen = null;

    public abstract void Display();
    protected virtual void HideCurrentScreen()
    {
        gameObject.SetActive(false);
    } 

    protected void GoToPreviousScreen()
    {
        if (!m_previousScreen)
            return;
            
        HideCurrentScreen();
        m_previousScreen.Display();
        m_currentScreen = m_previousScreen;
    }

    protected void GoToNextScreen()
    {
        if (!m_nextScreen)
            return;

        HideCurrentScreen(); 
        m_nextScreen.Display();
        m_currentScreen = m_nextScreen;
    }
    public static void StartListenToCancelAction()
    {
        GlobalInputs.Instance.inputSystem.cancel.action.started += CancelPressedAction;
    }
    public static void StopListenToCancelAction()
    {
        GlobalInputs.Instance.inputSystem.cancel.action.started -= CancelPressedAction;
    }

    public static void CancelPressedAction(InputAction.CallbackContext ctx)
    {
        m_currentScreen.OnCancelPressed();
    }

    public virtual void OnCancelPressed()
    { 
        GoToPreviousScreen();
    }
}
