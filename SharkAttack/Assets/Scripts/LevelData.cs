using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IsleData")]
public class LevelData : ScriptableObject {
    [SerializeField] public string currentIsle;
    [SerializeField] public int sharkNumber;
    [SerializeField] public int duration;
    [SerializeField] public int sharkAttackTime;
    [SerializeField] public int killerWhaleHealthPoint;
}
