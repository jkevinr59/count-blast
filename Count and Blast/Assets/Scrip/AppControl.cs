using UnityEngine;
using System.Collections;

public class AppControl : MonoBehaviour {

    AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = this.gameObject.GetComponent<AudioSource>();
        audio.Play();
        Screen.SetResolution(600, 1024, true);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
