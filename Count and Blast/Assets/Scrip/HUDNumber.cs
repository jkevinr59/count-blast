using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDNumber : MonoBehaviour {

    public GameObject tower;
    private Text txt;
    private Tower tower_scr;
	// Use this for initialization
	void Start () {
        txt = this.GetComponent<Text>();
        tower_scr = tower.GetComponent<Tower>();
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = tower_scr.get_power().ToString();
	}
}
