using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slashing : MonoBehaviour
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
        if(other.tag == "enemy"){
            enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
            hurtEnemy.addDamage(slashDamage);
        }
    }
}
