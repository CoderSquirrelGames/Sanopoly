using UnityEngine;
using System.Collections;

public class LoadTest : MonoBehaviour {
    Texture2D[] textures;

	// Use this for initialization
	void Start () {
        Texture2D texture = Resources.Load("Graphics/Dice/1") as Texture2D;

        renderer.material.mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
