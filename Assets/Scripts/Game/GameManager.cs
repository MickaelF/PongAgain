using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    void Start()
    {
        // Instancier le prefab du joueur
        // Ajouter un PlayerInput; 
        // Copier le PlayerInput du joueur
        // Supprimer l'objet contenant le playerinput d'origine.
        for (int i = 0; i < GameParameters.playerNumberSelected; ++i)
        {
            var go = GameObject.Instantiate(Resources.Load<GameObject>("Characters/" + GameParameters.characterSelected[i]));
            var pi = go.AddComponent<PlayerInput>();
            pi = GameParameters.playerInput[i];
            DestroyImmediate(GameParameters.playerInput[i]);
        }       
    }

    void Update()
    {
        
    }
}
