using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
//    Vector3 OriginalPosition, ZoomPosition;
//    GameObject piece;
	// Use this for initialization
	void Start () {
    //    OriginalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Zoom();
            }
        
	}


    public void Zoom()
    {
//        Camera.main.transform.position = piece.transform.position;
    }
}
