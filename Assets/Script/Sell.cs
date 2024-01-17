using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
    [SerializeField] private Text moneyText;

    public int money;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Sell"))
        {
            int moneyRand = Random.Range(10, 20);
            money = money + moneyRand;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trash"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Fix"))
        {
            money = money - 50;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Ticks"))
        {
            money = money - 50;
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        moneyText.text = money + "€";
    }

}
