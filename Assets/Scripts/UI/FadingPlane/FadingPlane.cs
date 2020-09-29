using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        GlobalInputs.Instance.inputSystem.actionsAsset.Disable();
        GameParameters.playerOneInput.gameObject.SetActive(false);
        if (GameParameters.playerTwoInput != null)
        GameParameters.playerTwoInput.gameObject.SetActive(false);
    }

    public void FadeOutCompleted()
    {
        SceneManager.LoadScene("Scenes/GameScene");
    }
}
