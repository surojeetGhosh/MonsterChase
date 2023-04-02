using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReferences;

    private GameObject monsterSpawned;

    [SerializeField]
    private Transform leftPos, rightPos;
    private int randomIndex;
    private int randomSide;
    void Start()
    {
        StartCoroutine(spawnMonster());
    }

    // Update is called once per frame
    // calling this randomly after 1->5 seconds
    // change collider to capsule collider as box collider sometimes get stuck in ground box collider
    IEnumerator spawnMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            randomIndex = Random.Range(0, monsterReferences.Length);
            randomSide = Random.Range(0, 2);
            monsterSpawned = Instantiate(monsterReferences[randomIndex]);

            if (randomSide == 0)
            {
                // left side
                monsterSpawned.transform.position = leftPos.transform.position;
                monsterSpawned.GetComponent<Enemy>().speed = Random.Range(4, 10);
            }
            else
            {
                // right side
                monsterSpawned.transform.position = rightPos.transform.position;
                // accessing Enemy script
                monsterSpawned.GetComponent<Enemy>().speed = -Random.Range(4, 10);
                monsterSpawned.transform.localScale = new Vector3(-1, 1, 1);
            }
        }

    }
}
