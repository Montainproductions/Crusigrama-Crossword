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

    private Sc_HintInfo hintInfo;

    private string answer;

    [SerializeField]
    private GameObject box;

    public float rotationSpeed = 2f;
    // Maximum rotation
    private float targetRotation = 10f;


    // Start is called before the first frame update
    void Start()
    {
        bigButton.SetActive(false);
        SetAllTextToInvis();
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
        bigTextComponent.text = hintInfo.hint.text;
        answer = hintInfo.answer;
    }

    public void CloseButton()
    {
        hintInfo = null;
        bigTextComponent.text = " ";
        answer = " ";

        bigButton.SetActive(false);
    }

    public void CheckAnswer(TextMeshProUGUI playerAnswer)
    {
        StartCoroutine(CheckAnswerIE(playerAnswer));
    }

    public IEnumerator CheckAnswerIE(TextMeshProUGUI playerAnswer)
    {
        Debug.Log(answer);
        Debug.Log(playerAnswer.text);
        Debug.Log(answer.Equals(playerAnswer.text));
        if (!answer.Equals(playerAnswer.text))
        {
            Debug.Log("Fail");
            //Set rotation change
            float startTime = Time.time;
            float elapsedTime = 0f;
            float randomRotation = Random.Range(-10f, 10f);

            //Rotate for x seconds
            while (elapsedTime < 5f)
            {
                float rotationAmount = Mathf.Lerp(0f, randomRotation, elapsedTime / 5f);
                box.transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount);
                elapsedTime += Time.deltaTime;
            }

            float originalRotation = transform.rotation.eulerAngles.z;
            float returnDuration = Mathf.Abs(originalRotation) / rotationSpeed; // Time to return to original rotation
            float returnStartTime = Time.time;
            while (Time.time < returnStartTime + returnDuration)
            {
                float currentRotation = Mathf.Lerp(randomRotation, 0f, (Time.time - returnStartTime) / returnDuration);
                box.transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
                yield return null;
            }
            box.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            Debug.Log("Succed");
            hintInfo.ActivateLetters();
        }

        yield return null;
    }
}
