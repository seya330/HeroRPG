using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillDragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler {
    public Vector2 defaultPosition;
    private Canvas rootCanvas;
    public RedCircle redCirclePrefab;
    private RedCircle redCircle;
    public GameObject effect;
    float skillDamage = 1f;

    void Start() {
        this.rootCanvas = this.GetComponentInParent<Canvas>();
    }
    void Update() {

    }
    public void OnBeginDrag(PointerEventData eventData) {
        if (GameManager.Instance.isDead) {
            return;
        }
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        redCircle = Instantiate(redCirclePrefab, p, Quaternion.identity, rootCanvas.transform);

        //transform.SetParent(rootCanvas.transform);
    }

    public void OnDrag(PointerEventData eventData) {
        if (GameManager.Instance.isDead) {
            return;
        }
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(currentPos);
        redCircle.transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (GameManager.Instance.isDead) {
            return;
        }
        Vector2 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] colliders = new Collider2D[5];
        ContactFilter2D filter = new ContactFilter2D();
        CircleCollider2D myCollider = redCircle.GetComponent<CircleCollider2D>();
        int a = Physics2D.OverlapCollider(myCollider, filter, colliders);
        for (int i = 0; i < colliders.Length; i++) {
            Collider2D collider = colliders[i];
            if (collider != null) {
                Monster target = collider.GetComponentInParent<Monster>();
                if(target != null) {
                    target.OnDamage(skillDamage);
                }
            }
        }
        
        Instantiate(effect, currentPos, Quaternion.identity, rootCanvas.transform);


        Destroy(redCircle.gameObject, 0.3f);
    }
}
