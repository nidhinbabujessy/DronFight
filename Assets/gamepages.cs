using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gamepages : MonoBehaviour
{
   public void home()
    {
        SceneManager.LoadScene("home");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    public void playGame()
    {
        SceneManager.LoadScene("Game");
       
    }

    public void quit()
    {
        Application.Quit();
    }
}
