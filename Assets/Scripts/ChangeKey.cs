
using TMPro;
using UnityEngine;

public class ChangeKey : ICommand
{
    //tried passing a ref to the input I wanted changed but needed to deep copy the variables and couldnt get that to work
    private InputManager input;
    private keys key;
    private KeyCode keyCode;
    private KeyCode oldKeyCode;
    private Transform buttonTrans;

    public ChangeKey(InputManager input, keys key, KeyCode keyCode, Transform buttonTrans)
    {
        this.input = input;
        this.key = key;
        this.keyCode = keyCode;
        this.buttonTrans = buttonTrans;
    }

    public void Execute()
    {
        buttonTrans.GetChild(0).GetComponent<TMP_Text>().text = keyCode.ToString();

        switch (key)
        {
            case keys.None:
                return;
            case keys.Forward:
                oldKeyCode = input.forwardKey;
                input.forwardKey = keyCode;
                return;
            case keys.Left:
                oldKeyCode = input.leftKey;
                input.leftKey = keyCode;
                return;
            case keys.Right:
                oldKeyCode = input.rightKey;
                input.rightKey = keyCode;
                return;
            case keys.Backwards:
                oldKeyCode = input.backwardsKey;
                input.backwardsKey = keyCode;
                return;
            case keys.Interact:
                oldKeyCode = input.interactKey;
                input.interactKey = keyCode;
                return;
        }
    }

    public void Undo()
    {
        buttonTrans.GetChild(0).GetComponent<TMP_Text>().text = oldKeyCode.ToString();

        switch (key)
        {
            case keys.None:
                return;
            case keys.Forward:
                input.forwardKey = oldKeyCode;
                return;
            case keys.Left:
                input.leftKey = oldKeyCode;
                return;
            case keys.Right:
                input.rightKey = oldKeyCode;
                return;
            case keys.Backwards:
                input.backwardsKey = oldKeyCode;
                return;
            case keys.Interact:
                input.interactKey = oldKeyCode;
                return;
        }
    }
}

