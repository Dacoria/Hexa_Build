using System.Collections.Generic;

public interface IRscInState
{
    public RscType RscType { get; }
    public int RscAvailableInit { get; }
    public HexStateType StateToIfNoMoreRsc { get; }
}