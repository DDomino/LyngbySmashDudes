using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector_script : MonoBehaviour
{
    public GameObject Goku;
    public GameObject Fox;
    private Vector3 CharacterPosition;
    private Vector3 OffScreen;
    private int CharInt = 1;

    private readonly string selectedCharacter = "SelectedCharacter";
    

    private void Awake()
    {
        CharacterPosition = Goku.transform.position;
        OffScreen = Fox.transform.position;
    }



    public void NextChar()
    {
        switch(CharInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                Goku.transform.position = OffScreen;
                Fox.transform.position = CharacterPosition;
                CharInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                Fox.transform.position = OffScreen;
                Goku.transform.position = CharacterPosition;
                CharInt++;
                ResetInt();
                break;
            default:
                ResetInt();
                break;
        }
    }

    public void PreChar()
    {
        switch (CharInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                Goku.transform.position = CharacterPosition;
                Fox.transform.position =  OffScreen;
                CharInt--;
                ResetInt();
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                Fox.transform.position = CharacterPosition;
                Goku.transform.position = OffScreen;
                CharInt--;
                
                break;
            default:
                ResetInt();
                break;
        }
    }


    private void ResetInt()
    {
        if(CharInt >= 2)
        {
            CharInt = 1;
        }
        else
        {
            CharInt = 2;
        }
    }


    public void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }

}
