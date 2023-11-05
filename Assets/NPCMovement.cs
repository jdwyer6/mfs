using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{

    public float idleTime = 2f; // Time the NPC stays idle
    public float walkTime = 3f; // Time the NPC walks
    private bool isWalking = false; // Current state of the NPC
    private Animator anim; // Animator component to control animations

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(ChangeState());
    }

    private IEnumerator ChangeState()
    {
        while (true)
        {
            yield return new WaitForSeconds(isWalking ? walkTime : idleTime);

            // Toggle the state between walk and idle
            isWalking = !isWalking;

            // Update the animator parameter to trigger the corresponding animation
            anim.SetBool("IsWalking", isWalking);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            anim.SetTrigger("Die");
        }
    }

}
