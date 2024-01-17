using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trash : MonoBehaviour
{
    [SerializeField] private Text xpText;

    public int xp, maxXp, levelAmount;

    private void Start()
    {
        maxXp = 500;
        levelAmount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            xp = xp + 15;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Sell"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Fix"))
        {
            xp = xp - 5;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Ticks"))
        {
            Destroy(other.gameObject);
        }

    }

    private void Update()
    {
        xpText.text = "XP: " + xp + "/" + maxXp;
        if (xp >= maxXp)
        {
            xp = xp - maxXp;
            levelAmount++;
            Debug.Log("P‰‰sit uuteeen tasoon " + levelAmount);
        }
    }
}
