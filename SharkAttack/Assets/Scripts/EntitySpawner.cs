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

    Coroutine routine_SpawnLoop = null;

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
        Vector3 position = RandomPositionOnRadius(_radiusSpawn);
        GameObject last = Instantiate(toSpawn, position, Quaternion.identity);
        Vector3 direction = _target != null ?
            _target.position - position :
            new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
        direction.Normalize();
        last.GetComponent<BasicBrain>()?.SetDirection(direction);
    }

    Vector3 RandomPositionOnRadius(float radius) {
        //Vector2 random = Random.insideUnitCircle.normalized;

        Vector3 randomDirection = Tools.RandomValue(Vector3.up, Vector3.right, Vector3.down, Vector3.left);
        float angle = Random.Range(_spawnAngle / 2f, -_spawnAngle / 2f);
        Vector3 targetDir = Quaternion.AngleAxis(angle, Vector3.forward) * randomDirection;
        return targetDir.Override(targetDir.y, Axis.Z).Override(0, Axis.Y) * radius;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radiusSpawn);
    }
}
