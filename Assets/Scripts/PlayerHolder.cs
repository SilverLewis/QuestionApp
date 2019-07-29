using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolder : MonoBehaviour
{
    public Player[] playerHolder;
    public int currentPlayerCount=0;
    public int maxPlayers = 20;

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
            List<string> has = new List<string>();
            has.Add("single");
            has.Add("female");
            p.name = "Silver";
            p.age = 1;
            AddPlayer();
            FillPlayer(p, i);
        }
    }

    public bool AddPlayer() {
        if (currentPlayerCount < maxPlayers)
        {
            currentPlayerCount++;
            return true;
        }
        return false;
    }

    public bool FillPlayer(Player p, int currentPlayer) {
        if (currentPlayer > currentPlayerCount)
            return false;
        playerHolder[currentPlayerCount] = p;
        currentPlayerCount++;
        return true;
    }

    public string[] GetRandomPlayerlist() {
        string[] randomPL = new string[currentPlayerCount];
        for (int i = 0; i < currentPlayerCount; i++)
            randomPL[i] = playerHolder[i].name;
        RandomOrder(randomPL);
        return randomPL;
    }

    public Player GetPlayer(int i) {
        if(i<currentPlayerCount)
            return playerHolder[i];
        return new Player();
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
