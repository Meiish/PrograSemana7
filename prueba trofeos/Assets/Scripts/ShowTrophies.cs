using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;
using GameJolt.UI;
using GameJolt.API.Objects;

public class ShowTrophies : MonoBehaviour
{
    void Start()
    {
        GameJoltUI.Instance.ShowTrophies();
    }
}