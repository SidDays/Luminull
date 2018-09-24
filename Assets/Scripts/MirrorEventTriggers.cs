using UnityEngine;
using UnityEngine.EventSystems;

public class MirrorEventTriggers : EventTrigger {

    public override void OnSelect(BaseEventData data)
    {
        Debug.Log("OnSelect called.");
    }
}
