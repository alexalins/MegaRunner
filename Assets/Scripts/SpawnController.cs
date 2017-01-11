using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    public GameObject barreiraPrefab; //Objeto Spawnar
    public float rateSpawn; // intervalo de spawn
    public float currentTime; //variavel de tempo
    private int posicao;
    private float y;
    public float posA;
    public float posB;

	// Use this for initialization
	void Start () {
        currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if(currentTime >= rateSpawn)
        {
            currentTime = 0;
            posicao = Random.Range(1,100);
      
            if(posicao > 50)// maior q 50 aparece no alto
            {
                y = posA;//-1.1f; menos sobe -2.19

            }
            else//menor aparece no chao
            {
                y = posB;//-2.7f;mais desce
            }

            GameObject tempPrefab = Instantiate(barreiraPrefab) as GameObject; // coçocando p spawn
            tempPrefab.transform.position = new Vector3(transform.position.x, y, tempPrefab.transform.position.z);
        }
	}
}
