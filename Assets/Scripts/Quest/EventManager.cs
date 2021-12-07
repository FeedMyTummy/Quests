using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public event EventHandler<GameEvent> OnGameEvent;

    [ContextMenu("Kill Beast")]
    void KillBeast()
    {
        OnGameEvent?.Invoke(this, new KillEvent("test")); 
    }
}
