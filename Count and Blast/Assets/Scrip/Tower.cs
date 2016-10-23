using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

    private int cannon_power;
    private int cannon_type;
    private GameObject control;
    private GameObject prefab;
    private SpawnControl spawner;
    private GameObject target;
	// Use this for initialization
    void Start()
    {
        cannon_power = 1;
        prefab = Resources.Load("Cannon") as GameObject;
        control = GameObject.FindGameObjectsWithTag("GameController")[0];
        spawner = control.GetComponent<SpawnControl>();
        target = spawner.current_target();
        Enemy targetset = target.GetComponent<Enemy>();
        targetset.set_targeting(1);
    }
    public void Add_Power()
    {
        if (cannon_power < 10)
        {
            cannon_power++;
        }

    }
    public void Reduce_Power()
    {
        if (cannon_power > 0)
        {
            cannon_power--;
        }

    }
	// Update is called once per frame

    public int get_power()
    {
        return this.cannon_power;
    }
    public void fire_cannon()
    {
        GameObject Can_1 = Instantiate(prefab) as GameObject;
        Can_1.transform.position = this.transform.position;
        Projectile can_pow = Can_1.GetComponent<Projectile>();
        can_pow.set_target(target);
        can_pow.set_power(cannon_power);
    }
	void Update () {
        if (target == null)
        {
            spawner.next();
            target = spawner.current_target();
            Enemy targetset = target.GetComponent<Enemy>();
            targetset.set_targeting(1);
        }
        else if (target.name != spawner.current_target().name)
        {
            Enemy targetset = target.GetComponent<Enemy>();
            targetset.set_targeting(0);
            target = spawner.current_target();
            targetset = target.GetComponent<Enemy>();
            targetset.set_targeting(1);
        }
	}
}
