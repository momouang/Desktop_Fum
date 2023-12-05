using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UniversialTestTrigger : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent TriggeredEvents;

    public void Trigger()
    {
        TriggeredEvents.Invoke();
    }
}

#if UNITY_EDITOR

class UniversialTestTriggerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        UniversialTestTrigger debugger = (UniversialTestTrigger)target;

        if (GUILayout.Button("Trigger Events"))
            debugger.Trigger();
    }
}

#endif