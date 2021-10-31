using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public Transform spawner;
    public Transform enemyPrfab;

    private void Start() {
        InvokeRepeating("SpawnEnemy", 0, 10.0f);
    }

    public void SpawnEnemy() {
        Debug.Log("spawning enemy");
        Instantiate(enemyPrfab, spawner.position,spawner.rotation);
        RandomizePosition();
    }

    private void RandomizePosition() {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
}
