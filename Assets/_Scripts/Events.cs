using UnityEngine;
using UnityEngine.Events;

namespace Rudrac.BrockenSteel
{
    public static class Events
    {
        [System.Serializable] public class GameStateChangeEvent : UnityEvent<GameState, GameState> { };
        [System.Serializable] public class GameModeChangeEvent : UnityEvent<GameMode> { };
        [System.Serializable] public class TriggerEvent : UnityEvent { };
        [System.Serializable] public class Impulsetrigger : UnityEvent { };
        [System.Serializable] public class SlowMotiontrigger : UnityEvent<bool> { };
        [System.Serializable] public class Holographtrigger : UnityEvent { };
        [System.Serializable] public class EnergyBoostertrigger : UnityEvent { };
        [System.Serializable] public class ShieldRecoverytrigger : UnityEvent { };
        [System.Serializable] public class FireWalltrigger : UnityEvent { };
        [System.Serializable] public class JourneyStageIncrementtrigger : UnityEvent { };

    }
}