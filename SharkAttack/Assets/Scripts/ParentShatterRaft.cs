using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParentShatterRaft : MonoBehaviour {
    [System.Serializable]
    struct TieredPiece {
        public HealthModule health;
        public int tier;

        public TieredPiece(HealthModule _health, int _tier) {
            tier = _tier;
            health = _health;
        }
    }

    [SerializeField] List<TieredPiece> childs = new List<TieredPiece>();
    [SerializeField] int healthPart;
    [SerializeField] UnityEvent<int> _onLostChild;

    public event UnityAction<int> OnLostChild { add => _onLostChild.AddListener(value); remove => _onLostChild.RemoveListener(value); }

    private void Awake() {
        for (int i = 0; i < childs.Count; i++) {
            childs[i].health.OnDeath += RemoveChild;
        }
    }

    public void AddChild(HealthModule health, int tier) {
        childs.Add(new TieredPiece(health, tier));
    }

    public void RemoveChild(IHealth health) {
        for (int i = 0; i < childs.Count; i++) {
            if (childs[i].health.GetComponent<IHealth>() == health) {
                if (childs[i].tier < healthPart) {
                    healthPart = childs[i].tier;
                    _onLostChild?.Invoke(healthPart);
                }
                childs.RemoveAt(i);
            }
        }
    }
}
