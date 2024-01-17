using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fix : MonoBehaviour
{
    [SerializeField] private Text xpText;

    public Trash trash;
    public Sell sell;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fix"))
        {
            trash.xp = trash.xp + 15;
            xpText.text = "XP: " + trash.xp + "/" + trash.maxXp;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trash"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Sell"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Ticks"))
        {
            sell.money = sell.money - 50;
            Destroy(other.gameObject);
        }
    }
}
