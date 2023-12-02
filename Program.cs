string[] data = File.ReadAllLines("data.txt");
int sum = 0;

foreach (string line in data)
{
    int red = 0;
    int blue = 0;
    int green = 0;
    string[] firstSplit = line.Split(':');
    int gameNumber = GetDigits(firstSplit[0]);
    Console.Write($"game {gameNumber}: ");

    string[] secondSplit = firstSplit[1].Split(';');
    for (int i = 0; i < secondSplit.Length; i++)
    {
        string[] thirdSplit = secondSplit[i].Split(',');
        for (int j = 0; j < thirdSplit.Length; j++)
        {
            switch (thirdSplit[j])
            {
                case string a when a.Contains("red"):
                    red += GetDigits(thirdSplit[j]);
                    break;
                case string b when b.Contains("green"):
                    green += GetDigits(thirdSplit[j]);
                    break;
                case string c when c.Contains("blue"):
                    blue += GetDigits(thirdSplit[j]);
                    break;
            }
        }
    }

    Console.WriteLine($"red: {red}, blue: {blue}, green {green}");
    if (red < 13 && green < 14 && blue < 15)
    {
        sum += gameNumber;
    }
}

Console.WriteLine(sum);



static int GetDigits(string input)
{
    string digits = new string(input.Where(c => char.IsDigit(c)).ToArray());
    int output = int.Parse(digits);
    return output;
}