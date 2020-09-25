using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingPlane : MonoBehaviour
{
    private Animator m_animator; 

    void Start()
    {
        m_animator = GetComponent<Animator>();
        GlobalInputs.Instance.inputSystem.actionsAsset.Disable();      
    }

    public void StartFadeOutAnimation()
    {
        Debug.Log("Up");
        m_animator.SetBool("hello", true);
    }

    public void StopFadeOutAnimation()
    {
        m_animator.SetBool("hello", false);
    }

    public void FadeInToMenuEnded()
    {
        GlobalInputs.Instance.inputSystem.actionsAsset.Enable();
    }

    public void SlowFadeOutEnded()
    {
        
    }

    public void FadeOutCompleted()
    {
        
    }

    public void FadeInToGameWhiteEnded()
    {

    }
}
