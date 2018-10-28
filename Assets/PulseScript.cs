using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseScript : MonoBehaviour {



    public GameObject whiteCellPrefab;

    public List<GameObject> spawnedCells;

    void Awake()
    {
        spawnedCells = new List<GameObject>();
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(PulseRoutine());

        for(int i = 0; i < 50; i++)
        {
            Vector3 loc = transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)) * Random.Range(0, 10);
            spawnedCells.Add(Instantiate(whiteCellPrefab, loc, Quaternion.identity));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator PulseRoutine()
    {
        Light l = GetComponentInChildren<Light>();

        while (true)
        {
            //Debug.Log("Pulse");
            Vector3 startScale = transform.localScale;
            float startRange = l.range;


            for (int i = 0; i < 30; i++)
            {
                transform.localScale += Vector3.one * 0.15f;
                l.range += 1f;
                yield return null;

            }

            for (int i = 0; i < 30; i++)
            {
                transform.localScale -= Vector3.one * 0.15f;
                l.range -= 1f;
                yield return null;

            }

            transform.localScale = startScale;
            l.range = startRange;


            for (int i = 0; i < 3; i++)
            {
                Vector3 loc = transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)) * Random.Range(0, 10);
                spawnedCells.Add(Instantiate(whiteCellPrefab, loc, Quaternion.identity));
            }

            yield return new WaitForSeconds(2);

        }

    }
}
