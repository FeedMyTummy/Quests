using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public event EventHandler<GameEvent> OnGameEvent;

    public void Invoke(DeathEvent deathEvent)
    {
        OnGameEvent?.Invoke(this, deathEvent);
    }

    [ContextMenu("Kill Beast")]
    void KillBeast()
    {
        OnGameEvent?.Invoke(this, new DeathEvent("test", "editor")); 
    }

    [ContextMenu("Kill Skeleton")]
    void KillSkeleton()
    {
        OnGameEvent?.Invoke(this, new DeathEvent("skeleton", "editor")); 
    }
}