using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] private float m_angle = 90.0f;
    [SerializeField] private int m_radius = 50;

    [SerializeField] private Transform m_childrenParent = null;
    private float m_radianAngle;
    private int m_nbCharacters;
    private int m_selectedCharacter = 0;

    void Awake()
    {
        m_radianAngle = Mathf.Deg2Rad * m_angle;
        m_nbCharacters = CharactersGlobal.instance.characters.Count;
        int i = 0;
        foreach (var charact in CharactersGlobal.instance.characters)
        {
            var go = GameObject.Instantiate(Resources.Load<GameObject>("Prefab/Game/Characters/" + charact.name));
            go.transform.SetParent(m_childrenParent);
            go.transform.position = ComputeNextPosition(i);
            go.transform.Rotate(0.0f, m_angle * i, 0.0f, Space.Self);
            ++i;
        }
    }

    public void SetSelectedCharacter(int index)
    {
        m_childrenParent.Rotate(0.0f, (m_selectedCharacter - index) * m_angle, 0.0f, Space.Self);
        m_selectedCharacter = index;
    }

    private Vector3 ComputeNextPosition(int index)
    {
        Vector3 cameraPosition = transform.position;
        float x = m_radius * Mathf.Sin(m_radianAngle * index);
        float z = m_radius * Mathf.Cos(m_radianAngle * index);

        return new Vector3(cameraPosition.x + x, cameraPosition.y, cameraPosition.z + z);
    }
}
