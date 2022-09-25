using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
        //move player
        public float movePower = 5;
        public float jumpPower = 5; 
        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private float direction = 0.7f;
        bool isJumping = false;
        public int jumpMax; 
        private int jumpCount;
        

        //player attack
        public Transform sword;
        public GameObject efSlashing;
        float slashRate = 0.5f;
        float nextSlash = 0f;

        //hp player
        public float maxHealth;
        float curHealth;
        public Slider PHSlider;

        //restart
        private bool restart;
        public Text restartText;
        public Text winText;
        public Text failtext;
        private bool won;

        void Start()
        {
            
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            jumpMax = 2;
            jumpCount = 0;

            curHealth = maxHealth;
            PHSlider.maxValue = maxHealth;
            PHSlider.value = maxHealth;

            restart = false;
            restartText.text = "";
            failtext.text = "";
            winText.text = "";
            won = false;
        }

        private void Update()
        {
            if(restart){
                failtext.text = "Fail!!!";
                restartText.text = "restarted by pressing the key 'S'";
                if (Input.GetKeyDown (KeyCode.S))
                {
                    Application.LoadLevel (Application.loadedLevel);
                }
            }
            if(won){
                winText.text = "Win!!!";
                restartText.text = "restarted by pressing the key 'S'";
            }
            Jump();
            Run();
            Attack();
            isDeath();
        }

        void FixedUpdate(){
            anim.SetBool("isTake", false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Cham dat thi bo trang thai Jump
            if(other.tag == "Ground" || other.tag == "enemy"){
                
                jumpCount = 0;
                anim.SetBool("isJump", false);
                anim.SetBool("isHJump", false);
                isJumping = false;
            }

            if(other.tag == "vucTham"){
                anim.SetBool("isDie", true);
                PHSlider.value = 0;
                Destroy(gameObject, 0.5f);
                restart = true;
                GetComponent<AudioSource>().Play();
            }

            if(other.tag == "Finish"){
                won = true;
            }

            if(other.tag == "fruit"){
                if(curHealth < 100){
                    curHealth = curHealth + 10;
                }
                PHSlider.value = curHealth;
            }
            
        }
        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);
            

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                
                moveVelocity = Vector3.left;
                // Xoay qua trai
                direction = -0.7f;
                transform.localScale = new Vector3(direction, 0.7f, 0.7f);
                if (!anim.GetBool("isJump")){
                    // Dang nhay khong duoc chay
                    anim.SetBool("isRun", true);
                }
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                moveVelocity = Vector3.right;
                // Xoay qua phai
                direction = 0.7f;
                transform.localScale = new Vector3(direction, 0.7f, 0.7f);
                if (!anim.GetBool("isJump")){
                    // Dang nhay khong duoc chay
                    anim.SetBool("isRun", true);
                }
            }

            transform.position += moveVelocity * movePower * Time.deltaTime;
        }

        void Jump()
        {
            if (Input.GetButtonDown("Jump") && jumpCount < jumpMax)  // Chi nhay 1 lan
            {
                GetComponent<AudioSource>().Play();
                if(anim.GetBool("isJump")){
                    anim.SetBool("isHJump", true);
                    anim.SetBool("isJump", false);
                }
                isJumping = true;
                anim.SetBool("isJump", true);
                jumpCount +=1;
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }  

        void Attack(){
            anim.SetBool("isAttack", false);
            anim.SetBool("isAttackRun", false);
            if (!anim.GetBool("isJump") && !anim.GetBool("isRun") && !anim.GetBool("isTake")){
                // Dang nhay khong duoc chem
                if(Input.GetKey(KeyCode.Z)){
                    anim.SetBool("isAttack", true);
                    isSlash();
                }
            }

            else if(!anim.GetBool("isJump") && anim.GetBool("isRun") && !anim.GetBool("isTake")){
                // Dang nhay khong duoc chem
                if(Input.GetKey(KeyCode.Z)){
                    anim.SetBool("isAttackRun", true);
                    isSlash();
                }
            } 
        }  

        void isSlash(){
            if(Time.time > nextSlash){
                nextSlash = Time.time + slashRate;
                efSlashing.transform.localScale = new Vector3(-direction, 0.7f, 0.7f);
                Instantiate(efSlashing, sword.position, Quaternion.Euler(new Vector3(0,0,0)));
            }
        }

        void isDeath(){
            if(curHealth == 0){
                anim.SetBool("isDie", true);
                PHSlider.value = 0;
                GetComponent<AudioSource>().Play();
                Destroy(gameObject, 1f);
                restart = true;
                
            }
        }

        public void addDamage(float damage){
            anim.SetBool("isTake", true);
            curHealth -= damage;
            PHSlider.value = curHealth;
            if(curHealth <= 0){
                isDeath();
            }
        }
}
