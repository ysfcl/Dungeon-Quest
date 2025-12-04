using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    private float _speed=5f;
    
    [SerializeField]
    private float _attackSuresi=0.18f;

    Rigidbody2D _rb;

    [SerializeField]
    private Collider2D _attackHitbox;
    Animator _anim;

    [SerializeField]
    private bool _isWalking=false;

    [SerializeField]
    private bool _isAttacking=false;

    [SerializeField]
    private bool _isHit=false;

    [SerializeField]
    private bool _isAlive=true;

    [SerializeField]
    private int lives=3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb=GetComponent<Rigidbody2D>();
        _anim=GetComponent<Animator>();
        _rb.freezeRotation=true;
        _attackHitbox.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isAlive)
        {
            return;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& _isAttacking)
        {
            other.GetComponent<Player_sc>().Damage();
        }
        
    }

    public void Damage()
    {
        //Player_sc _player_sc=GetComponent<Player_sc>();

        if (!_isAlive)
        {
            return;
        }
       Debug.Log("Damage tetiklendi! Can öncesi: " + lives);
        lives--;
 Debug.Log("Can sonrası: " + lives);
        if (lives > 0)
        {
            Debug.Log("Hit çalıştı");
            _anim.SetTrigger("isHit");    
        }

        else
        {
           _isAlive=false;
            _anim.SetBool("isAlive",false);
            
            StartCoroutine(DieRoutine());
        }
    }
    
    IEnumerator DieRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    void Attack()
    {
        _isAttacking=true;
        _attackHitbox.enabled=true;
        _anim.SetBool("isAttacking",true);
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(_attackSuresi);
        _attackHitbox.enabled=false;
        _anim.SetBool("isAttacking",false);
        _isAttacking=false;
    }
}
