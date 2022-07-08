using UnityEngine;
using TMPro;

namespace Core.HUD
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private int _score = 0;

        public void AddPoint()
        {
            _score++;
            _text.SetText(_score.ToString());
        }
    }
}