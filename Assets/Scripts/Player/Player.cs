using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //능력치
    public int maxHP {
        get {
            return PlayerPrefs.GetInt("maxHP", 100);
        }
        set {
            PlayerPrefs.SetInt("maxHP", value);
        }
    }
    public int maxMP {
        get {
            return PlayerPrefs.GetInt("maxMP", 10);
        }
        set {
            PlayerPrefs.SetInt("maxMP", value);
        }
    }
    public float attackDamage {
        get {

            return float.Parse(PlayerPrefs.GetString("attackDamage", "1"));
        }
        set {
            PlayerPrefs.SetString("attackDamage", value.ToString());
        }
    }
    public float abilityPower {
        get {
            return float.Parse(PlayerPrefs.GetString("abilityPower", "0"));
        }
        set {
            PlayerPrefs.SetString("abilityPower", value.ToString());
        }
    }

    public int attackTargetCnt {
        get {
            return 1;
        }
    }
}
