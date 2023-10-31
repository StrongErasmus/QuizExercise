using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*public class QuizInteraction : MonoBehaviour
{
    public GameObject person; // Drag and drop the person object onto this field in the Inspector
    public string[][] questions; // A two-dimensional array of questions to ask for each path
    public string[][] answers; // A two-dimensional array of correct answers for each question for each path
    public string[][] triageOptions; // A two-dimensional array of triage options for each question for each path

    private int currentQuestionIndex = 0; // Index of the current question being asked
    private int currentPathIndex = 0; // Index of the current question path being followed
    private bool isAskingQuestion = false; // Flag indicating whether a question is currently being asked

    private void Update()
    {
        // Check if the player is within a certain distance of the person
        if (Vector3.Distance(transform.position, person.transform.position) < 2.0f)
        {
            // Check if a question is not currently being asked and the player presses the A button on the Oculus Touch controller
            if (!isAskingQuestion && OVRInput.GetDown(OVRInput.Button.One))
            {
                // Ask the next question
                AskQuestion();
            }
        }
    }

    private void AskQuestion()
    {
        // Set the flag indicating that a question is being asked
        isAskingQuestion = true;

        // Display the question on the screen
        Debug.Log("Question: " + questions[currentPathIndex][currentQuestionIndex]);

        // Display the triage options on the screen
        Debug.Log("Triage Options:");
        for (int i = 0; i < triageOptions[currentPathIndex][currentQuestionIndex].Length; i++)
        {
            Debug.Log((i + 1) + ". " + triageOptions[currentPathIndex][currentQuestionIndex][i]);
        }

        // Wait for the player's input
        StartCoroutine(WaitForAnswer());
    }

    private IEnumerator WaitForAnswer()
    {
        // Wait for the player's input
        while (true)
        {
            // Check if the player has submitted an answer by pressing the B button on the Oculus Touch controller
            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                // Get the index of the next question based on the player's answer
                int nextQuestionIndex = int.Parse(answers[currentPathIndex][currentQuestionIndex]) - 1;

                // Update the current question index and path index based on the player's answer
                currentQuestionIndex = nextQuestionIndex;
                currentPathIndex++;

                // Check if all questions have been asked for the current path
                if (currentQuestionIndex >= questions[currentPathIndex - 1].Length)
                {
                    Debug.Log("End of path reached for path " + currentPathIndex);
                    yield break;
                }

                // Ask the next question
                AskQuestion();
            }
            yield return null;
        }
    }

}
*/

public class QuizInteraction : MonoBehaviour
{
    public GameObject person; // Drag and drop the person object onto this field in the Inspector
    public QuestionData questionData; // Reference to the QuestionData ScriptableObject
    public VitalSignsUI vitalSignsUI; // Reference to the VitalSignsUI script
    private bool isUIVisible = false; // Flag to track the visibility of the UI

    private int currentQuestionIndex = 0; // Index of the current question being asked
    private int currentPathIndex = 0; // Index of the current question path being followed
    private bool isAskingQuestion = false; // Flag indicating whether a question is currently being asked

    private void Update()
    {
        // Check if the player is within a certain distance of the person
        if (Vector3.Distance(transform.position, person.transform.position) < 2.0f)
        {
            // Check if a question is not currently being asked and the player clicks the mouse button or taps the screen
            //if (!isAskingQuestion && (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            if (!isAskingQuestion && (Input.GetMouseButtonDown(0))) 
            {
                // Ask the next question
                AskQuestion();
                vitalSignsUI.ShowUI();
                isUIVisible = true;
            }
        }
    }

    private void AskQuestion()
    {
        // Set the flag indicating that a question is being asked
        isAskingQuestion = true;

        // Get the current question path
        QuestionData.QuestionPath currentPath = questionData.questionPaths[currentPathIndex];

        // Check if the current question index is within the bounds of the current path
        if (currentQuestionIndex < currentPath.questions.Length)
        {
            // Display the question on the screen
            Debug.Log("Question: " + currentPath.questions[currentQuestionIndex]);

            // Display the triage options on the screen
            Debug.Log("Triage Options:");
            for (int i = 0; i < currentPath.triageOptions[currentQuestionIndex].Length; i++)
            {
                Debug.Log((i + 1) + ". " + currentPath.triageOptions[currentQuestionIndex][i]);
            }

            // Wait for the player's input
            StartCoroutine(WaitForAnswer());
        }
        else
        {
            Debug.Log("End of path reached for path " + currentPathIndex);
        }
    }

    private IEnumerator WaitForAnswer()
    {
        // Wait for the player's input
        while (true)
        {
            // Check if the player has submitted an answer by clicking the mouse button or tapping the screen
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Get the current question path
                QuestionData.QuestionPath currentPath = questionData.questionPaths[currentPathIndex];

                // Get the current answer index
                int answerIndex = int.Parse(currentPath.answers[currentQuestionIndex]) - 1;

                // Update the current path index based on the player's answer
                currentPathIndex = currentPathIndex + answerIndex;

                // Check if the current path index is within the bounds of the question paths array
                if (currentPathIndex < questionData.questionPaths.Length)
                {
                    // Reset the current question index for the new path
                    currentQuestionIndex = 0;

                    // Ask the next question
                    AskQuestion();
                }
                else
                {
                    Debug.Log("End of question paths reached");
                }

                break;
            }

            // Wait for the next frame
            yield return null;
        }
    }
}
