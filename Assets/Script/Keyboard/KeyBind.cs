using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class KeyBind
{
    public static Dictionary<InputCode, KeyCode> dictBinds => _dictBinds;
    private static Dictionary<InputCode, KeyCode> _dictBinds;

    public KeyBind()
    {
        _dictBinds = new();
        //if (PlayerPrefs.HasKey(InputCode.KEY_UP.ToString()))
        //{
        //    Load();
        //}
        //else
        //{
        //    ResetAll();
        //}
    }
    public void Bind(InputCode inputCode, KeyCode keyCode)
    {
        if (_dictBinds.ContainsValue(keyCode))
        {
            Dictionary<InputCode, KeyCode> temp = new Dictionary<InputCode, KeyCode>(_dictBinds);

            foreach(KeyValuePair<InputCode,KeyCode> pair in temp)
            {
                if (pair.Value.Equals(keyCode))
                {
                    _dictBinds[pair.Key] = KeyCode.None;
                }
            }
        }
        _dictBinds[inputCode] = keyCode;
        PlayerPrefs.SetString(inputCode.ToString(), keyCode.ToString());
    }
    public List<InputCode> NoneBind()
    {
        List<InputCode> noneBinds = new();
        if (_dictBinds.ContainsValue(KeyCode.None))
        {
            Dictionary<InputCode, KeyCode> temp = new Dictionary<InputCode, KeyCode>(_dictBinds);

            foreach (KeyValuePair<InputCode, KeyCode> pair in temp)
            {
                if (pair.Value.Equals(KeyCode.None))
                {
                    noneBinds.Add(pair.Key);
                    PlayerPrefs.SetString(pair.Key.ToString(), pair.Value.ToString());
                }
            }
        }
        return noneBinds;
    }
    public void Load()
    {
        Bind(InputCode.KEY_UP, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_UP.ToString())));
        Bind(InputCode.KEY_DOWN, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_DOWN.ToString())));
        Bind(InputCode.KEY_LEFT, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_LEFT.ToString())));
        Bind(InputCode.KEY_RIGHT, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_RIGHT.ToString())));

        Bind(InputCode.KEY_JUMP, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_JUMP.ToString())));
        Bind(InputCode.KEY_RUN, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_RUN.ToString())));
        Bind(InputCode.KEY_SIT, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_SIT.ToString())));

        Bind(InputCode.KEY_BASIC, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_BASIC.ToString())));
        Bind(InputCode.KEY_SPECIAL, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_SPECIAL.ToString())));
        Bind(InputCode.KEY_PASSOVER, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_PASSOVER.ToString())));
        Bind(InputCode.KEY_TABLET, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_TABLET.ToString())));

        Bind(InputCode.KEY_ITEM1, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_ITEM1.ToString())));
        Bind(InputCode.KEY_ITEM2, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_ITEM2.ToString())));
        Bind(InputCode.KEY_ITEM3, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_ITEM3.ToString())));
        Bind(InputCode.KEY_ITEM4, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_ITEM4.ToString())));
        Bind(InputCode.KEY_ITEM5, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_ITEM5.ToString())));

        Bind(InputCode.KEY_SCAN, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_SCAN.ToString())));
        Bind(InputCode.KEY_ACTION, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_ACTION.ToString())));
        Bind(InputCode.KEY_LIGHT, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_LIGHT.ToString())));
        Bind(InputCode.KEY_THROW, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_THROW.ToString())));
        Bind(InputCode.KEY_RELOAD, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_RELOAD.ToString())));
        Bind(InputCode.KEY_ESC, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(InputCode.KEY_ESC.ToString())));

    }
    public void ResetAll()
    {
        Bind(InputCode.KEY_UP,          KeyCode.W);
        Bind(InputCode.KEY_DOWN,        KeyCode.S);
        Bind(InputCode.KEY_LEFT,        KeyCode.A);
        Bind(InputCode.KEY_RIGHT,       KeyCode.D);

        Bind(InputCode.KEY_JUMP,        KeyCode.Space);
        Bind(InputCode.KEY_RUN,         KeyCode.LeftShift);
        Bind(InputCode.KEY_SIT,         KeyCode.LeftControl);

        Bind(InputCode.KEY_BASIC,       KeyCode.Mouse0);
        Bind(InputCode.KEY_SPECIAL,     KeyCode.Mouse1);
        Bind(InputCode.KEY_PASSOVER,    KeyCode.Mouse2);
        Bind(InputCode.KEY_TABLET,      KeyCode.Tab);

        Bind(InputCode.KEY_ITEM1,       KeyCode.Alpha1);
        Bind(InputCode.KEY_ITEM2,       KeyCode.Alpha2);
        Bind(InputCode.KEY_ITEM3,       KeyCode.Alpha3);
        Bind(InputCode.KEY_ITEM4,       KeyCode.Alpha4);
        Bind(InputCode.KEY_ITEM5,       KeyCode.Alpha5);

        Bind(InputCode.KEY_SCAN,        KeyCode.Q);
        Bind(InputCode.KEY_ACTION,      KeyCode.F);
        Bind(InputCode.KEY_LIGHT,       KeyCode.T);
        Bind(InputCode.KEY_THROW,       KeyCode.G);
        Bind(InputCode.KEY_RELOAD,      KeyCode.R);
        Bind(InputCode.KEY_ESC,         KeyCode.Escape);
    }
}
