using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Consider generating this from an string to enum tool for easy editing?
public enum EventType
{
    //ADD STUFF
    ENTER_LIVINGROOM,   //0
    NEXT_TASK,      //1
    NUM_EVENTS          //2
}

public delegate void EventCallback(EventType evt, object value);

public static class EventSystem
{
    private static Dictionary<EventType, System.Action> eventRegister = new Dictionary<EventType, System.Action>();

    public static void Subscribe(EventType evt, System.Action func)
    {
        if (!eventRegister.ContainsKey(evt))
        {
            eventRegister.Add(evt, null);
        }

        eventRegister[evt] += func;
    }

    public static void Unsubscribe(EventType evt, System.Action func)
    {
        if (eventRegister.ContainsKey(evt))
        {
            eventRegister[evt] -= func;
        }
    }

    public static void RaiseEvent(EventType evt, object value)
    {
        eventRegister[evt]?.Invoke();
    }
}