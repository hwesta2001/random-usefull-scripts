using UnityEngine;
using UnityEngine.AI;

[System.Serializable]

public class Unit
{
    [HideInInspector]
    public Transform trans, selectionArrowTransform; // unitmono da ayarlanıyor o yüzden HideInInspector!! // bu unit in Transform'u SÜPER KULLANIŞLI !!!
    [HideInInspector]
    public NavMeshAgent agent; // unitmono da ayarlanıyor o yüzden HideInInspector!! 

    public string unitName;
    public Sprite icon;
    public UnitType unitType;
    [Space]
    public int team = 1; // 1inci Team her zaman player
    public bool isBuilding;
    [Space]
    public string info;
    [Space]
    public float maxHp;
    public float hp;
    public float armor = 1;
    [Space]
    public float attackSpeed = 2;
    public float attackRange = 10;
    public float aggroRange = 20; // agrroRange yarıcaptan bağımsız merkezden itibaren ekstra hesaplamaya gerek yok
    public float yariCap = 2; // unitin yarıçapı diyebiliriz
    [Space]
    public int minDamage = 1;
    public int maxDamage = 2;
    }
