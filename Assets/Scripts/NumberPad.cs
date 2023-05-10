using System;
using UnityEngine;

public class NumberPad : MonoBehaviour
{
    [SerializeField]
    private XrTouchButton[] buttons;
    public Action<string> KeyInputActionMerged { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        foreach (var button in buttons)
        {
            button.KeyInputAction += KeyInputComming;
        }
    }

    private void KeyInputComming(string inputKeyText)
    {
        Debug.Log($"Key Input comming = {inputKeyText}");
        KeyInputActionMerged?.Invoke(inputKeyText);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
