using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class hpUi : MonoBehaviour
{

   // [SerializeField] private Text uiText1;
    //[SerializeField] private Text uiText2;



    public TextMeshProUGUI uiText1;
    public TextMeshProUGUI uiText2;

    public GameObject player1;
    public GameObject player2;
    public float hp1;
    public float hp2;


    // Start is called before the first frame update
    void Start()
    {

        player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Monster");
    }

    // Update is called once per frame
    void Update()
    {
       
        updateHP(hp1, uiText1, "1", player1);
        updateHP(hp2, uiText2, "2", player2);

    }


    public void updateHP(float hp,TextMeshProUGUI ui,string number, GameObject player)
    {
        hp = player.GetComponent<playerHP>().hp;
        

        ui.text = "Player "+number+": " + hp.ToString() + "%";
        
    }


}