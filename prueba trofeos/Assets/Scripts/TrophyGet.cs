using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;


public class TrophyGet : MonoBehaviour
{
    private void Start()
    {
        Trophies.Unlock(246744);
    }
}
