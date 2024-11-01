using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    private int count;
    private bool isDead;

    // Variables para controlar el desbloqueo único de cada trofeo
    private bool silverTrophyUnlocked = false;
    private bool goldTrophyUnlocked = false;
    private bool platinumTrophyUnlocked = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            count++;
            rb.AddForce(speed*Vector3.up,ForceMode.Impulse);
            ScoreUi.Instance.UpdateScore(count);
        }
        CheckForTrophies();
    }
    private void CheckForTrophies()
    {
        // Trofeo de plata
        if (count >= 5 && !silverTrophyUnlocked)
        {
            Trophies.Unlock(246743);
            silverTrophyUnlocked = true; // Evita desbloquearlo nuevamente
        }

        // Trofeo de oro
        if (count >= 10 && !goldTrophyUnlocked)
        {
            Trophies.Unlock(246742);
            goldTrophyUnlocked = true;
        }

        // Trofeo de platinum
        if (count >= 20 && !platinumTrophyUnlocked)
        {
            Trophies.Unlock(246748);
            platinumTrophyUnlocked = true;
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (isDead)
        {
            return;
        }
        isDead = true;
        GameManager.Instance.UpdateScore(count);
        Scores.Add(count, $"Clic count: {count}", 947229, "", OnCallback);
        
    }

    private void OnCallback(bool success)
    {
        Destroy(gameObject);
        GameManager.Instance.GameOver();
    }
}
