using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int en_pow;
    public float speed;
    public Sprite form1;
    public Sprite form2;
    public Sprite form3;
    public Sprite form4;
    public Sprite form5;
    public Sprite form6;
    public Sprite form7;
    public Sprite form8;
    public Sprite form9;
    private SpriteRenderer sr;
    private int targetState;
    private GameObject c_hair;
    private GameObject cross;
    public void set_pow(int pow)
    {
        this.en_pow = pow;
    }
    public void set_speed(float s)
    {
        this.speed = s;
    }
	// Use this for initialization
	void Start () {
        sr = this.gameObject.GetComponent<SpriteRenderer>();

	}
    public void set_targeting(int state)
    {
        this.targetState = state;
    }
    private void set_crosshair(int state)
    {
        if (state == 1 && c_hair == null)
        {
            cross = Resources.Load("crosshair") as GameObject;
            c_hair = Instantiate(cross) as GameObject;
            c_hair.transform.position = this.transform.position;
        }

        else if (state == 0)
        {
            Destroy(c_hair);
        }
    }

    void OnDestroy()
    {
        Destroy(c_hair);
    }
	// Update is called once per frame
	void Update () {
        if      (en_pow == 1) {sr.sprite = form1;}
        else if (en_pow == 2) {sr.sprite = form2;}
        else if (en_pow == 3) {sr.sprite = form3;}
        else if (en_pow == 4) {sr.sprite = form4;}
        else if (en_pow == 5) {sr.sprite = form5;}
        else if (en_pow == 6) {sr.sprite = form6;}
        else if (en_pow == 7) {sr.sprite = form7;}
        else if (en_pow == 8) {sr.sprite = form8;}
        else if (en_pow == 9) {sr.sprite = form9;}

        set_crosshair(this.targetState);
        if (c_hair != null)
        {
            c_hair.transform.position = this.transform.position;
        }

        this.transform.position += new Vector3(0f, -8f) * speed*Time.deltaTime;

        if (this.transform.position.y < -1.5f)
        {
            GameObject control = GameObject.FindGameObjectWithTag("GameController");
            HeartControl H_control = control.GetComponent<HeartControl>();
            H_control.Hit();
            Destroy(this.gameObject);
        }
	}
}
