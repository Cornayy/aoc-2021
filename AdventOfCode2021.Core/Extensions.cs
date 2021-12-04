namespace AdventOfCode2021.Core;

public static class Extensions
{
    public static IEnumerable<int> ConvertToIntegerEnumerable(this IEnumerable<string> enumerable)
    {
        return enumerable.Select(x => int.Parse(x));
    }

    public static string UpperFolder(this string folderName, int level)
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
    public static string CurrentProjectFolder(this string sender)
    {
        return sender.UpperFolder(3);
    }
}