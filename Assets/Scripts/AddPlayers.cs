using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPlayers : MonoBehaviour
{
    public Toggle single, female;
    public InputField nameField, ageField;
    private PlayerHolder playerHolder;
    private int currentPlayer;
    private int amountOfPlayers;
    private int MaxPlayers;


    // Start is called before the first frame update
    public void Start()
    {
        playerHolder = GameObject.Find("PlayerHolder").GetComponent<PlayerHolder>();
    }

    public void AddPlayer() {
        bool success = playerHolder.AddPlayer();
        if (success)
        {

        }
    }

    public void SavePlayer()
    {
        Player savePlayer = new Player();
        savePlayer.name = nameField.text;
        savePlayer.age = int.Parse(ageField.text);
        if (single.isOn)
        {
            savePlayer.has.Add("single");
            savePlayer.hasNot.Add("couple");
        }
        else {
            savePlayer.hasNot.Add("single");
            savePlayer.has.Add("couple");
        }
        if (female.isOn)
        {
            savePlayer.has.Add("single");
            savePlayer.hasNot.Add("couple");
        }
        else
        {
            savePlayer.hasNot.Add("single");
            savePlayer.has.Add("couple");
        }

        playerHolder.FillPlayer(savePlayer, currentPlayer);
    }

    public void SwitchFields(int newCurrentPlayer)
    {
        currentPlayer = newCurrentPlayer;
        //player buttons will start at 1;
        if (currentPlayer >= amountOfPlayers)
            return;

        Player player  = playerHolder.GetPlayer(currentPlayer);

        if (player.has.Contains("single"))
            single.isOn = true;
        if (player.has.Contains("female"))
            female.isOn = true;
        nameField.text = player.name;
        ageField.text = player.age.ToString();
    }




}
