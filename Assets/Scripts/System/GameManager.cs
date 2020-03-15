using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //싱글톤
    private static GameManager gameManager;

    public static GameManager Instance {
        get {
            if(gameManager == null) {
                gameManager = FindObjectOfType<GameManager>();
                if(gameManager == null) {
                    GameObject container = new GameObject("GameManager");
                    gameManager = container.AddComponent<GameManager>();
                }
            }
            return gameManager;
        }
    }

    //사망 플래그
    public bool isDead = false;

    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isDead) {
            return;
        }
    }
}
