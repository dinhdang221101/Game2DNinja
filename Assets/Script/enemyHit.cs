using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHit : MonoBehaviour
{

    public GameObject enemy;
    private Animator Aenemy;
    public GameObject Player;

    public GameObject efSlashing;
    float slashRate = 0.5f;
    float nextSlash = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Aenemy = enemy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            StartCoroutine(isAttack());
        }
    }

    IEnumerator isAttack(){
        yield return new WaitForSeconds(1f);
        if(!Aenemy.GetBool("isTake") ){
            if(Time.time > nextSlash){
                Aenemy.SetBool("isSee", true);
                nextSlash = Time.time + slashRate;
                Instantiate(efSlashing, transform.position, Quaternion.Euler(new Vector3(0,0,0)));
            }
        }
        yield return new WaitForSeconds(1f);
        Aenemy.SetBool("isSee", false);
    }
}
