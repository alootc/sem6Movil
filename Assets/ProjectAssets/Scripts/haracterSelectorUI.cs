using UnityEngine;
using UnityEngine.UI;

public class haracterSelectorUI : MonoBehaviour
{
    [SerializeField] private Button playButton;

    private void Start()
    {
        // Asigna este m�todo al bot�n Play
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        // Llama al m�todo que carga Game + Results
        SceneGlobalManager.Instance.LoadGameWithResults();

        // Opcional: Desactivar el bot�n para evitar m�ltiples clics
        playButton.interactable = false;

        Debug.Log("Iniciando juego con escena Results cargada");
    }
}
