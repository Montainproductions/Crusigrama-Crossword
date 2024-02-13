using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sc_HintInfo : MonoBehaviour
{
    public TextMeshProUGUI hint;

    public string answer;

    [SerializeField]
    private GameObject[] letterPositions;

    public void ActivateLetters()
    {
        for (int i = 0; i < letterPositions.Length; i++)
        {
            letterPositions[i].SetActive(true);
        }
    }
}
