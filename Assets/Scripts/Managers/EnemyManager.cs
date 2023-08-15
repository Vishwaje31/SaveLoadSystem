using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyTypes whichTypeSpawn;
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    void Start ()
    {
        InvokeRepeating (nameof(Spawn), spawnTime, spawnTime);
    }

    void Spawn ()
    {   
        if(playerHealth.CurrentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        GameObject obj = Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        KeepEnemyRecord.GetInstance().AddEnemy(enemy.GetComponent<EnemyMaster>());

    }

    public void SpawnAtSpecificPoint(Vector3 _pos)
    {
        if (playerHealth.CurrentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        GameObject obj = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        obj.transform.position = _pos;
        obj.GetComponent<EnemyMaster>().ResetNavSettings();

        KeepEnemyRecord.GetInstance().AddEnemy(enemy.GetComponent<EnemyMaster>());


    }

}
