// Komt overeen met namen van de shaders -> vereist!

using System.Collections.Generic;

public enum HexSurfaceType
{   
    Barren,    
    Clay_A,
    Blue_3D_Blocks,
    Bricks,
    Sand_A,
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
    Water_A,
    Water_Light,
    Water_Ice_Cracked,
    Yellow_Stone,
}

public static class HexSurfaceExt
{
    public static HexSurfaceType Barren() => HexSurfaceType.Barren;
    public static HexSurfaceType Soil() => HexSurfaceType.Sand_Dirt;
    public static HexSurfaceType Sand() => HexSurfaceType.Sand_A;
    public static HexSurfaceType Water() => HexSurfaceType.Water_A;
    public static HexSurfaceType Clay() => HexSurfaceType.Clay_A;
    public static HexSurfaceType BuildingArea() => HexSurfaceType.Light_Grey_Stone;
    public static HexSurfaceType Transparant() => HexSurfaceType.Transparant;
    public static bool IsVisible(this HexSurfaceType surfaceType) => surfaceType != Transparant();
}