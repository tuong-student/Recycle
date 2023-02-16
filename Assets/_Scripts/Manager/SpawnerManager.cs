using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Manager
{
    public class SpawnerManager : MonoBehaviour
    {
        private enum Direction
        {
            Left,
            Right
        }

        [SerializeField] private Direction direction;
        [SerializeField] private Transform[] objecToSpawnArray;
        [SerializeField] private Transform trashObjectHolder;

        private float spawnTimer;
        private float spawnTimerMax;

        private void Update()
        {
            spawnTimer -= Time.deltaTime;
            if(spawnTimer <= 0)
            {
                spawnTimerMax = Random.Range(1, 5);
                spawnTimer = spawnTimerMax;

                SpawnObject();
            }
        }

        private void SpawnObject()
        {
            Transform objectClone = Instantiate(objecToSpawnArray[Random.Range(0, objecToSpawnArray.Length)], trashObjectHolder);
            objectClone.position = this.transform.position;
            Rigidbody2D rigidbody2D = objectClone.GetComponent<Rigidbody2D>();
            float spawnForce = 500f * rigidbody2D.gravityScale;
            if(direction == Direction.Left)
            {
                rigidbody2D.AddForce(-this.transform.right * spawnForce, ForceMode2D.Impulse);
            }
            else
            {
                rigidbody2D.AddForce(this.transform.right * spawnForce, ForceMode2D.Impulse);
            }

        }
    }
}
