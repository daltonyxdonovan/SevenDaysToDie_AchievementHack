using BepInEx;
using UnityEngine;
using System;

namespace SevenDaysToDie_ConsoleCommands
{
    
    [BepInPlugin("com.daltonyx.SD2DAchievementHack", "AchievementHack", "0.9.9")]
    public class Plugin : BaseUnityPlugin
    {
        string[] achievement_names;

        public void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin AchievementHack is loaded!");
            achievement_names = new string[0];
        }

        public void addName(string name)
        {
            //add name to achievement_names while resizing array
            Array.Resize(ref achievement_names, achievement_names.Length + 1);
            achievement_names[achievement_names.Length - 1] = name;
        }

        public void printAchievements()
        {
            //print all the achievements
            for (int i = 0; i < achievement_names.Length; i++)
            {
                Logger.LogInfo(achievement_names[i]);
            }
        }

        public void Start()
        {
            //add all the names to the list of achievements
            //these were a bit tricky to find in this game, not gonna lie.
            addName("StoneAxe");
            addName("Bedroll");
            addName("BleedOut");
            addName("WoodFrame");
            addName("LandClaim");
            addName("Items50");
            addName("Items500");
            addName("Items1500");
            addName("Items5000");
            addName("Zombies10");
            addName("Zombies100");
            addName("Zombies500");
            addName("Zombies2500");
            addName("Players1");
            addName("Players10");
            addName("Players25");
            addName("Travel10");
            addName("Travel50");
            addName("Travel250");
            addName("Travel1000");
            addName("Die1");
            addName("Die7");
            addName("Die14");
            addName("Die28");
            addName("Height255");
            addName("Height0");
            addName("SubZeroNaked");
            addName("Kills44Mag");
            addName("LegBreak");
            addName("Life60Minute");
            addName("Life180Minute");
            addName("Life600Minute");
            addName("Life1680Minute");
            addName("Fortitude4");
            addName("Fortitude6");
            addName("Fortitude8");
            addName("Fortitude10");
            addName("Gamestage10");
            addName("Gamestage25");
            addName("Gamestage50");
            addName("Gamestage100");
            addName("Gamestage200");
            addName("Last");
        }

        public void Update()
        {
            //if we press space while in a map/game
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //we loop through the strings and pass them to Steamworks
                for (int i = 0; i < achievement_names.Length; i++)
                {
                    //and set them to unlocked
                    Steamworks.SteamUserStats.SetAchievement(achievement_names[i]);
                }

                //then we print a message to the console and spam newlines to make it more visible
                Logger.LogInfo("\n\n\n\n\n");
                Logger.LogInfo("=============================ATTEMPTING ACHIEVEMENT HACK=============================");
                Logger.LogInfo("All achievements should be unlocked now, if used while in a map/game. Mine did not trigger until I exited the game. -Daltonyx (:)");
                Logger.LogInfo("\n\n\n\n\n");
            }
        }
    }
}
