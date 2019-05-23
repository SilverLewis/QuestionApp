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
    }

    public bool AddPlayer(Player p) {
        if (currentPlayers > 7)
            return false;
        playerHolder[currentPlayers] = p;
        currentPlayers++;
        return true;
    }
}
