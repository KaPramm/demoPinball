using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampTriggerController : MonoBehaviour
{
    public Collider bola;
    public float score;

    public ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            scoreManager.AddScore(score);
        }
    }
}
