using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class GlobalInputs : MonoBehaviour
{
    public static GlobalInputs Instance = null; 
    public InputSystemUIInputModule inputSystem;
    void Awake()
    {
        Instance = this;
    }
}
