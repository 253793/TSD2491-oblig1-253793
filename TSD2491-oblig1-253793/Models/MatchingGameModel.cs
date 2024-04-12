using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;

namespace TSD2491_oblig1_253793.Models
{
    public class MatchingGameModel
    {
        //public List<string> ShuffledAnimals { get; private set; }
        public int MatchesFound = 0;
        public string GameStatus { get; private set; }

        public MatchingGameModel()
        {
            SetUpGame();
        }

        static public List<string> AnimalEmoji = new List<string>()
            {
                "🐕", "🐕",
                "🐺", "🐺",
                "🐔", "🐔",
                "🐹", "🐹",
                "🐈", "🐈",
                "🐀", "🐀",
                "🐅", "🐅",
                "🦈", "🦈",
            };
        static List<string> weatherEmoji = new List<string>()
            {
                "⛅", "⛅",
                "⛈️", "⛈️",
                "🌤️", "🌤️",
                "🌦️", "🌦️",
                "🌨️", "🌨️",
                "🌧️", "🌧️",
                "☁️", "☁️",
                "🌪️", "🌪️",
            };
        static List<string> randomEmoji = new List<string>()
            {
                "🎥", "🎥",
                "🔌", "🔌",
                "💻", "💻",
                "💣", "💣",
                "⚔️", "⚔️",
                "💉", "💉",
                "🍕", "🍕",
                "🦇", "🦇",
            };

        static Random random = new Random();
        public List<string> shuffledEmoji = pickRandomEmoji();
        static List<string> pickRandomEmoji()
        {
            // Generate a random number between 0 and 2 to select one of the lists
            int randomIndex = random.Next(0, 3);

            // Use a switch case to determine which list to return based on the randomIndex
            switch (randomIndex)
            {
                case 0:
                    return AnimalEmoji = AnimalEmoji.OrderBy(items => random.Next()).ToList(); ;
                case 1:
                    return weatherEmoji = weatherEmoji.OrderBy(items => random.Next()).ToList(); ;
                case 2:
                    return randomEmoji = randomEmoji.OrderBy(items => random.Next()).ToList(); ;
                default:
                    throw new Exception("Invalid random index");
            }
        }

        private void SetUpGame()
        {
            Random random = new Random();
            shuffledEmoji = pickRandomEmoji();

            MatchesFound = 0;

        }

        string lastAnimalFound = string.Empty;
        string lastDescription = string.Empty;

        public void ButtonClick(string animal, string animalDescription)
        {
            if (MatchesFound == 0)
            {
                // Første klikk, spill starter
                GameStatus = "Game Running";
            }
            if (lastAnimalFound == string.Empty)
            {
                lastAnimalFound = animal;
                lastDescription = animalDescription;

            }
            else if ((lastAnimalFound == animal) && (animalDescription != lastDescription))
            {
                lastAnimalFound = string.Empty;

                shuffledEmoji = shuffledEmoji
                    .Select(a => a.Replace(animal, string.Empty))
                    .ToList();

                MatchesFound++;
                if (MatchesFound == 8)
                {
                    GameStatus = "Game Complete";
                    SetUpGame();
                }
            }
            else
            {
                lastAnimalFound = string.Empty;
            }

        }

    }
}
