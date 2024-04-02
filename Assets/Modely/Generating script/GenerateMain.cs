using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMain : MonoBehaviour
{
    public float NumOfRooms=1;
    public float MaxRooms=10;

    public float NumOfSideRooms;
    public float MaxSideRooms;

    public bool isSideDone=false;

    [SerializeField]
    public GameObject starterRomm;

    [SerializeField]
    public GameObject EndRomm;

    [SerializeField]
    public GameObject SideEndRomm;

    [SerializeField]
    public GameObject SideMidRomm;

    [SerializeField]
    public GameObject DropDown;

    [SerializeField]
    public GameObject MidRoom;


    public int Last;
    public int SideLast;
    public List<GameObject> Roomlist = new List<GameObject>();
    public List<GameObject> SideRoomlist = new List<GameObject>();   
}
