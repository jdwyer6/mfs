using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float idleTime = 2f;  // Time the NPC stays idle
    public float walkTime = 3f;  // Time the NPC walks
    private bool isWalking = false;  // Current state of the NPC
    private Animator anim;  // Animator component to control animations
    private Vector3 randomDirection;  // Random direction to move in
    bool isAlive = true;

    public string[] fallAnimations;
 
    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(ChangeState());
        isAlive = true;
        idleTime += UnityEngine.Random.Range(1, 10);
        walkTime += UnityEngine.Random.Range(1, 10);
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

            if (isWalking)
            {
                // Generate a random direction
                randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MF"))
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die() {
        yield return new WaitForSeconds(.6f);
        anim.SetTrigger(fallAnimations[UnityEngine.Random.Range(0, fallAnimations.Length)]);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<CapsuleCollider>().enabled = false;
        isAlive = false;
    }

    private void Update()
    {
        if (isWalking && isAlive)
        {
            // Calculate the rotation angle based on the movement direction
            float targetAngle = Mathf.Atan2(randomDirection.x, randomDirection.z) * Mathf.Rad2Deg;

            // Rotate the NPC to face the direction they are walking
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            // Move the NPC in the random direction when walking
            transform.Translate(randomDirection * Time.deltaTime, Space.World);
        }
    }
}
