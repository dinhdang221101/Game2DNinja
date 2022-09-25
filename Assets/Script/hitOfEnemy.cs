using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitOfEnemy : MonoBehaviour
{
    public float slashDamage;
    private Rigidbody2D ef;

    void Awake(){
        ef = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            PlayerController hurtPlayer = other.gameObject.GetComponent<PlayerController>();
            hurtPlayer.addDamage(slashDamage);
        }
    }
}
