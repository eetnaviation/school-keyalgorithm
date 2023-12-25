using System.Text.RegularExpressions;

while (true)
{
    Console.WriteLine("Enter mode (1 for keygen 2 for checker): ");
    string mode = Console.ReadLine();
    if (mode == "1")
    {
        keygen();
    }
    else if (mode == "2")
    {
        keyChecker();
    }
    else
    {
        Console.WriteLine("Incorrect mode selection");
    }
}
static void keygen()
{
    Console.WriteLine("Running in keygen mode!");
    Console.WriteLine("Enter email: ");
    string username = Console.ReadLine();
    string usernameNumeric = getAlphabetNumberFromString(username);
    string allowedActions = "";

    bool userActionWhileExit = false;

    //Create checksum to define allowed functions
    while (userActionWhileExit != true)
    {
        Console.WriteLine("What actions is the user allowed to do? (1 for JAVA, 2 for BEDROCK, 3 for both): ");
        allowedActions = Console.ReadLine();
        if (allowedActions == "1" || allowedActions == "2" || allowedActions == "3")
        {
            userActionWhileExit = true;
        }
        else
        {
            Console.WriteLine("Invalid option!");
        }
    }
    var random = new Random();
    string productKey = "";
    if (allowedActions == "1")
    {
        productKey = random.Next(100, 201).ToString() + usernameNumeric;
    } 
    else if (allowedActions == "2")
    {
        productKey = random.Next(300, 601).ToString() + usernameNumeric;
    } 
    else if (allowedActions == "3")
    {
        productKey = random.Next(700, 901).ToString() + usernameNumeric;
    }
    string finalProductKey = dropCharacters(productKey);
    Console.WriteLine("Final product key: " + finalProductKey);
    Console.WriteLine("-- FINISHED OPERATION --");
    Console.WriteLine("");
}

static void keyChecker()
{
    Console.WriteLine("Enter email: ");
    string username = Console.ReadLine();
    Console.WriteLine("Enter key: ");
    string productKey = Console.ReadLine();
    string usernameNumeric = getAlphabetNumberFromString(username);
    string usernameNumericInput = productKey.Substring(3);
    string productKeyActionId = productKey.Substring(0, 3);
    int productKeyChecksumInt = Int32.Parse(productKeyActionId); //tuleb kui panna keycheckeris key alla tahed (bug)

    if (usernameNumericInput == usernameNumeric && productKeyChecksumInt > 100)
    {
        if (productKeyChecksumInt > 100 && productKeyChecksumInt < 201)
        {
            Console.WriteLine("Key valid! JAVA");
        }
        else if (productKeyChecksumInt > 300 && productKeyChecksumInt < 601)
        {
            Console.WriteLine("Key valid! BEDROCK");
        }
        else if (productKeyChecksumInt > 700 && productKeyChecksumInt < 901)
        {
            Console.WriteLine("Key valid! BOTH");
        }
        else
        {
            Console.WriteLine("Key invalid.");
        }
    }
    else
    {
        Console.WriteLine("Key invalid.");
    }
    Console.WriteLine("-- FINISHED OPERATION --");
    Console.WriteLine("");
}

static string dropCharacters(string input)
{
    //Drop all characters that are not numbers
    string output = Regex.Replace(input, "[^.0-9]", "");
    return output;
}
static string CreateMD5(string input)
{
    using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
    {
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        return Convert.ToHexString(hashBytes);
    }
}

static int convertToNumbers(string input)
{
    var ch = input[0];
    char c = ch;
    int index = char.ToUpper(c) - 64;
    int finalIndex = index;
    return finalIndex;
}

static string getAlphabetNumberFromString(string input)
{
    string finalInput = getLetters(input);
    int length = 5;
    int trueLength = finalInput.Length;
    if (trueLength < 5)
    {
        length = trueLength;
    }
    string finalSum = "";

    for (int i = 0; i < length; i++)
    {
        int differentI = i - 1;
        string differentIString = differentI.ToString();
        string currentCharacter = finalInput.Substring(i, 1);

        finalSum = finalSum + convertToNumbers(currentCharacter);
    }
    string convertedFinalSum = finalSum.ToString();
    return convertedFinalSum;
}

static string getLetters(string input)
{
    var myString = input;
    var onlyLetters = new String(myString.Where(Char.IsLetter).ToArray());
    return onlyLetters.ToString();
}