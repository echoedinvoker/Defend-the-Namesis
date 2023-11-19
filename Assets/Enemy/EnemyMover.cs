using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 0.1f;

    Enemy enemy;

    void OnEnable() {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
      enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            // path.Add(child.GetComponent<Waypoint>());
            
            Waypoint waypoint = child.GetComponent<Waypoint>();

            if (waypoint != null)
            {
              path.Add(waypoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint item in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = item.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f) {
                travelPercent += Time.deltaTime * speed; 
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return null;
            }
        }

        FinishPath();
    }

    void FinishPath()
    {
        gameObject.SetActive(false);
        enemy.StealGold();
    }
}
