using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public Collider bola;
    public Material onMaterial;
    public Material offMaterial;
    public float score;

    public AudioManager audioManager;
    public ScoreManager scoreManager;

    private bool isOn;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();

        isOn = false;
        renderer.material = offMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == bola)
        {
            StartCoroutine(blink(2));

            audioManager.PlaySFX(other.transform.position);
            scoreManager.AddScore(score);
        }

    }

    private void set(bool active)
    {
        isOn = active;
        if (isOn == true)
        {
            renderer.material = onMaterial;
        }
        else
        {
            renderer.material = offMaterial;
        }
    }

    private IEnumerator blink(int times)
    {
        int blinkTimes = times * 2;
        for (int i = 0; i < blinkTimes;i++)
        {
            set(!isOn);
            yield return new WaitForSeconds(0.2f);
        }
        
    }
}
