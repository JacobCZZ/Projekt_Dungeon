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
        // podm�nky pro kontrolu jestli je ne prefabu p?i?azen� outrence nebo sideoutrence
        MainScript = starterroom.GetComponent<GenerateMain>();
        if (SideOutrence != null)
        {
            SideGeneratingscript();  //Funkce pro vytvo?en� dal�� vedlej�� m�stnosti
         
            
        }
        
            if (Outrence != null )
            {
            
                
                Debug.Log("fortnite");
                Generatingscript();  //Funkce pro vytvo?en� dal�� hlavn� m�stnosti            
                
        }
     
                          
    }
    // --------------------------------- GENERACE VEDLEJ��CH CHODEB DUNGEONU-------------------------------------------------------  
    void SideGeneratingscript() 
    {
        rand2 = RandomNumberGenerator.GetInt32(MainScript.SideRoomlist.Count);  
        if (MainScript.NumOfSideRooms >= MainScript.MaxSideRooms-1) //Podm�nka kdy� je pro vytvo?en� kone?n� m�stnosti na konci vedlej�� cesty
        {           
            GenSideEND();
        }
        else if (MainScript.NumOfSideRooms % 2 == 0 || MainScript.NumOfSideRooms == 0) // podm�nka pro vytvo?en� chodby mezi ka�dou m�stnost�
        {
            GenSideMid();
        }else if (MainScript.NumOfSideRooms < MainScript.MaxSideRooms) // Podm�nka jestli nen� p?ekro?eno maximum vedlej��ch m�stnost�
            {
                while (rand2 == MainScript.SideLast) // While kter� kontroluje aby nebyly po sob? 2 stejn? m�stnosti
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
    // --------------------------------- GENERACE HLAVN�CH CHODEB DUNGEONU-------------------------------------------------------
    void Generatingscript()
    {
        rand = RandomNumberGenerator.GetInt32(MainScript.Roomlist.Count);
        if (MainScript.NumOfRooms < MainScript.MaxRooms)  //kontrola jestli nen� prekro?eno maximum m�stnost�
        {
            if (MainScript.NumOfRooms == MainScript.MaxRooms - 1) //podm�nka pro vytvo?en� Kone?n� m�stnoti dungeonu
            {
                GenEND();
            }
            if (MainScript.NumOfRooms % 2 == 0) // podm�nka pro vytvo?en� chodby mezi ka�dou m�stnost�
            {
                GenMID();
            }
            else if (MainScript.NumOfRooms % 5 == 0 && MainScript.NumOfRooms % 2 != 0) // podm�nka pro vytvo?en� dropdown m�stnosti ka�d�ch p�r m�stnost�
            {
                GenDropDown();
            }
            else if (MainScript.NumOfRooms < MainScript.MaxRooms)
            {
                while (rand == MainScript.Last ||
                    (MainScript.Last == 5 && (rand == 6 || rand == 1 || rand == 3))
                    || (MainScript.Last == 6 && (rand == 5 || rand == 1 || rand == 3))
                    || (MainScript.Last == 1 &&( rand == 6 || rand == 5 || rand == 3))
                    || (MainScript.Last == 3 && (rand == 6 || rand == 1 || rand == 5))) // Pros�m tohle po mne necht?jte vedet ale vymyslel jsem to kdy� jsem se koupal a kontroluje to aby nebyli po sob? zat�?ky
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
