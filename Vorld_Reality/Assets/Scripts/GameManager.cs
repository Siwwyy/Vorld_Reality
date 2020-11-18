using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button exitButton;
    public Button historyButton;
    static public GameStates gameState;
    public enum GameStates
    {
        MAIN_MENU, SCENE_MENU, IN_GAME
    }

    
    public void Awake()
    {
        gameState = GameStates.MAIN_MENU;
    }

    // Start is called before the first frame update
    void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
        historyButton.onClick.AddListener(EnterGame);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == GameStates.SCENE_MENU)
        {
            
        }

        if (gameState == GameStates.IN_GAME)
        {

        }

    }

    public void EnterGame()
    {
        if (checkIfGood())
        {
            SceneManager.LoadScene("Test_Scene");
            gameState = GameStates.SCENE_MENU;
        }


    }

    public void ExitGame()
    {
        if (canExit())
        {
            if (Application.isEditor)
            {
                Debug.Break();
            }
            else
            {
                Application.Quit();
            }
            
        }
    }

    public bool checkIfGood()
    {
        return true;
    }

    public bool canExit()
    {
        return true;
    }
}
