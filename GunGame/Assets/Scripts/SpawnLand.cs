using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLand : MonoBehaviour
{
    public List<GameObject> plots;
    private float lastZpos = 0;
    public float plotSize = 20f;
    public void SpawnPlot()
    {
        Debug.Log("Spawning");
        GameObject plot = plots[Random.Range(0, plots.Count)];
        float zPos = lastZpos + plotSize;
        Instantiate(plot, new Vector3(0, 0.025f, zPos), plot.transform.rotation);
        lastZpos += plotSize;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("In");
        if (other.gameObject.CompareTag("SpawnTrigger"))
        {
            SpawnPlot();
            Destroy(other.gameObject);
        }
    }
}
