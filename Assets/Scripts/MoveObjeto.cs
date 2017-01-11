using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjeto : MonoBehaviour {

    public float speed;
    private float x;
    public GameObject Player;
    private bool pontuado;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        // faz o objeto andar mudando o X
        x = transform.position.x;
        x += speed + Time.deltaTime;

        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        if(x <= -7)
        {
            Destroy(transform.gameObject);
        }

        //verificar se player passou do objeto
        if(x < Player.transform.position.x && pontuado == false)//false aqui pra pontuar uma vez
        {
            pontuado = true;
            PlayerContoller.pontuacao++;
        }
	}
}
