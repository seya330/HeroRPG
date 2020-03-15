using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    //싱글톤 영역
    private static DataController dataController;

    //핸들러 영역
    public UIManager uiManager;
    public Player player;
    public MonsterSpawner monsterSpawner;

    private void Start() {
        uiManager.UpdatePlayerMaxHPText(player.maxHP);
    }

    private void Update() {
        uiManager.UpdatePlayerHPText(monsterSpawner.GetMonsterListCnt());
        if(player.maxHP < monsterSpawner.GetMonsterListCnt()) {
            GameManager.Instance.isDead = true;
        }
    }
    public static DataController Instance {
        get {
            if(dataController == null) {
                dataController = FindObjectOfType<DataController>();
                if(dataController == null) {
                    GameObject container = new GameObject("DataController");
                    dataController = container.AddComponent<DataController>();
                }
            }
            return dataController;
        }
    }

    //데이터 영역

    //소지한 골드
    public int myGold {
        get {
            return PlayerPrefs.GetInt("myGold", 0);
        }
        set {
            PlayerPrefs.SetInt("myGold", value);
        }
    }

}
