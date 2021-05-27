using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowersManager : MonoBehaviour {

    [SerializeField] GameObject PowersMenu;
    [SerializeField] PlayerController Player;
    [SerializeField] Button[] Cards;
    [SerializeField] _ScriptablePowers[] Powers;

    bool cardsFilled = false;
    int selectedCardValue;

    [SerializeField] public static int springTalismanRank = 1;
    [SerializeField] public static int summerTalismanRank = 1;
    [SerializeField] public static int autumnTalismanRank = 1;
    [SerializeField] public static int winterTalismanRank = 1;

    [SerializeField] public static int springCost = 0;
    [SerializeField] public static int springSpeed = 0;
    [SerializeField] public static int springPower = 0;

    [SerializeField] public static int summerCost = 0;
    [SerializeField] public static int summerSpeed = 0;
    [SerializeField] public static int summerPower = 0;

    [SerializeField] public static int autumnCost = 0;
    [SerializeField] public static int autumnSpeed = 0;
    [SerializeField] public static int autumnPower = 0;

    [SerializeField] public static int winterCost = 0;
    [SerializeField] public static int winterPower = 10;

    [SerializeField] public static int maxEnergy = 0;
    [SerializeField] public static int maxSanity = 0;
    [SerializeField] public static int sanityDefense = 0;
    [SerializeField] public static int sanityRegen = 0;
    [SerializeField] public static int xpBonus = 0;

    void Start() {
        SetPowers();
    }

    void SetPowers() {
        foreach(Button Card in Cards) {
            int randomCard = Random.Range(0, Powers.Length);
            Card.GetComponent<CardManager>().cardTitle.text = Powers[randomCard].powerName;
            Card.GetComponent<CardManager>().cardDescription.text = Powers[randomCard].powerDescription;
            Card.GetComponent<CardManager>().cardPower = Powers[randomCard].powerattribute;
            Card.GetComponent<CardManager>().cardPowerValue = Powers[randomCard].value;
        }
    }

    public void SelectPower(Button card) {
        string power = card.GetComponent<CardManager>().cardPower;
        SetPowers();
        Player.SetReward();
        UsePower(power);
    }

    private void UsePower(string power) {
        switch (power){
            case "SpringUpgrade":
                springTalismanRank += 1;
                break;
            case "SpringCost":
                springCost += 1;
                break;
            case "SpringPower":
                springPower += 1;
                break;
            case "SpringSpeed":
                springCost += 1;
                break;
            case "SummerUpgrade":
                summerTalismanRank += 1;
                break;
            case "SummerCost":
                summerCost += 1;
                break;
            case "SummerPower":
                summerPower += 1;
                break;
            case "SummerSpeed":
                summerSpeed += 1;
                break;
            case "AutumnUpgrade":
                autumnTalismanRank += 1;
                break;
            case "AutumnCost":
                autumnCost += 1;
                break;
            case "AutumnPower":
                autumnPower += 1;
                break;
            case "AutumnSpeed":
                autumnSpeed += 1;
                break;
            case "WinterUpgrade":
                winterTalismanRank += 1;
                break;
            case "WinterCost":
                winterCost += 1;
                break;
            case "WinterPower":
                winterPower += 1;
                break;
            case "SanityBonus":
                maxSanity += 1;
                break;
            case "SanityRegen":
                sanityRegen += 1;
                break;
            case "SanityDefense":
                sanityDefense += 1;
                break;
            case "MaxEnergy":
                maxSanity += 1;
                break;
            case "XPBonus":
                xpBonus += 1;
                break;
            default:
                Debug.Log("Power not Found");
                break;
        }
    }
}
