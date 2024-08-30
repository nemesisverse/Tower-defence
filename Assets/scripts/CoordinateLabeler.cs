using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using System.Reflection.Emit;





[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro Text;
    Vector2Int Coordinates ;
    WayPoints waypoints;
    void Awake()
    {
        Text = GetComponent<TextMeshPro>();
        DisplayeCoordinates();
        waypoints = GetComponentInParent<WayPoints>();
    }



 
    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayeCoordinates();
            UpdateName();
        }

        ColoCoordinates();



    }

    void  ColoCoordinates()
    {
        if(waypoints.isplacable)
        {
            Text.color = Color.blue ;

        }

        else
        {
            Text.color = Color.gray;
        }
    }

    void DisplayeCoordinates()
    {
        Coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);

        Coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        Text.text = Coordinates.x + "," + Coordinates.y;
    }

    void UpdateName()
    {
        transform.parent.name = Coordinates.ToString();
    }
}
