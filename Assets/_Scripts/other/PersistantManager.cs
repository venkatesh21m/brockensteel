using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rudrac.BrockenSteel
{
    public static class PersistantManager 
    {
         static string intro = "Intro";
        
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

    }
}
