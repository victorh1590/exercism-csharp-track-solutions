using System;
using System.Text;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        StringBuilder song = new();
        int numBottles = startBottles+1;

        /* Phrases */
        string BottlesOfBeer(int numBottles) => numBottles switch
        {
            > 1 => $"{numBottles} bottles of beer",
            1 => $"{numBottles} bottle of beer",
            _ => "No more bottles of beer"
        };
        string Take(string what) => "Take " + what + " down and pass it around, ";
        string OnTheWall(bool endOfPhrase) => " on the wall" + (endOfPhrase ? "." : ", ");
        
        /* Lines */
        string FirstVerse() => BottlesOfBeer(numBottles) 
                               + OnTheWall(false) 
                               + BottlesOfBeer(numBottles).ToLower()
                               + ".\n";

        string SecondVerse()
        {
            return numBottles switch
            {
                >= 2 => Take("one") 
                        + BottlesOfBeer(numBottles - 1).ToLower() 
                        + OnTheWall(true),
                1 => Take("it") 
                     + BottlesOfBeer(numBottles - 1).ToLower() 
                     + OnTheWall(true),
                _ => "Go to the store and buy some more, " 
                     + BottlesOfBeer(99) 
                     + OnTheWall(true)
            };
        }
        
        while (--numBottles > -1)
        {
            song.Append(FirstVerse() + SecondVerse());
            if (--takeDown == 0) break;
            song.Append("\n\n");
        }
        
        return song.ToString();
    }
}