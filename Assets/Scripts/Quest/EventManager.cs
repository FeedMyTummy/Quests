using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public event EventHandler<GameEvent> OnGameEvent;

    public void DeathOfId(KillEvent killEvent)
    {
        OnGameEvent?.Invoke(this, killEvent);
    }

    [ContextMenu("Kill Beast")]
    void KillBeast()
    {
        OnGameEvent?.Invoke(this, new KillEvent("test", "editor")); 
    }

    [ContextMenu("Kill Skeleton")]
    void KillSkeleton()
    {
        OnGameEvent?.Invoke(this, new KillEvent("skeleton", "editor")); 
    }
}