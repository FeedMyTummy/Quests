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

    [ContextMenu("Kill Skeleton")]
    void KillSkeleton()
    {
        OnGameEvent?.Invoke(this, new KillEvent("skeleton")); 
    }
}
