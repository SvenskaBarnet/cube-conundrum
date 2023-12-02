string[] input = File.ReadAllLines("data.txt");
int sum = 0;

foreach (string line in input)
{
    int maxGreen = 0;
    int maxRed = 0;
    int maxBlue = 0;
    string[] firstSplit = line.Split(':')[1].Split(';');
    foreach (string game in firstSplit)
    {
        string[] secondSplit = game.Split(',');
        foreach (string set in secondSplit)
        {
            int cubeAmount = GetDigits(set);
            if (set.Contains("red") && cubeAmount > maxRed)
            {
                maxRed = cubeAmount;
            }
            if (set.Contains("green") && cubeAmount > maxGreen)
            {
                maxGreen = cubeAmount;
            }
            if (set.Contains("blue") && cubeAmount > maxBlue)
            {
                maxBlue = cubeAmount;
            }
        }
    }
    sum += maxRed * maxGreen * maxBlue;
}

Console.WriteLine(sum);

static int GetDigits(string input)
{
    string digits = new string(input.Where(char.IsDigit).ToArray());
    int output = int.Parse(digits);
    return output;
}
