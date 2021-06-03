using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "VoidEvent", menuName = "SO/Events/void Event", order =1)]
    public class SO_Event : ScriptableObject
    {
        private List<EventListener> listeners = new List<EventListener>();
        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised();
        }

        public void RegisterListener(EventListener listener)
        { 
            if (listeners.Contains(listener))
            {
                Debug.LogError("Registered listener tries to register (" + listener.name + ")");
                return;
            }

            listeners.Add(listener); 
        }

        public void UnregisterListener(EventListener listener)
        {
            if (listeners.Contains(listener))
            {
                Debug.LogError("Unregistered listener tries to unregister (" + listener.name + ")");
                return;
            }

            listeners.Remove(listener); 
        }
    }
}
