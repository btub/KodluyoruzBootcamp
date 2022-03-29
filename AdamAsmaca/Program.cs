using System;

namespace AdamAsmaca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1. Bir kelime grubundan rastgele bir kelime seç. (ayna)
             * 2. Seçtiğin bu kelimenin her harfini * işaretine dönüştür
             * 3. Bu bulmacayı ekranda göster. (****)
             * 4. Oyuncudan harf iste 
             * 5. Harf kelimede var mı kontrol et.
             * 6. a. Eğer varsa, o harfin bulunduğu * işaretlerini harfe çevir (Örnek a**a)
             *    b. Yoksa bir hakkını azalt
             * 7. Oyuncudan kelimeyi tahmin etmesini iste
             *    Bilirse oyunu bitir
             *    Bilemezse 3. adıma dön
             */

            

            bool isGameOver = false;
            int life = 6, level = 0;
           
            
            while (!isGameOver)
            {
                life = Play(life,level++);
                Console.WriteLine("Oyuna devam mı (E/H)?");
                if (Console.ReadLine().ToUpper() == "E")
                {
                    if (level > 3 || life==0)
                        level = 0;
                    life = 6;
                }
                else
                {
                    isGameOver = true;
                }
                    
            }
        }

        private static int Play(int life,int level)
        {
            string selectedWord = ChooseWord(level);
            string puzzle = ReplaceToStar(selectedWord);
            Console.WriteLine(puzzle);
            bool isWordFinding = false;
            Console.WriteLine($"Level: {level+1}");
            while (!isWordFinding)
            {
                DrawGame(life);
                Console.WriteLine("Bir harf giriniz");
                string letter = Console.ReadLine();
                bool isLetterExistInWord = CheckLetterInWord(selectedWord, letter);
                if (isLetterExistInWord)
                {
                    puzzle = ReplaceStarToLetter(selectedWord, puzzle, letter);
                }
                else
                {
                    life--;
                    if (life <= 0)
                    {
                        DrawGame(life);
                        break;
                    }
                }
                Console.WriteLine(puzzle);
                Console.WriteLine("Kelimeyi tahmin etmek ister misin? (E/H)");
                string answerForGuess = Console.ReadLine();
                if (answerForGuess.ToUpper() == "E")
                {
                    Console.WriteLine("Tahmininizi giriniz:");
                    string guess = Console.ReadLine();

                    if (CompareGuessAndSelectedWord(guess, selectedWord))
                    {
                        Console.WriteLine("Tebrikler!");
                        isWordFinding = true;
                    }
                    else
                    {
                        Console.WriteLine("Yanlış tahmin.");
                        life--;
                    }
                }
            }
            return life;
        }

        private static bool CompareGuessAndSelectedWord(string guess, string selectedWord)
        {
            return guess == selectedWord;
        }


        /// <summary>
        /// Belirli kelimelerin içinden rastgele kelime seçer
        /// </summary>
        /// <param name="words">kelimelerin bulunduğu koleksiyon</param>
        /// <returns></returns>
        static string ChooseWord(int level)
        {
            Random random = new Random();
            string word = String.Empty;
            
            switch (level)
            {
                case 0:    
                    string[] words = { "ayna", "masa", "kasa", "rock" };
                    word = words[random.Next(0, words.Length)];
                    return word;
                case 1:
                    random = new Random();
                    string[] words1 = { "sekiz", "sakız", "dilek", "delik" };
                    word = words1[random.Next(0, words1.Length)];
                    return word;
                case 2:
                    random = new Random();
                    string[] words2 = { "parlak", "kartal", "mantar", "pulsar" };
                    word = words2[random.Next(0, words2.Length)];
                    return word;
                case 3:
                    random = new Random();
                    string[] words3 = { "korteks", "plastik", "fraktal", "prenses" };
                    word = words3[random.Next(0, words3.Length)];
                    return word;
            }
            return word;
        }

        private static string ReplaceToStar(string selectedWord)
        {
            string puzzleResult = string.Empty;
            for (int i = 0; i < selectedWord.Length; i++)
            {
                puzzleResult += "*";
            }
            return puzzleResult;
        }

        /// <summary>
        /// Bu metod ile bir kelimede bir harf olup olmadığını bulursunuz.
        /// </summary>
        /// <param name="selectedWord">Kaynak kelime</param>
        /// <param name="letter">Aranacak harf</param>
        /// <returns></returns>
        private static bool CheckLetterInWord(string selectedWord, string letter)
        {
            return selectedWord.Contains(letter);
        }


        private static string ReplaceStarToLetter(string selectedWord, string puzzle, string letter)
        {
            int startIndex = 0;
            char[] puzzleStars = puzzle.ToCharArray();
            while (selectedWord.IndexOf(letter, startIndex) != -1)
            {
                int findingIndex = selectedWord.IndexOf(letter, startIndex);
                puzzleStars[findingIndex] = Convert.ToChar(letter);
                startIndex = findingIndex + 1;

            }

            string result = string.Empty;
            foreach (var item in puzzleStars)
            {
                result += item.ToString();
            }

            return result;

        }

        /// <summary>
        /// Adam asmaca oyununu çizer.
        /// </summary>
        /// <param name="life"></param>
        private static void DrawGame(int life)
        {
            switch (life)
            {
                case 0:
                    Console.WriteLine("-------------");
                    Console.WriteLine("|           |");
                    Console.WriteLine("|           |");
                    Console.WriteLine("| Game Over |");
                    Console.WriteLine("|           |"); 
                    Console.WriteLine("|           |");
                    Console.WriteLine("-------------");
                    break;
                case 1:
                    Console.WriteLine("-------------");
                    Console.WriteLine("|           |");
                    Console.WriteLine("|     O     |");
                    Console.WriteLine("|           |");
                    Console.WriteLine("|           |");
                    Console.WriteLine("|           |");
                    Console.WriteLine("-------------");
                    break;
                case 2:
                    Console.WriteLine("-------------");
                    Console.WriteLine("|           |");
                    Console.WriteLine("|     O     |");
                    Console.WriteLine("|     |     |");
                    Console.WriteLine("|           |");
                    Console.WriteLine("|           |");
                    Console.WriteLine("-------------");
                    break;
                case 3:
                    Console.WriteLine("-------------");
                    Console.WriteLine("|           |");
                    Console.WriteLine("|     O     |");
                    Console.WriteLine("|    /|     |");
                    Console.WriteLine("|           |");
                    Console.WriteLine("|           |");
                    Console.WriteLine("-------------");
                    break;
                case 4:
                    Console.WriteLine("-------------");
                    Console.WriteLine("|           |");
                    Console.WriteLine("|     O     |");
                    Console.WriteLine("|    /|\\    |");
                    Console.WriteLine("|           |");
                    Console.WriteLine("|           |");
                    Console.WriteLine("-------------");
                    break;
                case 5:
                    Console.WriteLine("-------------");
                    Console.WriteLine("|           |");
                    Console.WriteLine("|     O     |");
                    Console.WriteLine("|    /|\\    |");
                    Console.WriteLine("|    /      |");
                    Console.WriteLine("|           |");
                    Console.WriteLine("-------------");
                    break;
                case 6:
                    Console.WriteLine("-------------");
                    Console.WriteLine("|           |");
                    Console.WriteLine("|     O     |");
                    Console.WriteLine("|    /|\\    |");
                    Console.WriteLine("|    / \\    |");
                    Console.WriteLine("|           |");
                    Console.WriteLine("-------------");
                    break;
            }
        }
    }
}
