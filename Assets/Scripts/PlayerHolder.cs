using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolder : MonoBehaviour
{
    public Player[] playerHolder;
    public int currentPlayers=0;
    public int maxPlayers = 8;

    private void Start()
    {
        playerHolder = new Player[maxPlayers];
        DontDestroyOnLoad(this.gameObject);
        List<string> test = new List<string>();

        CreateDevExample();
    }

    private void CreateDevExample() {
        for (int i = 0; i < 8; i++) {
            Player p = new Player();
            p.single = true;
            p.female = true;
            p.name = "Silver";
            p.age = 1;
            AddPlayer(p);
        }
    }

    public bool AddPlayer(Player p) {
        if (currentPlayers > 7)
            return false;
        playerHolder[currentPlayers] = p;
        currentPlayers++;
        return true;
    }

    public string[] GetRandomPlayerlist() {
        string[] randomPL = new string[currentPlayers];
        for (int i = 0; i < currentPlayers; i++)
            randomPL[i] = playerHolder[i].name;
        RandomOrder(randomPL);
        return randomPL;
    }

    private void RandomOrder(object[] order)
    {
        for (int i = 0; i < order.Length; i++)
        {
            int k = Random.Range(0, order.Length - 1);
            object value = order[k];
            order[k] = order[i];
            order[i] = value;
        }
    }
}
