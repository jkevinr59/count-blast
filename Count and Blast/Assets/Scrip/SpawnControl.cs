using UnityEngine;
using System.Collections;

public class SpawnControl : MonoBehaviour {
    private GameObject monster_kuning;
    private GameObject monster_biru;
    private ArrayList targeting_array;
    private int spawn_speed;
    private int target_index;
    private float spawntime;
	// Use this for initialization
	void Start () {

        target_index = 0;
        targeting_array = new ArrayList();
        monster_kuning = Resources.Load("Monster") as GameObject;
        spawn_monster();
        spawntime = Time.time + 3f;
	}

    void spawn_monster()
    {
        Enemy monster_properties = monster_kuning.GetComponent<Enemy>();
        monster_properties.en_pow = Random.Range(1, 9);
        float random_posX = Random.Range(-2.2f, 2.2f);
        monster_kuning.transform.position = new Vector3(random_posX, 6f);
        monster_properties.set_speed(0.15f);
        GameObject monster = Instantiate(monster_kuning) as GameObject;
        monster.name = "monster" + targeting_array.Count.ToString();
        targeting_array.Add(monster);

    }

    public GameObject current_target()
    {
        return targeting_array[target_index] as GameObject;
    }
    public void next()
    {
        target_index= (target_index + 1)%targeting_array.Count ;
    }
    public void prev()
    {
        target_index--;
        if (target_index < 0)
        {
            target_index = targeting_array.Count - 1;
        }
    }
	// Update is called once per frame
	void Update () {
        if (spawntime < Time.time)
        {
            spawn_monster();
            spawntime = Time.time + Random.Range(2f,4f);
        }
	}
}
