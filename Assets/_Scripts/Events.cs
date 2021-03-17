using UnityEngine;
using UnityEngine.Events;

namespace Rudrac.BrockenSteel
{
    public static class Events
    {
        [System.Serializable] public class GameStateChangeEvent : UnityEvent<GameState, GameState> { };
        [System.Serializable] public class GameModeChangeEvent : UnityEvent<GameMode> { };
        
    }
}