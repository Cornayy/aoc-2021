namespace AdventOfCode2021.Core.Common;

public static class Extensions
{
    public static IEnumerable<int> ConvertToIntegerEnumerable(this IEnumerable<string> enumerable)
    {
        return enumerable.Select(x => int.Parse(x));
    }

    public static IEnumerable<(int row, int column, T value)> Flat<T>(this T[,] src)
    {
        for (var i = 0; i < src.GetLength(0); i++)
        {
            for (var j = 0; j < src.GetLength(1); j++)
            {
                yield return (i, j, src[i, j]);
            }
        }
    }

    public static string GetUpperFolder(this string folderName, int level)
    {
        var folderList = new List<string>();

        while (!string.IsNullOrEmpty(folderName))
        {
            var temp = Directory.GetParent(folderName);
            if (temp == null)
            {
                break;
            }

            folderName = temp.FullName;
            folderList.Add(folderName);
        }

        if (folderList.Count > 0 && level > 0)
        {
            if (level - 1 <= folderList.Count - 1)
            {
                return folderList[level - 1];
            }
        }

        return folderName;
    }

    public static string GetCurrentProjectFolder(this string sender)
    {
        return sender.GetUpperFolder(3);
    }
}