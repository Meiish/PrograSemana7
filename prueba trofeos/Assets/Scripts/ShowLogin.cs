using GameJolt.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowLogin : MonoBehaviour
{

    private void Start()
    {
        GameJoltUI.Instance.ShowSignIn(Onsinging);
    }

    private void Onsinging(bool success)
    {
        if(success) 
        {
            SceneManager.LoadScene("MainMenu");
        }

        else
        {
            Debug.Log("no se pudo");
        }
    }
}
