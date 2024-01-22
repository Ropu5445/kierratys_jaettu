using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string playSceneName, tutorialSceneName;
    [SerializeField] private GameObject menu, credits;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void Play()
    {
        SceneManager.LoadScene(playSceneName);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(tutorialSceneName);
    }

    public void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void SkipCredits()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
