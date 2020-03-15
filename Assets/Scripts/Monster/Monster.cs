using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, IMonster
{
    public event Action onDeath;
    private Animator anim;
    public bool isDead = false;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    public void Die() {
        if (GameManager.Instance.isDead) {
            return;
        }
        isDead = true;
        if (onDeath != null) {
            onDeath();
        }
        anim.SetTrigger("die");
    }

    public virtual void OnDamage(float damage) {
        this.Die();
    }

}
