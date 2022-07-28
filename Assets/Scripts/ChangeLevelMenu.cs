using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeLevelMenu : MonoBehaviour
{
        [SerializeField] private PlayerState _playerState;
        [SerializeField] private Button _changeLevel;
        
        [SerializeField] private GameObject _popup;
        [SerializeField] private InputField _field;
        [SerializeField] private Button _ok;

        private void Awake() {
                _popup.gameObject.SetActive(false);
                
                _changeLevel.onClick.AddListener(ShowPopup);
                _ok.onClick.AddListener(ChangeLevel);
        }

        private void ShowPopup() {
                _popup.gameObject.SetActive(true);
        }

        private void ChangeLevel() {
                var canChange = int.TryParse(_field.text, out int x);
                if (canChange) {
                        _playerState.ResetSave();
                        _playerState.level = x-1;
                        _playerState.Save();
                        SceneManager.LoadScene(1);
                }
        }
}