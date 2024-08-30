using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoints> Path;
    [SerializeField][Range(0f, 5f)] float Speed = 1f;


    Enemy enemy;


    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    // Start is called before the first frame update
    void OnEnable()
    {

        FindingPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindingPath()
    {
        Path.Clear();
        GameObject Parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in Parent.transform)
        {
          WayPoints waypoints =   child.GetComponent<WayPoints>();

            if(waypoints != null)
            {
                Path.Add(waypoints);
            }
        }
    }

    private void ReturnToStart()
    {
        transform.position  = Path[0].transform.position;
    }

    // Update is called once per frame
    IEnumerator FollowPath()
    {
        foreach(WayPoints waypoints in Path)
        {
            Vector3 StartingPosition = transform.position;
            Vector3 EndingPosition = waypoints.transform.position;
            float TravelPercent = 0f;

            transform.LookAt(EndingPosition);

            while(TravelPercent < 1f)
            {
                TravelPercent  += Time.deltaTime * Speed;
                transform.position = Vector3.Lerp(StartingPosition , EndingPosition , TravelPercent);
                yield return new WaitForEndOfFrame();
            }

        }

        gameObject.SetActive(false);
        enemy.StealGold();
    }
}
