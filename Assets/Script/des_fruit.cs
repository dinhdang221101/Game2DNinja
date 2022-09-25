using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class des_fruit : MonoBehaviour
{
    private Animator anim;
    public GameObject fruitCollected;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            anim.SetBool("isCollected", true);
            Destroy(gameObject);
            Instantiate(fruitCollected, transform.position, transform.rotation);
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
