using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum keys
{
    None,
    Forward,
    Left,
    Right,
    Backwards,
    Interact
}
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get { return instance; } }

    public KeyCode forwardKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode backwardsKey;
    public KeyCode interactKey;
    
    [SerializeField] private keys currentKey;
    
    private ICommand currentKeyCommand;
    private Transform currentTrans;
    private Stack<ICommand> commandStack = new Stack<ICommand>();
    private bool changeKeybind;
    private static InputManager instance;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }
    
    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && changeKeybind)
        {
            currentKeyCommand = new ChangeKey(this, currentKey, e.keyCode,  currentTrans);
            commandStack.Push(currentKeyCommand);
            currentKeyCommand.Execute();
            
            changeKeybind = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.LeftControl) && MenuManager.Instance.pauseMenuOn)
        {
            if (commandStack.Count > 0)
            {
                ICommand latestCommand = commandStack.Pop();
                latestCommand.Undo();
            }
        }
    }

    public void ChangeKeyForward(Transform trans)
    {
        currentTrans = trans;
        changeKeybind = true;
        currentKey = keys.Forward;
    }
    
    public void ChangeKeyLeft(Transform trans)
    {
        currentTrans = trans;
        changeKeybind = true;
        currentKey = keys.Left;
    }
    
    public void ChangeKeyRight(Transform trans)
    {
        currentTrans = trans;
        changeKeybind = true;
        currentKey = keys.Right;
    }
    
    public void ChangeKeyBackwards(Transform trans)
    {
        currentTrans = trans;
        changeKeybind = true;
        currentKey = keys.Backwards;
    }
    
    public void ChangeKeyInteract(Transform trans)
    {
        currentTrans = trans;
        changeKeybind = true;
        currentKey = keys.Interact;
    }
}
