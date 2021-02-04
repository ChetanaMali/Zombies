using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip[] smashSound;
    private AudioSource audioSource;
    public GameObject bloodEffect;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            //We will recast here.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //we reated our ray.
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction); // ray of main camera from origin to direction.

            if (hit.collider != null)                                  // When we hit something is not null
            {
                if (hit.collider.tag == "Enemy")                      // when we only hit enemy.
                {
                    //This code is for sound.
                    audioSource.PlayOneShot(smashSound[0], 0.5f);
                    //this code for hit the enemy.
                    gameObject.GetComponent<GameManeger>().killEnemy();

                    //Debug.Log("We hit somthing..!");
                    Camera.main.GetComponent<Animator>().SetTrigger("Shake");
                     DisplayBloodEffect(Camera.main.ScreenToWorldPoint(Input.mousePosition)); // this code for Blood Effect.
                }
            }
        }
    }

    private void DisplayBloodEffect(Vector2 pos) 
    {
        bloodEffect.transform.position = pos;
        bloodEffect.GetComponent<Animator>().SetTrigger("Smashed");
    }
}
