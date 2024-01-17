using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private string menuSceneName;
    [SerializeField] private string thisSceneName;

    public GameObject player, playerCamera;

    public PlayerMovement playerMovement;
    public PlayerCam cam;

    private bool toggle;

    public void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>(); 
        cam = playerCamera.GetComponent<PlayerCam>();
        toggle = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggle = !toggle;
        }

        if (!toggle)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            playerMovement.enabled = true;
            cam.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (toggle)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerMovement.enabled = false;
            cam.enabled = false;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void Resume()
    {
        toggle = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        playerMovement.enabled = true;
        cam.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(thisSceneName);
    }

    public void QuitToMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(menuSceneName);
    }

    public void QuitToWindows()
    {
        Application.Quit();
    }
}
