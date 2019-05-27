using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hpUi : MonoBehaviour
{

    [SerializeField] private Text uiText1;
    [SerializeField] private Text uiText2;

    public GameObject player1;
    public GameObject player2;
    public float hp1;
    public float hp2;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
       
        updateHP(hp1, uiText1, "1", player1);
        updateHP(hp2, uiText2, "2", player2);

    }


    public void updateHP(float hp,Text ui,string number, GameObject player)
    {
        hp = player.GetComponent<playerHP>().hp;
        

        ui.text = "Player "+number+": " + hp.ToString() + "%";
        
    }


}