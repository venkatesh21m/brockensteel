

namespace Rudrac.BrockenSteel
{
    public enum ColorType
    {
        Red,
        Green,
        Blue,
        Yellow,
        Violet,
        core,
        FireWall
    }

    public enum GameState
    {
        pregame,
        JourneyGame,
        InfiniteGame,
        Paused,
        GameOver
    }

    public enum GameMode
    {
        Defence,
        attack
    }

    public enum MovementType
    {
       strait,
       rotating,
       zigzag
    }


    public enum PowerUps
    {
        Impulse,
        SlowMotion,
        Holograph,
        EnergyBooster,
        ShieldRecovery,
        FireWall
    }
}