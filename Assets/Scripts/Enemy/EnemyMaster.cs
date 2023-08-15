using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMaster : MonoBehaviour
{
    [SerializeField] EnemyTypes myType;
    [SerializeReference] NavMeshAgent navAgent;

    public EnemyTypes GetMytype()
    {
        return myType;
    }

    public void ResetNavSettings()
    {
        navAgent.ResetPath();
    }


}
