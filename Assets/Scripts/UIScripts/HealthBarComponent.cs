using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UIScripts
{
    public class HealthBarComponent : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Scrollbar _scrollbar;

        private void Update()
        {
            this._scrollbar.value = Mathf.Lerp(
                a: this._scrollbar.value,
                b: this._healthComponent.Health / this._healthComponent.MaxHealth,
                t: Time.deltaTime * 5);
            this._text.text = $"\u2665 {this._healthComponent.Health}";
        }
    }
}