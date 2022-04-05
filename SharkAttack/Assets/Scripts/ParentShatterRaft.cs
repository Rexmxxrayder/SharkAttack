using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParentShatterRaft : MonoBehaviour{
    [SerializeField] List<ShatterRaft> childs = new List<ShatterRaft>();
    [SerializeField] int healthPart;
    public UnityEvent<int> lostChild;

    public void AddChild(ShatterRaft child) {
        childs.Add(child);
    }

    public void RemoveChild(ShatterRaft child) {
        if (childs.Contains(child)) {
            childs.Remove(child);
            lostChild?.Invoke(healthPart);
        }
    }
}
