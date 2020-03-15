using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    //프리팹
    public Monster monsterPrefab;
    public Camera mainCamera;

    //몬스터 생성 시간
    float creatingTime = 0f;
    float processingTime = 0f;

    //현재 생존 몬스터 배열
    private List<Monster> monsterList = new List<Monster>();

    private BoxCollider2D myBoxCollider;


    private RectTransform spawnArea;

    public Player player;
    void Start()
    {
        spawnArea = GetComponent<RectTransform>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isDead) {
            return;
        }

        if (Input.GetMouseButtonDown(0)) {
            Vector2 p = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] ovlColliders = Physics2D.OverlapCircleAll(p, 70f);

            int hitCnt = 0;
            for (int i = 0; i < ovlColliders.Length; i++) {
                Monster target = ovlColliders[i].GetComponentInParent<Monster>();
                if (target != null && !target.isDead) {
                    target.OnDamage(1f);
                    hitCnt++;
                    if (hitCnt >= player.attackTargetCnt) {
                        break;
                    }
                }
            }
        }



        processingTime += Time.deltaTime;
        if(processingTime >= creatingTime) {
            float posX = Random.Range(spawnArea.rect.xMin, spawnArea.rect.xMax);
            float posY = Random.Range(spawnArea.rect.yMin, spawnArea.rect.yMax);
            /*float posX = 0f; float posY = 0;*/

            Monster monster = Instantiate((Virus)monsterPrefab, new Vector3(posX, posY, 1), Quaternion.identity);
            monster.transform.SetParent(this.transform);
            monsterList.Add(monster);
            monster.onDeath += () => monsterList.Remove(monster);
            monster.onDeath += () => Destroy(monster.gameObject, 3f);

            processingTime = 0f;
            creatingTime = Random.Range(0f, 0.8f);
        }
    }

    public int GetMonsterListCnt() {
        return monsterList.Count;
    }

    /*public void OnMouseDown() {

        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] ovlColliders = Physics2D.OverlapCircleAll(p, 0.5f);

        int hitCnt = 0;
        for (int i=0; i<ovlColliders.Length; i++) {
            Monster target = ovlColliders[i].GetComponentInParent<Monster>();
            if(target != null && !target.isDead) {
                target.OnDamage(1f);
                hitCnt++;
                Debug.Log("hitCnt : " + hitCnt);
                if(hitCnt >= player.attackTargetCnt) {
                    Debug.Log("break!");
                    break;
                }
            }
        }
    }*/
}
