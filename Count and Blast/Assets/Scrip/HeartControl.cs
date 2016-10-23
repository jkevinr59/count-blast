using UnityEngine;
using System.Collections;

public class HeartControl : MonoBehaviour {

	private int HP;
    // Use this for initialization
	void Start () {
        HP= 5;
	}

    public void Hit()
    {
        HP--;
    }

    void Game_Over()
    {
        GameObject Text_prefab = Resources.Load("GameOverText") as GameObject;
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject txt = Instantiate(Text_prefab);
        txt.transform.SetParent(canvas.transform,false);
        Time.timeScale = 0;
        //Debug.Log("Game Over!!");
    }
	// Update is called once per frame
	void Update () {
        if (HP == 0)
            this.Game_Over();
	}
}
