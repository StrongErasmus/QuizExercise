using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "Quiz/Question Data")]
public class QuestionData : ScriptableObject
{
    [System.Serializable]
    public struct QuestionPath
    {
        public string[] questions;
        public string[] answers;
        public string[] triageOptions;
    }

    public QuestionPath[] questionPaths;
}
