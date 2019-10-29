using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Planet planet;

    public GameObject enemyPrefab;

    GameObject enemyGroup;

    [Range(0,20)] public float secondsSpawnInterval = 2;
    float secondsFromlastInterval = 0;

    private void ResetSpawnerPosition(){
        transform.RotateAround(
            planet.transform.position, 
            new Vector3(Random.Range(0,10),Random.Range(0,10),Random.Range(0,10)), 
            Random.Range(0,360)
        );
    }

    private void CreateEnemyGroupOnEditor(){
        enemyGroup = new GameObject();
        enemyGroup.name = "Enemy Group";
    }

    // Start is called before the first frame update
    void Start()
    {
        //ResetSpawnerPosition();
        CreateEnemyGroupOnEditor();
    }

    // Update is called once per frame
    void Update()
    {
        if (secondsFromlastInterval >= secondsSpawnInterval){
            SpawnEnemyInOrbit();
            secondsFromlastInterval = 0;
            ResetSpawnerPosition();
        }else{
            secondsFromlastInterval += Time.deltaTime;
        }
    }

    private void SpawnEnemyInOrbit(){
        GameObject newEnemy = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
        newEnemy.transform.Rotate(this.transform.forward, 180);
        newEnemy.transform.parent = enemyGroup.transform;
    }
}
