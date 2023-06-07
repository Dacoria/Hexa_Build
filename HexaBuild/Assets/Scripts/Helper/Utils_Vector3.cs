using UnityEngine;

public static partial class Utils
{
    public static bool IsEmpty(this Vector2 vector) => vector.x == 0 && vector.y == 0;

    public static Vector3 DefaultEmptyV3 = new Vector3(-1, -1, -1);
    public static Vector3Int DefaultEmptyV3Int = new Vector3Int(-1, -1, -1);

    public static float xOffset = 2f, yOffset = 1f, zOffset = 1.73f;
    public static Vector3Int ConvertPositionToCoordinates(this Vector3 position)
    {
        var x = Mathf.CeilToInt(position.x / xOffset);
        var y = Mathf.RoundToInt(position.y / yOffset);
        var z = Mathf.RoundToInt(position.z / zOffset);

        return new Vector3Int(x, y, z);
    }

    public static Vector3 ConvertCoordinatesToPosition(this Vector3Int position)
    {
        if (position.z % 2 == 0)
        {
            var x = position.x * xOffset;
            var y = position.y * yOffset;
            var z = position.z * zOffset;
            return new Vector3(x, y, z);
        }
        else
        {
            var x = position.x * xOffset - 1;
            var y = position.y * yOffset;
            var z = position.z * zOffset;
            return new Vector3(x, y, z);
        }
    }
}