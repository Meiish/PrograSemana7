using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.UI;

public class ShowRanking : MonoBehaviour
{
    void Start()
    {
        GameJoltUI.Instance.ShowLeaderboards();
    }
}
