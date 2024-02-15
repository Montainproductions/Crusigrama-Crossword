using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sc_LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] allTextSpots;

    [SerializeField]
    private GameObject bigButton, bigButtonOgPos;

    [SerializeField]
    private TextMeshProUGUI bigTextComponent;

    [SerializeField]
    private Sc_HintInfo hintInfo;

    private string answer;

    // Start is called before the first frame update
    void Start()
    {
        bigButton.SetActive(false);
    }

    public void SetAllTextToInvis()
    {
        for(int i = 0; i < allTextSpots.Length; i++)
        {
            allTextSpots[i].SetActive(false);
        }
    }

    public void OpenButton(Sc_HintInfo hintInfo)
    {
        bigButton.SetActive(true);

        this.hintInfo = hintInfo;
        bigTextComponent = hintInfo.hint;
        answer = hintInfo.answer;
    }

    public void CloseButton()
    {
        hintInfo = null;
        bigTextComponent = null;
        answer = null;

        bigButton.SetActive(false);
    }

    public void CheckAnswer(TextMeshProUGUI playerAnswer)
    {
        if(answer != playerAnswer.text)
        {
            ///Return ScreenShake
            ///For 3-5 seconds randomly choose a direction in the x,y cordtinates and slightly move the game object Biggerbutton that direction. Then restart to 0
        }
        else
        {
            hintInfo.ActivateLetters();
        }
    }
}
