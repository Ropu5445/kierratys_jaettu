using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Tutorial : MonoBehaviour
{
    
    //nämä asiat :]
    private int tutorialPhase = 0;
    private static bool complete = false;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private UnityEngine.UI.Image canvasImage;
    private bool EDown =false;
    private bool FDown = false;
    private int beenDes = 0;

    //player liikkumis scripteihin referenssit
    public PlayerMovement movementScript;
    public PlayerCam cameraScript;
    public NewNPC npcScript;
    public NPC npcScript2;
    public Interactor interScript;
    public Scanner scannerScript;

    //popup imaget ja missä kohdassa niitä käytetään
    [SerializeField] private Sprite welcomeSprite; //alussa
    [SerializeField] private Sprite mouseSprite; //mouse tutorialissa
    [SerializeField] private Sprite movementSprite; //liikkumis tutorialissa
    [SerializeField] private Sprite pickupSprite; //interact ja pickup tutorialissa
    [SerializeField] private Sprite interactSprite; //interact ja pickup tutorialissa
    [SerializeField] private Sprite scannerSprite; //scanner tutorialissa
    [SerializeField] private Sprite clothesSprite; //vaatesorting tutorialissa
    [SerializeField] private Sprite pelialkuSprite;
    [SerializeField] private string poistaNpcnimellä = "NPC FBX(Clone)";

    private float holdDuration = 0f;
    private bool isKeyDown = false;

    [SerializeField] private string playSceneName, thisSceneName;



    void Start()
    {
        //laita tutorialPaneli pois, kato ollaanko tutorial scenessä, jos ollaan niin aloita tutorial
        tutorialPanel.SetActive(false);
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == thisSceneName)
        {
            Starting();
        }
    }

    void Update()
    {
        

        //lopettaa npc spawnaamisen kunnes npc:tä tarvitaan
        if (tutorialPhase != 4&&beenDes==0)
        {
            npcScript.enabled = false;
            npcScript2.enabled = false;
        }
        else if (tutorialPhase == 4)
        {
            npcScript.enabled=true;
            npcScript2.enabled=true;
        }

        
        //onko E presssed
        if (Input.GetKeyDown(KeyCode.E) && tutorialPanel.activeSelf)
        {
            ClosePanel();
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            EDown = true;
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            EDown = false;
        }

        if (Input.GetKeyDown(KeyCode.F)){
            FDown = true;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            FDown = false;
        }

        //wasd ja arrow keys check
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        bool anyKey = Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f;

        if (tutorialPhase == 3)
        {
            //jos wasd tai arrow keys on down nii holdduration up
            if (anyKey)
            {
                if (!isKeyDown)
                {
                    isKeyDown = true;
                }
                holdDuration += Time.deltaTime;
            }
            else
            {
                isKeyDown = false;
            }
        }
    }

    public void Starting()
    {
        //Tässä katsotaan onko tutoriaali jo suoritettu
        //isTutorialComplete();
        if (complete != true)
        {
            StartTutorial();
        }

    }

    public void IsTutorialComplete()
    {

        //referaa johonkin settings filee yms jossa on tutorialComplete joka voi olla 1 tai 0 jossa 0 on ei completetattu tutorial ja 1 on completattu.

        //if tutorialcomplete =1 -> complete=true
        //if else tutorialcomplete=0 -> complete=false
        //else complete=false
        //jos tätä ei jaksa/haluu lisätä nii poistaa tän methodin :]
        
    }

    public void ClosePanel()
    {
        tutorialPanel.SetActive(false);
        EnableMovement();
    }


    public void StartTutorial()
    {
        
        if (tutorialPhase == 0)
        {
            StartCoroutine(StartTutorialCoroutine());
        }
    }
    public IEnumerator StartTutorialCoroutine()
    {
        
        tutorialPhase = 1;

        //laittaa paneelin näkyväks
        Color imageColor = canvasImage.color;
        canvasImage = tutorialPanel.GetComponent<UnityEngine.UI.Image>();
        canvasImage.sprite = welcomeSprite;
        tutorialPanel.SetActive (true);
        imageColor.a = 1;
        canvasImage.color = imageColor;

        DisableMovement();
        
        while(tutorialPanel.activeSelf)
        {
            tutorialPhase = 1;
            yield return new WaitForSeconds(0.2f);
        }

        MoveCameraTutorial();
    }

    public void DisableMovement()
    {
        movementScript.enabled = false;
        cameraScript.enabled = false;
    }
    public void EnableMovement()
    {
        movementScript.enabled = true;
        cameraScript.enabled = true;
    }
    public void MoveCameraTutorial() //tutorial phase 2
    {
        tutorialPhase = 2;
        canvasImage.sprite = mouseSprite;
        tutorialPanel.SetActive(true);
        DisableMovement();

        StartCoroutine(CheckCameraMovement());
    }

    public IEnumerator CheckCameraMovement()
    {
        while (tutorialPanel.activeSelf)
        {
            yield return new WaitForSeconds(0.2f);
        }
        EnableMovement();
        while (cameraScript.movementDuration<0.8f)
        {
            yield return new WaitForSeconds(0.2f);
        }
        MoveAroundTutorial();
    }

    public void MoveAroundTutorial() //tutorial phase 3
    {
        tutorialPhase = 3;
        canvasImage.sprite = movementSprite;
        tutorialPanel.SetActive(true);
        DisableMovement();

        StartCoroutine(CheckMovementTutorial());
    }

    public IEnumerator CheckMovementTutorial()
    {
        while (tutorialPanel.activeSelf)
        {
            yield return new WaitForSeconds(0.2f);
        }

        while (holdDuration < 2)
        {
            yield return new WaitForSeconds(0.2f);
        }
        InteractNpickupTutorial();
    }
    public void InteractNpickupTutorial() //tutorial phase 4
    {
        tutorialPhase = 4;
        canvasImage.sprite = interactSprite;
        tutorialPanel.SetActive(true);
        DisableMovement();
        StartCoroutine(InteractTutorial());
    }

    public IEnumerator InteractTutorial()
    {
        while (tutorialPanel.activeSelf)
        {
            yield return new WaitForSeconds(0.2f);
        }

        while (EDown == false)
        {
            yield return new WaitForSeconds(0.2f);
        }
        
        canvasImage.sprite = pickupSprite;
        tutorialPanel.SetActive(true);

        while (tutorialPanel.activeSelf)
        {
            yield return new WaitForSeconds(0.2f);
        }

        ScannerTutorial();
    }

    public void ScannerTutorial() // tutorial phase 5
    {
        tutorialPhase = 5;
        canvasImage.sprite = scannerSprite;
        tutorialPanel.SetActive(true);
        DisableMovement();
        StartCoroutine(CheckScannerTut());
    }
    public IEnumerator CheckScannerTut()
    {
        while (tutorialPanel.activeSelf)
        {
            yield return new WaitForSeconds(0.2f);
        }
        while (scannerScript.scanDone == false)
        {
            yield return new WaitForSeconds(0.2f);
        }
        ClothesSortingTutorial();
    }
    public void ClothesSortingTutorial() //tutorial phase 6
    {
        tutorialPhase = 6;
        canvasImage.sprite = clothesSprite;
        tutorialPanel.SetActive(true);
        DisableMovement();
        StartCoroutine(EndTutorial());
    }


    //tootiarolin loppu
    public IEnumerator EndTutorial()
    {
        while (tutorialPanel.activeSelf)
        {
            yield return new WaitForSeconds(0.2f);
        }
        while (FDown == false)
        {
            yield return new WaitForSeconds(0.2f);
        }
        canvasImage.sprite = pelialkuSprite;
        tutorialPanel.SetActive(true);
        while (tutorialPanel.activeSelf)
        {
            yield return new WaitForSeconds(0.2f);
        }

        SceneManager.LoadScene(playSceneName);
    }
}
