using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text myGoldText;
    public Text playerMaxHPText;
    public Text livingMonsterText;
    public Text playerMaxMPText;
    public GameObject gameOverUI;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isDead) {
            gameOverUI.SetActive(true);
            return;
        }
        myGoldText.text = "Gold : " + DataController.Instance.myGold;
/*        if (Input.GetMouseButtonDown(0)) {
            Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("UIManager : " + p);
        }*/
    }

    public void SetPlayerMaxHP(int maxHP) {
        playerMaxHPText.text = "0/" + maxHP;
    }
    public void SetPlayerMaxMP(int maxMP) {
        playerMaxMPText.text = "0/" + maxMP;
    }

    public void UpdatePlayerHPText(int livingMonsterCount) {
        livingMonsterText.text = livingMonsterCount.ToString();
    }

    public void UpdatePlayerMaxHPText(int maxHP) {
        playerMaxHPText.text = maxHP.ToString();
    }
}
