using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject player, computerCamera, computerObj, crosshair, cameraHolder, shopDoor, cleanserGameobject;

    [SerializeField] private Button campaign, cleanserButton, shopButton, closeCopmuter;

    [SerializeField] private int campaignPrice = 100;
    [SerializeField] private int cleanserPrice = 200;
    [SerializeField] private int shopPrice = 1000;

    public Sell sell;

    public PauseMenu pauseMenu;

    private void Start()
    {
        shopDoor.SetActive(true);
    }

    public void Interact()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        crosshair.SetActive(false);
        computerCamera.SetActive(true);
        cameraHolder.SetActive(false);
        player.SetActive(false);
        computerObj.SetActive(true);
        pauseMenu.enabled = false;
    }

    // Kierrätyskamppanjan osto.
    public void BuyCampaign(){
        // Jos rahaa on yhtä paljon kuin "campaignPrice" tai enemmän niin voi ostaa kamppanijan
        if (sell.money >= campaignPrice)
        {
            Debug.Log("Mainoskamppanja ostettu!");
            sell.money -= campaignPrice;
            campaign.interactable = false; //Napin käyttö disabloidaan
            NewNPC.waitTime = 15; //Asettaa NPC spwnaamisajan 15 sekunttiin
            Debug.Log(NewNPC.waitTime);
        } 
        // Ei tarpeeksi rahaa, mitään ei tapahdu.
        else if (sell.money <= campaignPrice)
        {
            Debug.Log("Rahaa ei riittävästi");
        }
    }

    // Toinen ostos, höyrylaite.
    public void BuyCleanser()
    {
        if (sell.money >= cleanserPrice)
        {
            Debug.Log("Häyrylaite ostettu");
            sell.money -= cleanserPrice;
            cleanserGameobject.SetActive(true);
            cleanserButton.interactable = false;
        }
        else if (sell.money <= cleanserPrice)
        {
            Debug.Log("Rahaa ei riittävästi");
        }
    }

    public void BuyShop()
    {
        if (sell.money >= shopPrice)
        {
            Debug.Log("Parannettu hajuaisti ostettu");
            sell.money -= shopPrice;
            shopButton.interactable = false;
            shopDoor.SetActive(false);
            Debug.Log("4");
        }
        else if (sell.money <= shopPrice)
        {
            Debug.Log("Rahaa ei riittävästi");
        }
    }

    public void CloseComputer()
    {
        crosshair.SetActive(true);
        player.SetActive(true);
        cameraHolder.SetActive(true);
        computerCamera.SetActive(false);
        computerObj.SetActive(false);
        pauseMenu.enabled = true;
    }
}