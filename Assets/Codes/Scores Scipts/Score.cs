using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.UIElements;

namespace Juego.Scoreboards
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private int maxEntrySocre = 5;
        [SerializeField] private Transform scoresHolderTransform = null;
        [SerializeField] private GameObject scoreEntryObject = null;

        [Header("Test")]
        public TMP_InputField Nombre;
        public UnityEngine.UI.Button btnSubmit;
        public UnityEngine.UI.Button btnQuit;
        public Player player;
        [SerializeField] private string testEntryName = "New Name";
        [SerializeField] private float testEntryScore = 0;

        private string SavePath => $"{Application.persistentDataPath}/highscore.json";
        private void Start()
        {
            ScoreSave savedScores = GetSavedScore();
            UpdateUI(savedScores);
            SaveScores(savedScores);
            btnQuit.interactable =false;
        }
        public void DeactivateSave()
        {
            btnSubmit.interactable=false;
        }

        public void ActivateQuit()
        {
            btnQuit.interactable=true;
        }

        [ContextMenu("Add Test Entry")]
        public void AddTestEntry()
        {
            testEntryScore = player.tiempo;
            AddEntry(new ScoreEntry()
            {
                entryName = Nombre.text.ToString(),
                entryScore = player.tiempo
            });

        }

        
        public void AddEntry(ScoreEntry scoreEntry)
        {
            ScoreSave savedScores = GetSavedScore();

            bool scoreAdded = false;
            for (int i = 0; i < savedScores.highscores.Count; i++)
            {
                if (testEntryScore < savedScores.highscores[i].entryScore)
                {
                    savedScores.highscores.Insert(i, scoreEntry);
                    scoreAdded = true;
                    break;
                }
            }
            if(!scoreAdded && savedScores.highscores.Count < maxEntrySocre)
            {
                savedScores.highscores.Add(scoreEntry);
            }

            if (savedScores.highscores.Count > maxEntrySocre) 
            {
                savedScores.highscores.RemoveRange(maxEntrySocre, savedScores.highscores.Count - maxEntrySocre);
            }

            UpdateUI(savedScores);
            SaveScores(savedScores);
        }
       
        private void UpdateUI(ScoreSave savedSocres)
        {
            foreach(Transform child in scoresHolderTransform)
            {
                Destroy(child.gameObject);
            }
            foreach(ScoreEntry highscore in savedSocres.highscores)
            {
                Instantiate(scoreEntryObject, scoresHolderTransform).GetComponent<ScoreUI>().Initialise(highscore);
            }
        }

        private ScoreSave GetSavedScore()
        {
            if (!File.Exists(SavePath))
            {
                File.Create(SavePath).Dispose();
                return new ScoreSave();
            }
            using (StreamReader stream = new StreamReader(SavePath))
            {
                string json = stream.ReadToEnd();
                return JsonUtility.FromJson<ScoreSave>(json);
            }
        }
        private void SaveScores(ScoreSave scoreSave)
        {
            using (StreamWriter stream = new StreamWriter(SavePath))
            {
                string json = JsonUtility.ToJson(scoreSave, true);
                stream.Write(json);
            }
        }
    }
}

