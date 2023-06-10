// Komt overeen met namen van de shaders -> vereist!

using System.Collections.Generic;

public enum HexSurfaceType
{   
    Barren,    
    Big_Brown_Stones,
    Blue_3D_Blocks,
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
    SandRock,
    Simple_Plain,
    Simple_Rock,
    Simple_Sand,
    Simple_Water,
    Transparant,
    Water_Deep,
    Water_Light,
    Water_Ice_Cracked,
    Yellow_Stone,

}

public static class HexSurfaceExt
{
    public static bool CanChangeSurfaceType(this Hex hex) => 
        hex.AllowedHexSurfaceTypes().Count > 0;

    public static List<ResourceAmount> Cost(this HexSurfaceType surfaceType) => surfaceType switch
    {
        HexSurfaceType.Sand_Dirt => Utils.Rsc(ResourceType.Mana, 5),
        HexSurfaceType.Light_Grey_Stone => Utils.Rsc(ResourceType.Mana, 10),    
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
        return surfaceType == HexSurfaceType.Barren;
    }

    public static bool IsDiscoverable(this HexSurfaceType surfaceType)
    {
        return surfaceType == HexSurfaceType.Transparant;
    }

    public static bool IsBuildGround(this HexSurfaceType surfaceType)
    {
        return surfaceType == HexSurfaceType.Light_Grey_Stone;
    }

    public static bool IsSoilGround(this HexSurfaceType surfaceType)
    {
        return surfaceType == HexSurfaceType.Sand_Dirt;
    }

    public static bool IsWater(this HexSurfaceType surfaceType) => surfaceType switch
    {
        HexSurfaceType.Water_Deep => true,
        HexSurfaceType.Water_Ice_Cracked => true,
        HexSurfaceType.Water_Light => true,
        HexSurfaceType.Simple_Water => true,

        _ => false
    };
}