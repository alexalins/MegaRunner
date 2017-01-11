using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour {

    public Rigidbody2D PlayerRigidbody;
    public int forceJump;
    public Animator Anime;

    public bool jump;
    public bool slide;

    //verificar o chao
    public bool grounded;
    public LayerMask whatIsGround;
    public Transform GroundCheck;

    //slide
    public float slideTemp;
    public float timeTemp;

	//colisor
	public Transform colisor;

    //audio
    public AudioSource audio;
    public AudioClip soundJump;
    public AudioClip soundSlide;

    //pontuacao
    public static int pontuacao;
    public UnityEngine.UI.Text txtPontos;

	// Use this for initialization
	void Start () {
        pontuacao = 0;
        PlayerPrefs.SetInt("pontuacao", pontuacao);
       
    }
	
	// Update is called once per frame
	void Update () {

        txtPontos.text = pontuacao.ToString();
        //quando apertar o pulo no chao 
        if (Input.GetMouseButtonDown(0) && !grounded)
        {
			//tamanho do pulo
            PlayerRigidbody.AddForce(new Vector2(0,forceJump));

            audio.PlayOneShot(soundJump);//som pulo
			//para o colisor voltar a posicao depois do slide-pulo
			if (slide == true)
			{
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
				slide = false;
			}
        }
		//quando apertar o slide
        if (Input.GetMouseButtonDown(1) && !grounded && !slide)
        {
            audio.PlayOneShot(soundSlide);//som do slide
            //para colisor descer junto com slide
            colisor.position = new Vector3 (colisor.position.x, colisor.position.y - 0.3f, colisor.position.z);
            slide = true;
            timeTemp = 0;
            
        }

		//chao
        grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, whatIsGround);
        
        if(slide == true)
        {	//para passar 1 seg no slide e voltar a correr
            timeTemp += Time.deltaTime;
            if(timeTemp >= slideTemp)
            {
                slide = false;
				colisor.position = new Vector3 (colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
            }
        }

		//chamando as animacoes
        Anime.SetBool("jump", grounded);
        Anime.SetBool("slide", slide);
    }

	void OnTriggerEnter2D(){
        PlayerPrefs.SetInt("pontuacao", pontuacao);
        if(pontuacao > PlayerPrefs.GetInt("recorde"))//ver se eh maior q o recorde
        {
            PlayerPrefs.SetInt("recorde", pontuacao);
        }
        Application.LoadLevel("game_over"); 
	}
}
