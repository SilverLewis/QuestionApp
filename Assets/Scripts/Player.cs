using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    public List<string> has, hasNot;
    public string name;
    public int age;

    void Awake() {
        name= "";
        age = -1;
        has = new List<string>();
        hasNot = new List<string>();
    }

    public void AddPlayerData(string data, bool include) {
        if (include)
            has.Add(data);
        else
            hasNot.Add(data);
    }
}
