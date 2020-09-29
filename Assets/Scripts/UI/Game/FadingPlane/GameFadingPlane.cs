using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFadingPlane : MonoBehaviour
{
    [SerializeField] private Text m_gameModeName = null; 
    
    public void FadeToWhiteEnded()
    {
        m_gameModeName.gameObject.SetActive(true);
    }
}
