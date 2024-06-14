namespace Hex_plorer.Providers;

public static class DirectoryProvider
{

    public static string[] GetActiveDisks()
    {
        List<string> disks = [];

        foreach (var drive in DriveInfo.GetDrives())
        {
            if (!drive.IsReady)
                continue;
            disks.Add(drive.Name.Trim(Path.DirectorySeparatorChar));
        }
        return [.. disks];
    }

    public static string[] GetAllDisks()
    {
        return [.. DriveInfo.GetDrives().Select(drive => drive.Name.Trim(Path.DirectorySeparatorChar))];
    }

    public static string[] GetDirectories(string path)
    {
        return Directory.GetDirectories(path);
    }

    public static string[] GetAccessibleDirectories(string path)
    {
        var directories = Directory.GetDirectories(path);
        List<string> accessibleDirectories = [];

        foreach (var directory in directories)
        {
            try
            {
                Directory.GetDirectories(directory);
                accessibleDirectories.Add(directory);
            }
            catch (UnauthorizedAccessException)
            { }
            catch (IOException)
            { }
        }
        return [.. accessibleDirectories];
    }
}