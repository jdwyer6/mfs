using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipTheBird : MonoBehaviour
{
    private Animator am;
    bool isFlippingBird;
    public float timeToPauseMovement = 1.5f;
    public GameObject colliderObj;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M) && !isFlippingBird) {
            StartCoroutine(InitiateBirdFlip());
        }
    }

    IEnumerator InitiateBirdFlip() {
        isFlippingBird = true;
        am.SetTrigger("FlipTheBird");
        GetComponent<PlayerController>().canMove = false;
        colliderObj.SetActive(true);
        yield return new WaitForSeconds(timeToPauseMovement);
        GetComponent<PlayerController>().canMove = true;
        isFlippingBird = false;
        colliderObj.SetActive(false);
    }
}
