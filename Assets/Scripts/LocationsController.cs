using System.Collections.Generic;
using UnityEngine;

public class LocationsController : MonoBehaviour
{
    public static LocationsController Instance;

    public List<EnergyLocationBehaviour> Locations { get; set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        Locations = new List<EnergyLocationBehaviour>();
        for (int i = 0; i < GetComponentsInChildren<EnergyLocationBehaviour>().Length; i++)
        {
            Locations.Add(GetComponentsInChildren<EnergyLocationBehaviour>()[i]);
        }
    }
    
}
