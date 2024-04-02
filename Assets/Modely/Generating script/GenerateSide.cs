using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Security.Cryptography;


public class GenerateSide : MonoBehaviour
{
    // Start is called before the first frame update
  
    [SerializeField]
    public GameObject Outrence;
   
    [SerializeField]
    public GameObject starterroom;

    [SerializeField]
    public GameObject SideOutrence;

  

    public int rand;
    public int rand2;

    GenerateMain MainScript;
    void Start()
    {
        // podmínky pro kontrolu jestli je ne prefabu p?i?azené outrence nebo sideoutrence
        MainScript = starterroom.GetComponent<GenerateMain>();
        if (SideOutrence != null)
        {
            SideGeneratingscript();  //Funkce pro vytvo?ení další vedlejší místnosti
         
            
        }
        
            if (Outrence != null )
            {
            
                
                Debug.Log("fortnite");
                Generatingscript();  //Funkce pro vytvo?ení další hlavní místnosti            
                
        }
     
                          
    }
    // --------------------------------- GENERACE VEDLEJŠÍCH CHODEB DUNGEONU-------------------------------------------------------  
    void SideGeneratingscript() 
    {
        rand2 = RandomNumberGenerator.GetInt32(MainScript.SideRoomlist.Count);  
        if (MainScript.NumOfSideRooms >= MainScript.MaxSideRooms-1) //Podmínka když je pro vytvo?ení kone?né místnosti na konci vedlejší cesty
        {           
            GenSideEND();
        }
        else if (MainScript.NumOfSideRooms % 2 == 0 || MainScript.NumOfSideRooms == 0) // podmínka pro vytvo?ení chodby mezi každou místností
        {
            GenSideMid();
        }else if (MainScript.NumOfSideRooms < MainScript.MaxSideRooms) // Podmínka jestli není p?ekro?eno maximum vedlejších místností
            {
                while (rand2 == MainScript.SideLast) // While který kontroluje aby nebyly po sob? 2 stejn? místnosti
                {                  
                    rand2 = RandomNumberGenerator.GetInt32(MainScript.SideRoomlist.Count);
                }
                GenSideRoom();              
            }        
    }
    void  GenSideEND()
    {
        GameObject obj = Instantiate(MainScript.SideEndRomm, SideOutrence.transform.position, SideOutrence.transform.rotation);
        obj.GetComponent<GenerateSide>().starterroom = this.starterroom;
        MainScript.NumOfSideRooms =0;
    
    }
    void GenSideMid()
    {
        GameObject obj = Instantiate(MainScript.SideMidRomm, SideOutrence.transform.position, SideOutrence.transform.rotation);
        obj.GetComponent<GenerateSide>().starterroom = this.starterroom;
        MainScript.NumOfSideRooms++;

    }
    void GenSideRoom()
    {
        GameObject obj = Instantiate(MainScript.SideRoomlist[rand2], SideOutrence.transform.position, SideOutrence.transform.rotation);
        obj.GetComponent<GenerateSide>().starterroom = this.starterroom;
        MainScript.SideLast = rand2;
        MainScript.NumOfSideRooms++;

    }
    // --------------------------------- GENERACE HLAVNÍCH CHODEB DUNGEONU-------------------------------------------------------
    void Generatingscript()
    {
        rand = RandomNumberGenerator.GetInt32(MainScript.Roomlist.Count);
        if (MainScript.NumOfRooms < MainScript.MaxRooms)  //kontrola jestli není prekro?eno maximum místností
        {
            if (MainScript.NumOfRooms == MainScript.MaxRooms - 1) //podmínka pro vytvo?ení Kone?né místnoti dungeonu
            {
                GenEND();
            }
            if (MainScript.NumOfRooms % 2 == 0) // podmínka pro vytvo?ení chodby mezi každou místností
            {
                GenMID();
            }
            else if (MainScript.NumOfRooms % 5 == 0 && MainScript.NumOfRooms % 2 != 0) // podmínka pro vytvo?ení dropdown místnosti každých pár místností
            {
                GenDropDown();
            }
            else if (MainScript.NumOfRooms < MainScript.MaxRooms)
            {
                while (rand == MainScript.Last ||
                    (MainScript.Last == 5 && (rand == 6 || rand == 1 || rand == 3))
                    || (MainScript.Last == 6 && (rand == 5 || rand == 1 || rand == 3))
                    || (MainScript.Last == 1 &&( rand == 6 || rand == 5 || rand == 3))
                    || (MainScript.Last == 3 && (rand == 6 || rand == 1 || rand == 5))) // Prosím tohle po mne necht?jte vedet ale vymyslel jsem to když jsem se koupal a kontroluje to aby nebyli po sob? zatá?ky
                {
                    rand = RandomNumberGenerator.GetInt32(MainScript.Roomlist.Count);
                }
                GenRoom();
            }
            MainScript.NumOfRooms++;
        }
    }
    void GenEND()
    {
        GameObject obj = Instantiate(MainScript.EndRomm, Outrence.transform.position, Outrence.transform.rotation);
        obj.GetComponent<GenerateSide>().starterroom = this.starterroom;
        MainScript.NumOfRooms = 99999;
    }
    void GenMID()
    {
        GameObject obj = Instantiate(MainScript.MidRoom, Outrence.transform.position, Outrence.transform.rotation);
        obj.GetComponent<GenerateSide>().starterroom = this.starterroom;      
    }
    void GenDropDown()
    {
        GameObject obj = Instantiate(MainScript.DropDown, Outrence.transform.position, Outrence.transform.rotation);
        obj.GetComponent<GenerateSide>().starterroom = this.starterroom;
    }
    void GenRoom()
    {
        GameObject obj = Instantiate(MainScript.Roomlist[rand], Outrence.transform.position, Outrence.transform.rotation);
        obj.GetComponent<GenerateSide>().starterroom = this.starterroom;
        MainScript.Last = rand;
    }
}
