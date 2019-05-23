using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class NewPlayer : MonoBehaviour
{
    public Toggle single, female;
    public InputField nameField, age;
    private PlayerHolder playerHolder;

    public void Start()
    {
        playerHolder = GameObject.Find("PlayerHolder").GetComponent<PlayerHolder>();
    }

    public void CreateNewPlayer() {
        Player p = new Player();
        p.single = single.GetComponent<Toggle>().isOn;
        p.female = female.GetComponent<Toggle>().isOn;
        p.name = nameField.text;

        if (!int.TryParse(age.text, out p.age))
            p.age = -1;
        if(playerHolder.AddPlayer(p))
            print("success");
    }
}
