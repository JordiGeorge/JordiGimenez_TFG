using UnityEngine;


public enum GameState
{
    Exploration,
    Inventory,
    Puzzle,
    StoryMode
}

public class GameStateManager : MonoBehaviour
{
    private GameState currentState;

    void Start()
    {
        // Initialize the starting state, e.g., Exploration
        SetState(GameState.Exploration);
    }

    public void SetState(GameState newState)
    {
        currentState = newState;

        // Exit logic for the current state
        switch (currentState)
        {
            case GameState.Exploration:
                // Enable player movement, exploration interactions, etc.
                EnableExploration();
                break;
            case GameState.Inventory:
                // Enable inventory UI, item examination, etc.
                EnableInventoryAndAnalysis();
                break;
            case GameState.Puzzle:
                // Enable puzzle mechanics, interactions, etc.
                EnablePuzzle();
                break;
            case GameState.StoryMode:
                // Play cutscene or handle transition effects
                StartCutsceneOrTransition();
                break;
        }

        // Add any additional logic needed when switching states
    }

    private void EnableExploration()
    {
        // Logic for enabling exploration state
    }

    private void EnableInventoryAndAnalysis()
    {
        // Logic for enabling inventory and analysis state
    }

    private void EnablePuzzle()
    {
        // Logic for enabling puzzle state
    }

    private void StartCutsceneOrTransition()
    {
        // Logic for handling cutscenes and transitions
    }

    // Update or other methods can be used for state-specific logic
    void Update()
    {
        switch (currentState)
        {
            case GameState.Exploration:
                // Update logic for exploration
                break;
            case GameState.Inventory:
                // Update logic for inventory and analysis
                break;
            case GameState.Puzzle:
                // Update logic for puzzles
                break;
            case GameState.StoryMode:
                // Update logic for cutscene or transition
                break;
        }
    }
}



