#nullable enable
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using QuizGameCore;
using Uitls;
using UnityEngine;

namespace Quizs.QuizSource
{
    public class XMLFileQuizSource : MonoBehaviour, IQuizSource
    {
        [SerializeField] private TextAsset textAsset = null!;

        public IReadOnlyList<IQuiz> QuizList()
        {
            var raw = textAsset.EnsureNotNull().text;
            var list = DeserializeFromXml<QuizzesList>(raw).EnsureNotNull();
            return list.Quizzes.Select(q => q.Create()).ToList();
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        [XmlRoot("QuizList")]
        public class QuizzesList
        {
            [XmlElement("Quiz")]
            public List<QuizData> Quizzes { get; set; } = new List<QuizData>();
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public class QuizData
        {
            public string? Question;
            public string? CorrectAnswer;

            [XmlArray("WrongAnswers")]
            [XmlArrayItem("WrongAnswer")]
            public string[]? WrongAnswers;

            public IQuiz Create()
            {
                return new Quiz(
                    Question.EnsureNotNull(),
                    CorrectAnswer.EnsureNotNull(),
                    WrongAnswers.EnsureNotNull()
                );
            }
        }

        private static T? DeserializeFromXml<T>(string xmlString) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stringReader = new StringReader(xmlString))
            {
                return serializer.Deserialize(stringReader) as T;
            }
        }
    }
}