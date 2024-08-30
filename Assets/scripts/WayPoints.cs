using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WayPoints : MonoBehaviour
{

    [SerializeField] bool IsPlaceable;
    [SerializeField] Tower TowerPrefab;

    public bool isplacable
    {
        get
        {
            return IsPlaceable;
        }
    }

    // Start is called before the first frame update
    void OnMouseDown()
    {
        if(IsPlaceable)
        {
            bool isPlace = TowerPrefab.CreateTower(TowerPrefab,transform.position);
            // Instantiate(TowerPrefab,transform.position,Quaternion.identity);
            IsPlaceable = !isPlace;
        }
        
    }
}
