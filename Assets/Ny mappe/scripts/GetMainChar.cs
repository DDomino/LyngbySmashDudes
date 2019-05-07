using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainChar : MonoBehaviour
{

    public Sprite Goku, Fox;
    private SpriteRenderer mySprite;

    private readonly string selectedCharacter = "SelectedCharacter";
    // Start is called before the first frame update

    private void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        int getCharacter;

        getCharacter = PlayerPrefs.GetInt(selectedCharacter);

        switch (getCharacter)
        {
            case 1:
                mySprite.sprite = Goku;
                break;
            case 2:
                mySprite.sprite = Fox;
                break;
            default:
                mySprite.sprite = Goku;
                break;
        }
    }

}
