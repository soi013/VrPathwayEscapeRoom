using TMPro;
using UnityEngine;

public class NumberPadScreenDispenser : MonoBehaviour
{
    [SerializeField]
    private NumberPad numberPad;

    [SerializeField]
    private TextMeshProUGUI textCode;

    [SerializeField]
    private TextMeshProUGUI textResult;

    private const string COLLECT_RESULT = "5555";

    [SerializeField]
    private AudioSource audioInputKey;


    void Start()
    {
        numberPad.KeyInputActionMerged += UpdateCode;
        ClearInput();
    }

    private void UpdateCode(string inputKeyText)
    {
        textCode.text += inputKeyText;
        audioInputKey.Play();

        if (textCode.text.Length == COLLECT_RESULT.Length)
        {
            CalcResult();
        }
        if (textCode.text.Length > COLLECT_RESULT.Length)
        {
            ClearInput();
            textCode.text += inputKeyText;
        }
    }

    private void CalcResult()
    {
        bool result = textCode.text == COLLECT_RESULT;

        textResult.text = result
            ? "VALID"
            : "INVALID";
    }

    private void ClearInput()
    {
        textCode.text = string.Empty;
        textResult.text = string.Empty;
    }
}
