// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



int res = MatchingArray(new int[] { 1, 2, 3, -5, -5, 2, 3, 18 }, new int[] { 3,-2,3 });
int ress = matches(new int[] { 1, 2, 3, -5, -5, 2, 3, 18 }, new int[] { 3,-2,3 });
Console.WriteLine(res);
static int MatchingArray(int[] A, int[] P)
{
    int index = 0;
    int psum = 0;
    for(int i=0; i<=P.Length-1; i++)
    {
        if (P[i] < 0) P[i] = P[i] * (-1);
        psum += P[i];
    }
    if (psum != A.Length) return 0;
    for (int i = 0; i <= P.Length-1; i++)
    {
        int count = 0;

        for (int j = index; j <= A.Length-1; j++)
        {
            if ((P[i] > 0 && A[j] > 0) || (P[i] < 0 && A[j] < 0))
            {
                count++;
                continue;
            }
            if (P[i] < 0) P[i] = P[i] * (-1);
            if (count == P[i]) { index = count + index; break; }
            else return 0;
        }
    }
    return 1;
}
int matches(int[] a, int[] p)
{
    bool isPPositive = true;
    bool isAPositive = true;
    int firstElement = 0;
    int secondElement = p[0];
    int count = 0;
    int pSum = 0;
    int matches = 0;
    if (secondElement < 0)
    {
        secondElement = secondElement * -1;
        isPPositive = false;
    }

    int aLength = a.Length;
    for (int o = 0; o < p.Length; o++)
    {
        if (p[o] < 0) { pSum = pSum + (p[o] * -1); }
        else
            pSum = pSum + p[o];
    }
    if (pSum == aLength)
    {
        for (int i = 1; i < p.Length + 1; i++)
        {
            for (int j = firstElement; j < secondElement; j++)
            {
                if (a[j] < 0) isAPositive = false;
                if (isAPositive == true && isPPositive == true || isAPositive == false && isPPositive == false)
                    count++;
            }
            if (count == secondElement) matches = matches + 1;
            if (p.Length > i)
            {
                firstElement = secondElement;

                if (p[i] < 0)
                {
                    secondElement = secondElement + p[i] * -1;
                    isPPositive = false;
                }
                else secondElement = secondElement + p[i];
            }
            else break;
        }
        if (matches == p.Length)
            return 1;
    }
    return 0;
}