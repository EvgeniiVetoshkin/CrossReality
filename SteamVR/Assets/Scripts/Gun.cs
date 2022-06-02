using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Gun : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;

    public float speed = 40;
    public GameObject bullet;
    public Transform barrel;
    //public AudioSource audioSource;
    //public AudioClip audioClip;
    private Interactable interactable;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        if (interactable.attachedToHand != null)
        {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;
            if (fireAction[source].stateDown)
            {
                Fire();
            }
        }
    }
    public void Fire()
    {
        GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation * Quaternion.Euler(90,0,0));
        spawnedBullet.GetComponent<Rigidbody>().AddForce(barrel.transform.forward * speed, ForceMode.VelocityChange);
        //audioSource.PlayOneShot(audioClip);
        Destroy(spawnedBullet, 4);
    }
}