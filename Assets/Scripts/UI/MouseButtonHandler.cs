using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseButtonHandler : MonoBehaviour, IPointerEnterHandler
{    
    public void OnPointerEnter(PointerEventData data)
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
}
