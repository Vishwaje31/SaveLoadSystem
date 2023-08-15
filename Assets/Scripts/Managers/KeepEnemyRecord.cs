using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepEnemyRecord : MonoBehaviour
{
    private static KeepEnemyRecord instance;
    public static KeepEnemyRecord GetInstance() { return instance; }

    //{ get; private set; }
public List<EnemyMaster> enemyList  = new List<EnemyMaster>();

    private void Awake()
    {
        instance = this;
    }

    public void AddEnemy(EnemyMaster enemy)
    {
        enemyList.Add(enemy);

    }

    public void CleanEnemy()
    {
        enemyList.RemoveAll(i => i == null);

    }


}
