using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;

    private void Start()
    {
        playButton.onClick.AddListener(playGame);
        exitButton.onClick.AddListener(exitGame);
    }

    private void playGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void exitGame()
    {
        Application.Quit();
    }
}
