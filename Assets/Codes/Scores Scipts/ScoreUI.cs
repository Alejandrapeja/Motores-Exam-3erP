using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
namespace Juego.Scoreboards
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI entryNameText = null;
        [SerializeField] private TextMeshProUGUI entryScoreText = null;
        public void Initialise(ScoreEntry scoreEntry)
        {
            entryNameText.text = scoreEntry.entryName;
            TimeSpan time = TimeSpan.FromSeconds(scoreEntry.entryScore);
            entryScoreText.text = time.ToString("hh':'mm':'ss");
        }
    }
}
