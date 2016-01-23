using UnityEngine;
using CnControls;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    [SerializeField] GameObject igralec;
    private float playerSpeed = 10.0f;
    int x, y;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //premik igralca
        Vector3 premik = igralec.transform.forward * CnInputManager.GetAxis("Vertical");
        premik+=igralec.transform.right * CnInputManager.GetAxis("Horizontal");
        igralec.transform.position = igralec.transform.position + premik;
        if (CnInputManager.GetAxis("Vertical") != 0) Debug.Log("leva");
    }
}
