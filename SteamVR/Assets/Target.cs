using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject exlosionEffect;
    public MeshRenderer mesh;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            //Instantiate(exlosionEffect, transform.position, transform.rotation);
            //Destroy(gameObject);

            StartCoroutine(Explosion());
        }
    }

    IEnumerator Explosion()
    {
        GameObject particle = Instantiate(exlosionEffect, transform.position, transform.rotation);
        mesh.enabled = false;

        yield return new WaitForSeconds(2);
        
        DestroyImmediate(particle);
        Destroy(gameObject);
        
        //Destroy(particle);
    }
}
