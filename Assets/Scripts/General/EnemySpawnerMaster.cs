using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerMaster : MonoBehaviour
{
    [SerializeField] EnemyManager zomBunnyManagerIns;
    [SerializeField] EnemyManager zoomBearManagerIns;
    [SerializeField] EnemyManager hellephantManagerIns;

    public void SpawnBackSpecificEnemy(EnemyTypes _type, Position _pos)
    {
        Vector3 temp = new Vector3(_pos.posx, _pos.posy, _pos.posz);

        switch (_type)
        {
            case EnemyTypes.ZomBunny:
                zomBunnyManagerIns.SpawnAtSpecificPoint(temp);
                break;

            case EnemyTypes.ZomBear:
                zoomBearManagerIns.SpawnAtSpecificPoint(temp);
                break;

            case EnemyTypes.Hellephant:

                hellephantManagerIns.SpawnAtSpecificPoint(temp);
                break;
        }

    }


}
