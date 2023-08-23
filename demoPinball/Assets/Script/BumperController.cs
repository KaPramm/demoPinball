using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public float maxVelocity;
    public Color color;
    public float score;

    public AudioManager audioManager;
    public VFXManager vfxManager;
    public ScoreManager scoreManager;
    private Animator animator;

    private void Start()
    {
        GetComponent<Renderer>().material.color = color;
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            
            bolaRig.velocity *= multiplier;
            bolaRig.maxLinearVelocity = maxVelocity;

            //BumperHitAnimation
            animator.SetTrigger("Hit");

            //PlaySFX
            audioManager.PlaySFX(collision.transform.position);

            //PlayVFX
            vfxManager.PlayVFX(collision.transform.position);

            //Scoring
            scoreManager.AddScore(score);
        }
    }
}