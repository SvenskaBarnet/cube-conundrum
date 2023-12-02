using System.Runtime.CompilerServices;

string[] input = File.ReadAllLines("data.txt");

int sum = 0;

for (int i = 0; i < input.Length; i++)
{
    bool possible = true;
    int currentGame = i + 1;
    string[] firstSplit = input[i].Split(':')[1].Split(';');

    for (int j = 0; j < firstSplit.Length; j++)
    {
        string[] secondSplit = firstSplit[j].Split(',');

        for (int k = 0; k < secondSplit.Length; k++)
        {
            int cubeAmount = GetDigit(secondSplit[k]);
            if (secondSplit[k].Contains("red") && cubeAmount > 12)
            {
                possible = false;
            }
            else if (secondSplit[k].Contains("green") && cubeAmount > 13)
            {
                possible = false;
            }
            else if (secondSplit[k].Contains("blue") && cubeAmount > 14)
            {
                possible = false;
            }
        }
    }

    if (possible)
    {
        sum += currentGame;
    }
}

Console.WriteLine(sum);

static int GetDigit(string input)
{
    string digits = new string(input.Where(c => char.IsDigit(c)).ToArray());
    int output = int.Parse(digits);
    return output;
}