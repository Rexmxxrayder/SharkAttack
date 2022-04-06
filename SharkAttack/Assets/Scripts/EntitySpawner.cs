using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToolsBoxEngine;

public class EntitySpawner : MonoBehaviour {
    [SerializeField] GameObject _toSpawn = null;
    [SerializeField] float _spawnAngle = 60f;
    [SerializeField] float _time;
    [SerializeField] float _radiusSpawn;
    [SerializeField] Transform _target;

    int[] _sharkBySide = new int[4];
    Coroutine routine_SpawnLoop = null;

    Vector3[] _directions = { Vector3.up, Vector3.right, Vector3.down, Vector3.left };
    public int[] SharkBySide => _sharkBySide;

    void Start() {
        SpawnLoop(_time);
    }

    void Update() {

    }

    void SpawnLoop(float time) {
        if (routine_SpawnLoop != null) { StopCoroutine(routine_SpawnLoop); }
        routine_SpawnLoop = StartCoroutine(SpawnLoop(_toSpawn, time));

        IEnumerator SpawnLoop(GameObject toSpawn, float time) {
            while (true) {
                yield return new WaitForSeconds(time);
                Spawn(toSpawn);
            }
        }
    }

    public void Spawn(GameObject toSpawn) {
        (Vector3, int) position = RandomPositionOnRadius(_radiusSpawn);
        GameObject last = Instantiate(toSpawn, position.Item1, Quaternion.identity);
        Vector3 direction = _target != null ?
            _target.position - position.Item1 :
            new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        direction.Normalize();
        BasicBrain brain = last.GetComponent<BasicBrain>();
        if (brain != null) {
            brain.SetDirection(direction);
            brain.SetSide(position.Item2);
            ++_sharkBySide[position.Item2];
            brain.OnDeath += DeadShark;
        }
    }

    (Vector3, int) RandomPositionOnRadius(float radius) {
        //Vector2 random = Random.insideUnitCircle.normalized;
        int randomIndex = Random.Range(0, _directions.Length);
        Vector3 randomDirection = _directions[randomIndex];
        float angle = Random.Range(_spawnAngle / 2f, -_spawnAngle / 2f);
        Vector3 targetDir = Quaternion.AngleAxis(angle, Vector3.forward) * randomDirection;
        return (targetDir.Override(targetDir.y, Axis.Z).Override(0, Axis.Y) * radius, randomIndex);
    }

    void DeadShark(BasicBrain shark) {
        if (shark.Side == -1) { return; }
        --_sharkBySide[shark.Side];
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radiusSpawn);
    }
}
