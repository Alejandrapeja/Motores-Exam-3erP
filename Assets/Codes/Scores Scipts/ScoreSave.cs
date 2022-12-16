using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Juego.Scoreboards
{
    [System.Serializable]
    public class ScoreSave
    {
        public List<ScoreEntry> highscores = new List<ScoreEntry>();
    }
}
