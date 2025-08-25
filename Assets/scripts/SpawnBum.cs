using System.Collections;
using UnityEngine;

public class SpawnBum : MonoBehaviour
{
    public GameObject bombPrefab; //”š’e‚ÌƒvƒŒƒnƒu
    public float spawnInterval = 2.0f; //”š’e‚Ì¶¬ŠÔŠu

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBomb());
    }

    IEnumerator SpawnBomb()
    {
        while (true) 
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
