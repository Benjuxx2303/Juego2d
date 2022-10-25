using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    public float velocidad = 5;
    public float salto = 5;
    private Rigidbody2D fisicas;
    private Animator _animator;
    bool enSuelo;
    
    void Start(){
        enSuelo = true;
        fisicas = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update(){
        var ejeX = Input.GetAxis("Horizontal");
        
        transform.Translate(new Vector2(ejeX, 0) * (Time.deltaTime * velocidad));
        
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo){
            fisicas.AddForce(new Vector2(0, salto), ForceMode2D.Impulse);
            enSuelo = false;
            _animator.SetBool("salto", true);
        }

        // Mirar Abajo (Test)
        /*
        if (Input.GetKeyDown(KeyCode.S)){
            _animator.SetBool("mirarAbajo", true);
        } else{
            _animator.SetBool("mirarAbajo", false);
        }
        */
        
        _animator.SetFloat("derecha", Mathf.Abs(ejeX));
        if (ejeX < 0) {
            transform.localScale = new Vector3(-2, 2, 2);
            
        }else if (ejeX > 0) {
            transform.localScale = new Vector3(2, 2, 2);
        }
    }
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Suelo")){
            enSuelo = true;
            _animator.SetBool("salto", false);
        }
    }
}

