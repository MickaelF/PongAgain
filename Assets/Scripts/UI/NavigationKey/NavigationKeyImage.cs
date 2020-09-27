using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationKeyImage : MonoBehaviour
{
    private Image m_key;
    public Sprite sprite
    {
        set
        {
            m_key.sprite = value;
        }
    }
    private NavigationKey m_parent;
    void Awake()
    {
        m_key = GetComponent<Image>();
        m_parent = GetComponentInParent<NavigationKey>();
    }

    public void OnAnimationEnded()
    {
        m_key.sprite = m_parent.GetNextSprite();
    }

    public void ResetAlpha()
    {
        Color c = m_key.color;
        c.a = 1.0f;
        m_key.color = c;
    }
}
