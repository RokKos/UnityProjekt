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

        //rotacija SAMO KAMERE gor-dol
        Vector3 rotationAngles;
        rotationAngles.y = 0;
        rotationAngles.z = 0;
        //rotationAngles.z = -1 * CnInputManager.GetAxis("Vertical") * igralec.transform.forward.x * playerRotateSpeed * Time.deltaTime;
        rotationAngles.x = -1 * CnInputManager.GetAxis("Vertical") * playerRotateSpeed * Time.deltaTime;
        cam.transform.Rotate(rotationAngles, Space.Self);

        //omejitev rotacije kamere gor-dol, maksimum je 35st
        //Debug.Log(cam.transform.localEulerAngles.x);
        if (cam.transform.localEulerAngles.x < 325 && cam.transform.localEulerAngles.x > 180) {
            cam.transform.Rotate(325 - cam.transform.localEulerAngles.x, 0, 0, Space.Self);
        }
        if (cam.transform.localEulerAngles.x > 35 && cam.transform.localEulerAngles.x < 180)
        {
            cam.transform.Rotate(35 - cam.transform.localEulerAngles.x, 0, 0, Space.Self);
        }
    }
}
