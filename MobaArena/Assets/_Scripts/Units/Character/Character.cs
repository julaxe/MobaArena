using _Scripts.Scriptables;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private ScriptableCharacterBase baseCharacter;
    
    //spells
    
    private void Awake() => ExampleGameManager.OnBeforeStateChanged += OnStateChanged;

    private void OnDestroy() => ExampleGameManager.OnBeforeStateChanged -= OnStateChanged;

    private void OnStateChanged(GameState newState)
    {
        
    }

    private void OnMouseDown() {
        // Only allow interaction when it's the hero turn
        if (ExampleGameManager.Instance.State != GameState.HeroTurn) return;

        // Eventually either deselect or ExecuteMove(). You could split ExecuteMove into multiple functions
        // like Move() / Attack() / Dance()

        Debug.Log("Unit clicked");
    }
    
}