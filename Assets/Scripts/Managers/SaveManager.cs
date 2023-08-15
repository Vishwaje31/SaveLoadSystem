using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class SaveManager : MonoBehaviour
{
    [SerializeField] Transform playerTransRef;
    [SerializeField] PlayerHealth player_HealthRef;
    [SerializeField] EnemySpawnerMaster spawnMasterRef;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
            SaveGame();

        else if (Input.GetKeyDown(KeyCode.P))
            LoadGame();

    }

    public void SaveGame()
    {
        KeepEnemyRecord.GetInstance().CleanEnemy();

        SaveEnemyData saveData = new SaveEnemyData();

        saveData.enemyTypes = new List<EnemyTypes>();
        saveData.enemyTrans = new List<Position>();

        List<EnemyMaster> tempList = KeepEnemyRecord.GetInstance().enemyList;


        for (int i = 0; i < tempList.Count; i++)
        {
            //Debug.Log(tempList);
            //Debug.Log(tempList[i]);
            //Debug.Log(saveData);
            //Debug.Log(saveData.enemyPrefab.Count);

            saveData.enemyTypes.Add(tempList[i].GetMytype());

            Position _pos = new Position();
            _pos.posx = tempList[i].transform.position.x;
            _pos.posy = tempList[i].transform.position.y;
            _pos.posz = tempList[i].transform.position.z;

            saveData.enemyTrans.Add(_pos);

        }

        BinarySaver.SaveGame(saveData);

        //now save player data

        SavePlayerData player_data = new SavePlayerData();
        Position _pPos = new Position();

        _pPos.posx = playerTransRef.position.x;
        _pPos.posy = playerTransRef.position.y;
        _pPos.posz = playerTransRef.position.z;

        player_data.playerPosition = _pPos;

        player_data.score = ScoreManager.score;
        player_data.health = player_HealthRef.CurrentHealth;

        BinarySaver.SavePlayerData(player_data);

    }

    public void LoadGame()
    {
        SaveEnemyData saveData = new SaveEnemyData();
        saveData = BinarySaver.LoadGame();

        for (int i = 0; i < saveData.enemyTypes.Count; i++)
        {
            Position ePos = new Position();
            ePos = saveData.enemyTrans[i];

            spawnMasterRef.SpawnBackSpecificEnemy(saveData.enemyTypes[i], ePos);

        }

        //now for the player

        SavePlayerData player_data = new SavePlayerData();
        player_data = BinarySaver.LoadPlayerData();

        playerTransRef.position = new Vector3(player_data.playerPosition.posx, player_data.playerPosition.posy, player_data.playerPosition.posz);

        //so basically max health - our last health
        //let 60 is last and 100 is max, 100- 60 = 40
        player_HealthRef.TakeDamage(player_HealthRef.startingHealth - player_data.health);
        ScoreManager.score = player_data.score;

    }


    //[SerializeReference] Transform myTransformRef;
    //[SerializeField] bool canSave;
    //[SerializeField] int saveBetweenTime;

    //public string saveDataStr = "";

    //private void Start()
    //{
    //    LoadMyState();

    //    StartCoroutine(_SaveMyState());

    //}

    //IEnumerator _SaveMyState()
    //{
    //    yield return new WaitForSeconds(saveBetweenTime);

    //    JSONObject data = JSON.Parse("{ 0 : [] }") as JSONObject;

    //    JSONArray pos = data[0] as JSONArray;

    //    pos.Add(Mathf.Round(transform.position.x));
    //    pos.Add(Mathf.Round(transform.position.y));
    //    pos.Add(Mathf.Round(transform.position.z));

    //    Debug.Log(data);

    //    saveDataStr = data.ToString();

    //    StartCoroutine(_SaveMyState());

    //}

    //public static int c = 0;

    //private void LoadMyState()
    //{
    //    if (saveDataStr != "")
    //    {
    //        c++;
    //        JSONObject data = JSON.Parse(saveDataStr) as JSONObject;

    //        JSONArray pos = data[0] as JSONArray;

    //        Debug.Log("------------------" + c);
    //        Debug.Log(data);  
    //        Debug.Log(pos[0] + "   /    " + pos[1] + "    /   " + pos[2]);

    //        myTransformRef.position = new Vector3(pos[0], pos[1], pos[2]);

    //    }

    //}


}
