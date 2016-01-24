using UnityEngine;
using CnControls;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    [SerializeField] GameObject igralec;
    private float playerSpeed = 7.5f;
    [SerializeField] Rigidbody rigitBody;
    private int smer;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //if (smer==1) Debug.Log(smer);
        //premik igralca naprej-nazaj
        float newXcordinate = igralec.transform.forward.x * smer * playerSpeed * Time.deltaTime;
        float newZcordinate = igralec.transform.forward.z * smer * playerSpeed * Time.deltaTime;
        rigitBody.MovePosition(igralec.transform.position + new Vector3(newXcordinate, 0, newZcordinate));
    }

    public void premik(int sm){
        //Debug.Log(smer);
        //sm je 1-naprej, 0-stoj in -1-nazaj
        smer = sm;
    }
}
