using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sc_LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject biggerButton;

    [SerializeField]
    private TextMeshProUGUI bigTextComponent;

    private string answer;

    // Start is called before the first frame update
    void Start()
    {
        biggerButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenButton(ScrObj_HintInfo hintInfo)
    {
        biggerButton.SetActive(true);
        bigTextComponent = hintInfo.hint;
    }

    public void CloseButton()
    {
        bigTextComponent = null;
        biggerButton.SetActive(false);
    }

    public void CheckAnswer()
    {
        if (answer != null)
        {

        }
    }
}
