using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public KeyCode launch;
    public Collider bola;

    public Material maxTriggerMaterial;
    public Material lowTriggerMaterial;

    public float maxTimeHold;
    public float maxForce;

    private bool isHold = false;
    private Renderer renderer;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == bola)
        {
            renderer = GetComponent<Renderer>();
            ReadInput(bola);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(launch) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float force = 0.0f;
        float timeHold = 0.0f;

        while (Input.GetKey(launch))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
            
            if (timeHold > maxTimeHold)
            {
                renderer.material = maxTriggerMaterial;
            }
            else
            {
                renderer.material = lowTriggerMaterial;
            }
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
        renderer.material = lowTriggerMaterial;
    }
}