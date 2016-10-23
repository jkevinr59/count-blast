using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    private float speed;
    private GameObject direction_target;
    private Vector3 direction;
    private int power;
	// Use this for initialization
	void Start () {
        speed = 3f;

        this.direction = direction_target.transform.position - this.transform.position;
	}

    public void set_power(int pow)
    {
        this.power = pow;
    }
	// Update is called once per frame
    public void set_target(GameObject target)
    {
        this.direction_target = target;
        this.direction = direction_target.transform.position - this.transform.position;

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = direction_target.GetComponent<Enemy>();
       // Debug.Log(enemy.en_pow.ToString() + " " + this.power.ToString());
        if (enemy.en_pow == this.power && collision.gameObject == direction_target)
        {
            Destroy(direction_target);
        }
        Destroy(this.gameObject);
    }
	void Update () {
        if (direction_target != null)
        {
            this.transform.position += direction * speed * Time.deltaTime;

        }
        else if (direction_target == null)
        {
            Destroy(this.gameObject);
        }
	}
}
