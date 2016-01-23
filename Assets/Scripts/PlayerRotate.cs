using UnityEngine;
using CnControls;
using System.Collections;

public class PlayerRotate : MonoBehaviour {
    [SerializeField] GameObject igralec;
    [SerializeField] Camera cam;
    //kotna hitrost vrtenja igralca v stopinjah
    private float playerRotateSpeed = 30.0f;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //rotacija igralca in kamere levo-desno
        float rotateY = CnInputManager.GetAxis("Horizontal") * playerRotateSpeed * Time.deltaTime;
        igralec.transform.Rotate(0, rotateY, 0, Space.World);
        cam.transform.Rotate(0, rotateY, 0, Space.World);
        //Debug.Log(igralec.transform.forward.x.ToString() + igralec.transform.forward.z.ToString());

        /*if (Input.GetKey(KeyCode.RightArrow))
        {
            cam.transform.Rotate(0, playerRotateSpeed  * Time.deltaTime, 0, Space.World);
            igralec.transform.Rotate(0, playerRotateSpeed * Time.deltaTime, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            cam.transform.Rotate(0, -1 * playerRotateSpeed * Time.deltaTime, 0, Space.World);
            igralec.transform.Rotate(0, -1 * playerRotateSpeed * Time.deltaTime, 0, Space.Self);
        }*/

        //rotacija SAMO KAMERE gor-dol
        Vector3 rotationAngles;
        rotationAngles.y = 0;
        rotationAngles.z = 0;
        //rotationAngles.z = -1 * CnInputManager.GetAxis("Vertical") * igralec.transform.forward.x * playerRotateSpeed * Time.deltaTime;
        rotationAngles.x = -1 * CnInputManager.GetAxis("Vertical") * playerRotateSpeed * Time.deltaTime;
        cam.transform.Rotate(rotationAngles, Space.Self);
        //igralec.transform.Rotate(rotationAngles, Space.Self);
    }
}
