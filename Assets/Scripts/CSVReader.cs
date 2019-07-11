using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVReader : MonoBehaviour
{
    private List<string> stringList = new List<string>();
    public List<List<string>> parsedList = new List<List<string>>();

    void Awake()
    {
        print("About to parse:");
        ReadTextFile("Assets/CSV/Questions.csv");
        print("Parsed with result of: "+parsedList.Count);
    }

    void ReadTextFile(string path)
    {
        StreamReader inp_stm = new StreamReader(path);

        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();

            stringList.Add(inp_ln);
        }

        inp_stm.Close();

        ParseList();
    }

    void ParseList()
    {
        for (int i = 1; i < stringList.Count; i++)
        {
            List<string> tempL = new List<string>();
            string[] temp = stringList[i].Split(',');

            tempL.Add(temp[0].Trim());

            //make it so it doesnt to lower the question
            for (int j = 1; j < temp.Length; j++)
            {
                if (temp[j] == "")
                    continue;
                if(j==1)
                    temp[j] = temp[j].Trim();
                else
                    temp[j] = temp[j].ToLower().Trim();
                tempL.Add(temp[j]);
            }
            parsedList.Add(tempL);
        }
    }
}
