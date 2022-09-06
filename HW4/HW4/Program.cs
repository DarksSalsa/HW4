using static System.Console;

Random r = new ();
Write("Enter the number of elements: ");
int number = System.Convert.ToInt32(ReadLine());
int[] arr = new int[number];
int counterEven = 0;

// creating initial array
for (int i = 0; i < number; i++)
{
    arr[i] = r.Next(1, 27);
    if (arr[i] % 2 == 0)
    {
        counterEven++;
    }
}

int[] evenArr = new int[counterEven];
int[] oddArr = new int[number - counterEven];
int k = 0;
int m = 0;

// Filling arrays with numbers
for (int j = 0; j < number; j++)
{
    if (arr[j] % 2 == 0)
    {
        evenArr[k] = arr[j];
        k++;
    }
    else
    {
        oddArr[m] = arr[j];
        m++;
    }
}

// Swapping numbers with words and counting special spectre
char[] alph = "AbcDEfgHIJklmnopqrstuvwxyz".ToCharArray();
char[] charEvenArr = new char[k];
char[] charOddArr = new char[m];
int scales = 0;
for (int l = 0; l < Math.Max(k, m); l++)
{
    if (l >= k)
    {
        charOddArr[l] = alph[oddArr[l]];
        switch (charOddArr[l])
        {
            case 'A':
            case 'D':
            case 'E':
            case 'I':
            case 'H':
            case 'J':
                scales++;
                break;
        }

        continue;
    }

    if (l >= m)
    {
        charEvenArr[l] = alph[evenArr[l]];
        switch (charEvenArr[l])
        {
            case 'A':
            case 'D':
            case 'E':
            case 'I':
            case 'H':
            case 'J':
                scales--;
                break;
        }

        continue;
    }

    charEvenArr[l] = alph[evenArr[l] - 1];
    switch (charEvenArr[l])
    {
        case 'A':
        case 'D':
        case 'E':
        case 'I':
        case 'H':
        case 'J':
            scales--;
            break;
    }

    charOddArr[l] = alph[oddArr[l]];
    switch (charOddArr[l])
    {
        case 'A':
        case 'D':
        case 'E':
        case 'I':
        case 'H':
        case 'J':
            scales++;
            break;
    }
}

if (scales < 0)
{
    WriteLine("The array with even numbers has more special chars.");
}
else if (scales > 0)
{
    WriteLine("The array with odd numbers has more special chars.");
}
else
{
    WriteLine("Both arrays have an equal number of special chars.");
}

// Writing both arrays to console
Write("charEvenArr: ");
foreach (char x in charEvenArr)
{
    Write($"{x} ");
}

WriteLine();
Write("charOddArr: ");
foreach (char y in charOddArr)
{
    Write($"{y} ");
}
