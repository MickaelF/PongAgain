﻿using System.Collections;
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
        m_animator.SetBool("FadeOut", true);
    }

    public void StopFadeOutAnimation()
    {
        m_animator.SetBool("FadeOut", false);
        m_animator.Play("Base Layer.Transparent");
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
