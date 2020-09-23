using System.Collections.Generic;
using UnityEngine;

public class CharactersGlobal
{
    public static CharactersGlobal instance = new CharactersGlobal();
    private List<CharacterData> m_characters = new List<CharacterData>();
    public List<CharacterData> characters
    {
        get { return m_characters; }
    }

    public int randomCharacter { get { return Random.Range(0, m_characters.Count); } }
    private const string m_characterFilePath = "Characters/characterSheets";

    private CharactersGlobal()
    {
        TextAsset csvFile = Resources.Load<TextAsset>(m_characterFilePath);
        string[] lines = csvFile.text.Split('\n');
        for (int i = 1; i < lines.Length; ++i)
        {
            string[] values = lines[i].Split(',');
            string name = values[0].Replace("\"", "");
            int rebound = int.Parse(values[1].Replace("\"", ""));
            int speed = int.Parse(values[2].Replace("\"", ""));
            int length = int.Parse(values[3].Replace("\"", ""));
            m_characters.Add(new CharacterData(name, length, rebound, speed));
        }
    }

    public List<string> GetCharacterNames()
    {
        List<string> names = new List<string>();
        foreach (CharacterData data in m_characters)
            names.Add(data.name);
        return names;
    }

    public int Count()
    {
        return m_characters.Count;
    }

    public CharacterData GetCharacter(int index)
    {
        return m_characters[index];
    }
}
