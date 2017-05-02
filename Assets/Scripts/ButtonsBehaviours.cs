using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsBehaviours : MonoBehaviour {

    public void GameSelection()
    {
        SceneManager.LoadScene("GameSelection");
    }

    public void PlayerVsPlayer()
    {
        SceneManager.LoadScene("playervsplayer");
    }

    public void selectPlayerOne(bool isCross)
    {
        if (isCross)
        {
            PlayerPrefs.SetString("piece", "cross");   
        }
        else
        {
            PlayerPrefs.SetString("piece", "circle");
        }
    }

    public void deletePlayerPrefs ()
    {
        PlayerPrefs.DeleteAll();
    }

}
