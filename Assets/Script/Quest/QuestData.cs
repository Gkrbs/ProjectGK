using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "Scriptable Object/QuestData", order = int.MaxValue)]
public class QuestData : ScriptableObject
{
    public int clearCount = 0;
    public string questId = "";
    public string name = "";
    public string info = "";
}
