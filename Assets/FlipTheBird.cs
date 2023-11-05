using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTheBird : MonoBehaviour
{
    private Animator anim;
    bool isFlippingBird;
    public float timeToPauseMovement = 1.5f;
    public GameObject colliderObj;

    private AudioManager am;
    public float timeBeforeImpact = .6f;
    public string[] impactSounds;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        am = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !isFlippingBird) {
            StartCoroutine(InitiateBirdFlip());
        }
    }

    IEnumerator InitiateBirdFlip() {
        StartCoroutine(BirdFlipImpact());
        isFlippingBird = true;
        anim.SetTrigger("FlipTheBird");
        GetComponent<PlayerController>().canMove = false;
        colliderObj.SetActive(true);
        yield return new WaitForSeconds(timeToPauseMovement);
        GetComponent<PlayerController>().canMove = true;
        isFlippingBird = false;
        colliderObj.SetActive(false);
    }

    IEnumerator BirdFlipImpact() {
        yield return new WaitForSeconds(timeBeforeImpact);

        am.Play(impactSounds[UnityEngine.Random.Range(0, impactSounds.Length)]);
    }
}
