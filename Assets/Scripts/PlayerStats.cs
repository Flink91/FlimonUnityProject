using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 10;

    private void Start()
    {
        Money = startMoney;
    }

}
