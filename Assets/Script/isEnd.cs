using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isEnd : MonoBehaviour
{
    private Animator anim;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            anim.SetBool("isChecked", true);
            GetComponent<AudioSource>().Play();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
