// Komt overeen met namen van de shaders -> vereist!

using System.Collections.Generic;

public enum HexSurfaceType
{
    Simple_Plain,
    Simple_Rock,
    Simple_Sand,
    Simple_Water,
    Big_Brown_Stones,
    Bricks,
    Desert_Sand,
    Flowers,
    Grass,
    Ice,
    Ice_Dark,
    Light_Grey_Stone,
    Magma,
    Poison,
    Purple_Cracks,
    Purple_Crystal,
    Sand_Dirt,
    Snow,
    Snow_Rocks,
    Water_Deep,
    Water_Moving,
    Water_Ice_Cracked,
    Yellow_Stone,
    SandRock,
    Water_Light,
    Blue_3D_Blocks,
}

public static class HexSurfaceExt
{
    public static bool CanChangeSurfaceType(this Hex hex) => 
        hex.AllowedHexSurfaceTypes().Count > 0;

    public static List<ResourceAmount> BuildCost(this HexSurfaceType surfaceType) => surfaceType switch
    {
        HexSurfaceType.Sand_Dirt => new List<ResourceAmount> { new ResourceAmount(5, ResourceType.Mana) },
        HexSurfaceType.Light_Grey_Stone => new List<ResourceAmount> { new ResourceAmount(10, ResourceType.Mana) },
        _ => new List<ResourceAmount>()
    };

    public static List<HexSurfaceType> AllowedHexSurfaceTypes(this Hex hex)
    {
        if(hex.HexSurfaceType.IsBarren())
        {
            return new List<HexSurfaceType>
            {
                HexSurfaceType.Sand_Dirt,
                HexSurfaceType.Light_Grey_Stone,
            };
        }

        return new List<HexSurfaceType>();
    }

    public static bool IsBarren(this HexSurfaceType surfaceType)
    {
        return surfaceType == HexSurfaceType.Simple_Sand;
    }

    public static bool CanBeDiscovered(this Hex hex)
    {
        return hex.FogIsActive();
    }

    public static bool IsWater(this HexSurfaceType surfaceType) => surfaceType switch
    {
        HexSurfaceType.Water_Deep => true,
        HexSurfaceType.Water_Moving => true,
        HexSurfaceType.Water_Ice_Cracked => true,
        HexSurfaceType.Water_Light => true,
        HexSurfaceType.Simple_Water => true,

        _ => false
    };
}