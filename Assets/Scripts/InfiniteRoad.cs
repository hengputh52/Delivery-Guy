using UnityEngine;
using System.Collections.Generic;

public class InfiniteRoad : MonoBehaviour
{
    public GameObject roadPrefab;
    public List<GameObject> environmentPrefabs;
    public float speed = 15f;
    public int roadCount = 7;
    public float roadLength = 12f;
    public float sideOffset = 8f;

    private List<GameObject> segments = new List<GameObject>();

    void Start()
    {
        if (roadPrefab == null) return;
        
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        segments.Clear();

        for (int i = 0; i < roadCount; i++)
        {
            SpawnSegment(i * roadLength - roadLength * 2);
        }
    }

    void SpawnSegment(float zPos)
    {
        GameObject segment = new GameObject("Segment");
        segment.transform.SetParent(transform);
        segment.transform.position = new Vector3(0, 0, zPos);

        GameObject road = Instantiate(roadPrefab, segment.transform);
        road.transform.localPosition = Vector3.zero;

        if (environmentPrefabs != null && environmentPrefabs.Count > 0)
        {
            if (Random.value > 0.3f)
            {
                GameObject leftEnv = Instantiate(environmentPrefabs[Random.Range(0, environmentPrefabs.Count)], segment.transform);
                leftEnv.transform.localPosition = new Vector3(-sideOffset, 0, 0);
                leftEnv.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }

            if (Random.value > 0.3f)
            {
                GameObject rightEnv = Instantiate(environmentPrefabs[Random.Range(0, environmentPrefabs.Count)], segment.transform);
                rightEnv.transform.localPosition = new Vector3(sideOffset, 0, 0);
            }
        }

        segments.Add(segment);
    }

    void Update()
    {
        foreach (var seg in segments)
        {
            seg.transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        if (segments.Count > 0 && segments[0].transform.position.z < -roadLength * 2f)
        {
            GameObject recycled = segments[0];
            segments.RemoveAt(0);
            float newZ = segments[segments.Count - 1].transform.position.z + roadLength;
            recycled.transform.position = new Vector3(0, 0, newZ);
            segments.Add(recycled);
        }
    }
}
