using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestionDataExample : MonoBehaviour
{
    public QuestionData questionData;

    private void Start()
    {
        // Create a new QuestionPath
        QuestionData.QuestionPath path1;
        path1.questions = new string[]
        {
            "Question 1",
            "Question 2",
            "Question 3"
        };
        path1.answers = new string[]
        {
            "2", // Answer to Question 1 leads to Question 2
            "3", // Answer to Question 2 leads to Question 3
            "1"  // Answer to Question 3 leads back to Question 1
        };
        path1.triageOptions = new string[]
        {
            "Option 1", "Option 2", "Option 3"
        };

        // Create another QuestionPath
        QuestionData.QuestionPath path2;
        path2.questions = new string[]
        {
            "Question A",
            "Question B"
        };
        path2.answers = new string[]
        {
            "2", // Answer to Question A leads to Question B
            "1"  // Answer to Question B leads back to Question A
        };
        path2.triageOptions = new string[]
        {
            "Option A", "Option B"
        };

        // Assign the created paths to the questionData
        questionData.questionPaths = new QuestionData.QuestionPath[]
        {
            path1,
            path2
        };
    }
}