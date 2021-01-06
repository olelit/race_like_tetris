using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    const string SaveName = "points";

    public SaveState _state;
    public SaveState State 
    { get
        {
            if (_state == null)
                Load();
            return _state;
        }
        set { _state = value; }
    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Save()
    {
        PlayerPrefs.SetString(SaveName, Serialize.Serializer(State));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(SaveName))
        {
            State = Serialize.Deserialize<SaveState>(PlayerPrefs.GetString(SaveName));
        }
        else
        {
            State = new SaveState();
            Save();
        }
    }

    public void Reset()
    {
        State.Point = 0;
    }
}
