using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneSelectScript : MonoBehaviour
{
    public void selectScene()
    {
        switch (this.gameObject.name)
        {
            case "Button":
                SceneManager.LoadScene("SampleScene");
                break;

            case "HowTo":
                SceneManager.LoadScene("HowToPlayGame");
                break;

            case "PauseMenu":
                SceneManager.LoadScene("PauseMenu");
                break;


        }
    }
}
