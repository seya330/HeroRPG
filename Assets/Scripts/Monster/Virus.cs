using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : Monster {

    //내가 사망했을때 플레이어에게 주는 금액
    int myCost = 1;
    /*private void OnMouseDown() {
        Die();
    }*/

    public override void OnDamage(float damage) {
        DataController.Instance.myGold += myCost;
        base.OnDamage(damage);
    }
}
