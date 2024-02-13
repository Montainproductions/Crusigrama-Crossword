using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Hint", order = 1)]
public class ScrObj_HintInfo : ScriptableObject
{

    public TextMeshProUGUI hint;

    public string answer;
}
