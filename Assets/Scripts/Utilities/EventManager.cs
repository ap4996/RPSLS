using System;
using System.Collections.Generic;

public static class EventManager
{
    // Single dictionary to store all event listeners
    private static Dictionary<Events, Delegate> eventDictionary = new Dictionary<Events, Delegate>();

    // Subscribe to an event (supports both types of actions)
    public static void Subscribe(Events eventName, Action listener)
    {
        if (!eventDictionary.ContainsKey(eventName))
            eventDictionary[eventName] = null;

        eventDictionary[eventName] = (Action)eventDictionary[eventName] + listener;
    }

    public static void Subscribe<T>(Events eventName, Action<T> listener)
    {
        if (!eventDictionary.ContainsKey(eventName))
            eventDictionary[eventName] = null;

        eventDictionary[eventName] = (Action<T>)eventDictionary[eventName] + listener;
    }

    // Unsubscribe from an event
    public static void Unsubscribe(Events eventName, Action listener)
    {
        if (eventDictionary.ContainsKey(eventName))
            eventDictionary[eventName] = (Action)eventDictionary[eventName] - listener;
    }

    public static void Unsubscribe<T>(Events eventName, Action<T> listener)
    {
        if (eventDictionary.ContainsKey(eventName))
            eventDictionary[eventName] = (Action<T>)eventDictionary[eventName] - listener;
    }

    // Trigger an event
    public static void TriggerEvent(Events eventName)
    {
        if (eventDictionary.ContainsKey(eventName) && eventDictionary[eventName] is Action action)
        {
            action?.Invoke();
        }
    }

    public static void TriggerEvent<T>(Events eventName, T data)
    {
        if (eventDictionary.ContainsKey(eventName) && eventDictionary[eventName] is Action<T> action)
        {
            action?.Invoke(data);
        }
    }
}


public enum Events
{
    ChoiceSelected,
    TimerEnded,
    GameResult,
    StartGame,
    RestartGame,
    StartTimer
}