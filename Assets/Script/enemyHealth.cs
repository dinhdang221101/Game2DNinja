using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float speed = 0.3f;
    private Rigidbody2D bodyE;

    public float maxHealth;
    float curHealth;

    private Animator anim;

    public GameObject enemyDeath;

    public Slider EHSlider;
    // Start is called before the first frame update
    void Start()
    {
        bodyE = GetComponent<Rigidbody2D>();
        curHealth = maxHealth;
        anim = GetComponent<Animator>();

        EHSlider.maxValue = maxHealth;
        EHSlider.value = maxHealth;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine (Move());
        anim.SetBool("isTake", false);
    }

    public void addDamage(float damage){
        curHealth -= damage;
        
        if(curHealth <= 0){
            makeDead();
        }
    }

    void makeDead(){
        
        Destroy(gameObject);
        Instantiate(enemyDeath, transform.position, transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other){
        
        if(other.tag == "slashing"){
            anim.SetBool("isTake", true);
            EHSlider.value = curHealth;
        }
    }

    

    IEnumerator Move(){
        
        yield return new WaitForSeconds(0f);
        Vector3 movement = Vector3.zero;
        if(transform.rotation.y == 0){
            yield return new WaitForSeconds(3f);
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.rotation =  Quaternion.Euler(0, 180, 0);
            
        }
        else{
            yield return new WaitForSeconds(3f);
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.rotation =  Quaternion.Euler(0, 0, 0);
            
        } 
    }
}
