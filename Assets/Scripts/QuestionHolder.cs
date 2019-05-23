using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Microsoft.VisualBasic.FileIO.TextFieldParser;

public class QuestionHolder : MonoBehaviour
{

    private Dictionary<string,int> indexes = new Dictionary<string,int>();
    private Dictionary<int, string> question = new Dictionary<int, string>();
    private List<List<bool>> adjacencyMatrix = new List<List<bool>>();
    private CSVReader reader;


    void Start()
    {

        FillList();
        print("finished"+indexes.ContainsKey("1"));

    }

    private void AddQuestion(List<string> tags) {
        

        question.Add(adjacencyMatrix.Count, tags[0]);
        adjacencyMatrix.Add(new List<bool>());

        for (int i = 0; i < adjacencyMatrix[0].Count; i++)
            adjacencyMatrix[adjacencyMatrix.Count-1].Add(false);

        for (int i = 1; i < tags.Count; i++)
        {

            if (!indexes.ContainsKey(tags[i]))
            {
                print("new tag:" + tags[i]+":");
                indexes.Add(tags[i], adjacencyMatrix[0].Count);
                for (int j = 0; j < adjacencyMatrix.Count - 1; j++)
                    adjacencyMatrix[j].Add(false);
                adjacencyMatrix[adjacencyMatrix.Count - 1].Add(true);
            }
            else {
                
                int cur = indexes[tags[i]];
                adjacencyMatrix[adjacencyMatrix.Count - 1].RemoveAt(cur);
                adjacencyMatrix[adjacencyMatrix.Count - 1].Insert(cur,true);
            }
        }
    }

    public string GetRandomQuestion(string[] tagsTrue, string[] tagsFalse)
    {
        
        int[] idTrue = new int[tagsTrue.Length];
        int[] idFalse = new int[tagsFalse.Length];
        print("in the deep: "+indexes.ContainsKey(tagsTrue[0])+":"+ indexes.ContainsKey("2")+":"+tagsTrue[0]);

        for (int i = 0; i < tagsTrue.Length; i++)
            idTrue[i] = indexes[tagsTrue[i]];
        for (int i = 0; i < tagsFalse.Length; i++)
            idFalse[i] = indexes[tagsFalse[i]];
        bool matches=true;
        List<int> correctQuestions= new List<int>();
        for (int i = 0; i < adjacencyMatrix.Count; i++)
        {
           
            matches = true;
            for (int j = 0; j < idTrue.Length; j++) {
                if (adjacencyMatrix[i][idTrue[j]] == false)
                        matches = false;
            }
            for (int j = 0; j < idFalse.Length; j++)
            {
                if (adjacencyMatrix[i][idFalse[j]] == true)
                    matches = false;
            }
            if (matches)
                correctQuestions.Add(i);
        }
        if (correctQuestions.Count == 0)
            return "-1";
        int q = correctQuestions[Random.Range(0, correctQuestions.Count)];
        string finalQ = question[q];

        question.Remove(q);
        adjacencyMatrix.RemoveAt(q);

        return finalQ;
    }


    public void FillList()
    {


        reader = GameObject.Find("PlayerHolder").GetComponent<CSVReader>();
        if (reader == null)
        {
            //create new one
            print("oopsie didnt find reader!");
        }
        
        for (int i = 0; i < reader.parsedList.Count; i++)
        {
            if (reader.parsedList[i][1] == "2")
                print("found it!");
            AddQuestion(reader.parsedList[i]);
        }
    }
}
