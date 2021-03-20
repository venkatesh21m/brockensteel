using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rudrac.BrockenSteel
{
    public static class PersistantManager 
    {
         static string intro = "Intro";
         static string infiniteScore = "HighScore";
        
        public static int Intro
        {
            get
            {
                int value = 0;
                if (PlayerPrefs.HasKey(intro))
                {
                    value = PlayerPrefs.GetInt(intro);
                }
                return value;
            }
            set
            {
                PlayerPrefs.SetInt(intro, value);
            }
        }
        
        public static int HighScore
        {
            get
            {
                int value = 0;
                if (PlayerPrefs.HasKey(infiniteScore))
                {
                    value = PlayerPrefs.GetInt(infiniteScore);
                }
                return value;
            }
            set
            {
                PlayerPrefs.SetInt(infiniteScore, value);
            }
        }

    }
}
