using System.Collections;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor.Callbacks;
#endif
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    [SerializeField]
    private float horizontalInput;
    [SerializeField]
    private float slideSuresi=0.5f;
    
    [SerializeField]
    Rigidbody2D rb;
    
    [SerializeField]
    private float attackSuresi=0.2f;

    [SerializeField]
    private float jumpSuresi=0.2f;
    Animator anim;

    [SerializeField]
    private Collider2D attackHitbox;
    
    [SerializeField]
    float speed=5f;

    [SerializeField]
    float jumpForce=5f;

    [SerializeField]
    private bool isWalking=false;

    [SerializeField]
    private bool isAttacking=false;

    [SerializeField]
    private bool isJumping=false;

    [SerializeField]
    private bool isSliding=false;

    [SerializeField]
    private bool isAlive=true;

    [SerializeField]
    private bool isGrounded;

    [SerializeField]
    private int lives=3;

    [SerializeField]
    private bool hasDecDamage=false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        rb.freezeRotation=true;
        attackHitbox.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            return;
        }

        if(Input.GetKey(KeyCode.W) && isGrounded)
        {
            rb.velocity=new Vector2(rb.velocity.x,jumpForce); 
            Jump();
            Debug.Log("Zıplama başarılı");
        }

        Move();

        if (Input.GetKey(KeyCode.E) && !isAttacking && !isSliding)
        {
            Attack();
        }

        if(Input.GetKey(KeyCode.X) && !isSliding && isGrounded)
        {
            Slide();
        }
    }

     void OnCollisionEnter2D(Collision2D other)
    {
        
        Debug.Log("Zemin");
       
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded=true;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy")&& isAttacking && !hasDecDamage)
        {
            other.GetComponent<Enemy_sc>().Damage();
            hasDecDamage=true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Havada");
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded=false;
        }
    }


    void Move()
    {
        horizontalInput=Input.GetAxis("Horizontal");
        //verticalInput=Input.GetAxis("Vertical");
        rb.velocity=new Vector2(horizontalInput*speed,rb.velocity.y);
        
        if (horizontalInput!=0 )
        {
            anim.SetBool("isWalking",true);
            isWalking=true;
        }
        else
        {
            anim.SetBool("isWalking",false);
            isWalking=false;
        }


    }

    void Attack()
    {
        Debug.Log("Attack fonksiyonu çalıştı");
        isAttacking=true;
        anim.SetBool("isAttacking",true);
        SFXManager_sc.instance.PlayAttack();
        attackHitbox.enabled=true;
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(attackSuresi);
        anim.SetBool("isAttacking",false);
        isAttacking=false;
        attackHitbox.enabled=false;
        hasDecDamage=false;
    }


    void Jump()
    {
        anim.SetTrigger("isJumping");
        SFXManager_sc.instance.PlayJump();
        StartCoroutine(JumpRoutine());
    }

    IEnumerator JumpRoutine()
    {
        yield return new WaitForSeconds(jumpSuresi);
        anim.SetBool("isJumping",false);
        isJumping=false;
    }

    public void Damage()
    {
        if (!isAlive)
        {
            return;
        }
        
        lives--;

        if (lives == 0)
        {
            Debug.Log("Öldün");
            isAlive=false;
            anim.SetBool("isAlive",false);
            SFXManager_sc.instance.PlayDeath();
            Destroy(this.gameObject);
        }
    }

    void Slide()
    {
        Debug.Log("Slide çalıştı");
        isSliding=true;
        anim.SetBool("isSliding",true);
        speed*=1.6f;
        StartCoroutine(SlideRoutine());
    }

    IEnumerator SlideRoutine()
    {
        yield return new WaitForSeconds(slideSuresi);
        anim.SetBool("isSliding",false);
        speed/=1.6f;
        isSliding=false;
    }

}
