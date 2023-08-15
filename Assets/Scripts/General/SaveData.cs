using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SaveEnemyData
{
    public List<Position> enemyTrans;
    public List<EnemyTypes> enemyTypes;

    //public int posx;
    //public int posy;
    //public int posz;

}

[System.Serializable]
public struct SavePlayerData
{
    public Position playerPosition;
    public int score;
    public int health;

}

[System.Serializable]
public struct Position
{
    public float posx;
    public float posy;
    public float posz;
}

[System.Serializable]
public enum EnemyTypes
{
    ZomBunny,
    ZomBear,
    Hellephant
}
