

Console.WriteLine("Player 1:");
string player1 = Console.ReadLine();

Console.WriteLine("Player 2:");
string player2 = Console.ReadLine();

Console.Clear();

Console.WriteLine(player1 + " you are O");

Thread.Sleep(2000);

Console.WriteLine(player2 + " you are X");

string collum1 = "[1][2][3]";
string collum2 = "[1][2][3]";
string collum3 = "[1][2][3]";

bool hasWon = false;
bool hasTie = false;

string ClearLine(string collum)
{

    string one = collum.Replace("1", " ");
    string two = one.Replace("2", " ");
    string three = two.Replace("3", " ");

    return three;

}

void WriteClearBoard()
{

    Console.WriteLine(ClearLine(collum1));
    Console.WriteLine(ClearLine(collum2));
    Console.WriteLine(ClearLine(collum3));

}

int GetNumber(string type)
{
    Console.WriteLine(type + ":");
    int.TryParse(Console.ReadLine(), out int collum);

    if (collum < 0 || collum > 3)
    {

        Console.WriteLine("enter a valid " + type +  "number from 1 to 3");
        GetNumber(type);

    }

    return collum;
}

string CheckWin(int collum, int slot, char letter)
{

    if (collum1[1] == letter && collum1[4] == letter && collum1[7] == letter)
    {
            
        return "won";

    }

    if (collum1[1] == letter && collum2[1] == letter && collum3[1] == letter)
    {

        return "won";

    }

    if (collum1[1] == letter && collum2[4] == letter && collum3[7] == letter)
    {

        return "won";

    }

    if (collum1[1] == letter && collum2[4] == letter && collum3[7] == letter)
    {

        return "won";

    }

    if (collum2[1] == letter && collum2[4] == letter && collum2[7] == letter)
    {

        return "won";

    }

    if (collum1[4] == letter && collum2[4] == letter && collum3[4] == letter)
    {

        return "won";

    }

    if (collum1[7] == letter && collum2[4] == letter && collum3[1] == letter)
    {

        return "won";

    }

    if (collum3[1] == letter && collum3[4] == letter && collum3[7] == letter)
    {

        return "won";

    }

    if (collum1[7] == letter && collum2[7] == letter && collum3[7] == letter)
    {

        return "won";

    }

    bool allOn1 = (collum1[1] == 'X' || collum1[1] == 'O') && (collum1[4] == 'X' || collum1[4] == 'O') && (collum1[7] == 'X' || collum1[7] == 'O');
    bool allOn2 = (collum2[1] == 'X' || collum2[1] == 'O') && (collum2[4] == 'X' || collum2[4] == 'O') && (collum2[7] == 'X' || collum2[7] == 'O');
    bool allOn3 = (collum3[1] == 'X' || collum3[1] == 'O') && (collum3[4] == 'X' || collum3[4] == 'O') && (collum3[7] == 'X' || collum3[7] == 'O');

    if (allOn1 && allOn2 && allOn3)
    {

        return "tie";

    }

    return "set";

}

string Set(int collum, int slot, char letter)
{

    if (collum == 1)
    {

        if (!collum1.Contains(slot.ToString()))
        {

            return "!set";

        }

        collum1 = collum1.Replace(slot.ToString(), letter.ToString());

        return CheckWin(collum, slot, letter);

    }

    if (collum == 2)
    {

        if (!collum2.Contains(slot.ToString()))
        {

            return "!set";

        }

        collum2 = collum2.Replace(slot.ToString(), letter.ToString());

        return CheckWin(collum, slot, letter);

    }

    if (collum == 3)
    {

        if (!collum3.Contains(slot.ToString()))
        {

            return "!set";

        }

        collum3 = collum3.Replace(slot.ToString(), letter.ToString());

        return CheckWin(collum, slot, letter);

    }

    return "set";

}

void Turn(char letter)
{

    if (!hasWon && !hasTie)
    {

        if (letter == 'O')
        {

            Console.WriteLine(player1 + "'s turn (O)");

        }
        else if (letter == 'X')
        {

            Console.WriteLine(player2 + "'s turn (X)");

        }

        int collum = GetNumber("collum");
        int slot = GetNumber("slot");

        string set = Set(collum, slot, letter);

        if (set == "!set")
        {

            Console.Clear();

            Console.WriteLine("Slot occupied");

            Thread.Sleep(1000);

            Console.Clear();

            WriteClearBoard();

            Turn(letter);

        }
        else if (set == "set")
        {

            Console.Clear();

            WriteClearBoard();

        }
        else if (set == "won")
        {

            Console.Clear();

            WriteClearBoard();

            if (letter == 'O')
            {

                Console.WriteLine(player1 + " won!");

            }
            else if (letter == 'X')
            {

                Console.WriteLine(player2 + " won!");

            }

            hasWon = true;

        }
        else if (set == "tie")
        {

            hasTie = true;

            Console.Clear();

            Console.WriteLine("Tie!");

        }

    }

}

Thread.Sleep(2000);

Console.Clear();

WriteClearBoard();

Turn('O');

Turn('X');

Turn('O');

Turn('X');

Turn('O');

Turn('X');

Turn('O');

Turn('X');

Turn('O');
